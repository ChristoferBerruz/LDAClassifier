using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapack;

namespace FaceRecognitionLDA
{
    class LDA
    {

        /// <summary>
        /// Dimensionality of the data
        /// </summary>
        public int DIM { set; get; }


        /// <summary>
        /// The number of distinct classes in the data.
        /// </summary>
        public int C { set { } get { return this.FacesByClass.Keys.Count; } }


        /// <summary>
        /// Matrix where each column corresponds to a datum. In our case, face.
        /// </summary>
        public IMatrix DataMatrix { set; get; }

        /// <summary>
        /// List of ATTFaces
        /// </summary>
        public List<ATTFace> FaceList { set; get; }

        /// <summary>
        /// Matrix where each column corresponds to a projection vector
        /// </summary>
        public IMatrix WMatrix { set; get; }

        /// <summary>
        /// Matrix where each columns corresponds to the projection of a datum in DataMatrix.
        /// Rows = C-1, as the dimensionality of the reduced spaced is C-1
        /// </summary>
        public IMatrix ProjectedMatrix { set; get; }

        /// <summary>
        /// Withing scatter matrix
        /// </summary>
        private IMatrix SW { set; get; }


        /// <summary>
        /// Dictionary that groups ATTFaces by each class, in our case is personID.
        /// </summary>
        public IDictionary<int, FaceClass> FacesByClass { set; get; }



        /// <summary>
        /// Mean image, or average across all data in this dimensionality space.
        /// </summary>
        public double[] meanImage { set; get; }

        public LDA(List<ATTFace> FacesNewDimension)
        {
            LoadData(FacesNewDimension);
        }

        public void Train(int newDim)
        {
            CalculateMeansForAllClasses();
            meanImage = CalculateMean(this.FaceList); //Mean image of all data
            SW = CalculateWithinclassScatter();
            IMatrix SB = CalculateBetweenclassScatter();
            IMatrix Res = SW.Inverse.Multiply(SB);
            IEigenvalueDecomposition Decomposition = Res.GetEigenvalueDecomposition();
            List<EigenObject> Eigens = GetSortedEigenObjects(Decomposition);
            Console.WriteLine(Eigens.Count);
            WMatrix = GetLDABase(Eigens, newDim); //The weighted matrix
            ProjectedMatrix = WMatrix.Transpose().Multiply(DataMatrix); //Projected samples
            ComputeLDAProjectionForList(this.FaceList);
        }


        /// <summary>
        /// Populates the data in FaceList, FacesGroupByClass, and DataMatrix
        /// </summary>
        /// <param name="trainingPath"> Path where training data is located</param>
        private void LoadData(List<ATTFace> FacesNewDimension)
        {
            this.FaceList = FacesNewDimension;
            DIM = FaceList[0].ImageVectorTransformed.Length;
            this.FacesByClass = new Dictionary<int, FaceClass>();
            this.DataMatrix = new Matrix(DIM, FaceList.Count);
            int j = 0; //Indexing for columns
            foreach (ATTFace Person in this.FaceList)
            {
                int wi = Person.personID;
                double[] x = Person.ImageVectorTransformed; //datum, column to be inserted in DataMatrix

                //---------- Populating Grouping the faces by classes -------------- 
                if (FacesByClass.ContainsKey(wi))
                {

                    FacesByClass[wi].FacesInClass.Add(Person);
                }
                else
                {
                    FaceClass SomeFaceClass = new FaceClass();
                    SomeFaceClass.TotalN = FaceList.Count;
                    SomeFaceClass.ID = wi;
                    SomeFaceClass.FacesInClass.Add(Person);
                    FacesByClass.Add(wi, SomeFaceClass);
                }

                //--------------- Putting values to the Matrix
                for (int i = 0; i < DataMatrix.Rows; i++)
                {
                    DataMatrix[i, j] = x[i];
                }
                j++;
            }
        }


        // --------------------------------------------- Methods Call when Train() is called --------------- //
        /// <summary>
        /// Calculates the mean for all the classes
        /// </summary>
        private void CalculateMeansForAllClasses()
        {
            foreach (KeyValuePair<int, FaceClass> entry in FacesByClass)
            {
                double[] classmean = CalculateMean(entry.Value.FacesInClass);
                entry.Value.MeanOfClass = classmean;
            }
        }

        /// <summary>
        /// Returns a sorted list of EigenObjects sorted by their corresponding comparator implemention (eigenvalue in our case)
        /// </summary>
        /// <param name="Decomposition">Decomposition after solving the GEVP</param>
        /// <returns></returns>
        private List<EigenObject> GetSortedEigenObjects(IEigenvalueDecomposition Decomposition)
        {
            List<EigenObject> Res = new List<EigenObject>();
            IMatrix Eigenvectors = Decomposition.EigenvectorMatrix;
            for (int j = 0; j < Eigenvectors.Columns; j++)
            {
                EigenObject Eigen = new EigenObject();
                double[] eigenvector = new double[Eigenvectors.Rows];
                double magnitude = 0.0;
                double eigenvalue = Decomposition.RealEigenvalues[j];
                for (int i = 0; i < Eigenvectors.Rows; i++)
                {
                    eigenvector[i] = Eigenvectors[i, j];
                    magnitude += Eigenvectors[i, j] * Eigenvectors[i, j];
                }
                magnitude = Math.Sqrt(magnitude);
                Eigen.Magnitude = magnitude;
                Eigen.Eigenvalue = eigenvalue;
                Eigen.Eigenvector = eigenvector;
                Res.Add(Eigen);
            }
            Res.Sort();
            return Res;
        }

        /// <summary>
        /// After solving the GEVP and having sorted the eigen values, we retrieve C-1 eigenvectors
        /// </summary>
        /// <param name="Eigens"> List of EigenObjects</param>
        /// <param name="numVectors">Number of vector.</param>
        /// <returns></returns>
        private IMatrix GetLDABase(List<EigenObject> Eigens, int numVectors)
        {
            if (numVectors > (C - 1)) throw new ArgumentException("LDA Produces at MOST C-1 eigenvectors.");
            if (Eigens == null || Eigens.Count < 1) throw new ArgumentException("EigenObject list cannot be empty nor null!");
            IMatrix Res = new Matrix(Eigens[0].Eigenvector.Length, numVectors);
            for (int j = 0; j < numVectors; j++)
            {
                EigenObject Eg = Eigens[j];
                for (int i = 0; i < Eg.Eigenvector.Length; i++)
                {
                    Res[i, j] = Eg.Eigenvector[i]/Eg.Magnitude;
                }
                Console.WriteLine(j + " : " + Eg.Eigenvalue);
            }
            return Res;
        }


        /// <summary>
        /// Computes the projection onto the LDABase (W) 
        /// </summary>
        /// <param name="Face"></param>
        /// <returns></returns>
        private double[] ComputeLDAProjection(ATTFace Face)
        {
            double[] x = Face.ImageVectorTransformed;
            double[] projected = new double[WMatrix.Columns]; //C-1 Dimensions
            for (int j = 0; j < this.WMatrix.Columns; j++)
            {
                double temp = 0.0;
                for (int i = 0; i < WMatrix.Rows; i++)
                {
                    temp += x[i] * WMatrix[i, j];
                }
                projected[j] = temp;
            }
            return projected;
        }

        /// <summary>
        /// Computes the LDA projection of all faces in a list
        /// </summary>
        /// <param name="Faces"></param>
        private void ComputeLDAProjectionForList(List<ATTFace> Faces)
        {
            foreach(ATTFace Face in Faces)
            {
                double[] projected = ComputeLDAProjection(Face);
                Face.LDAProjection = projected;
            }
        }

        //------------------------------------- To calculate Within Class Scatter ------------------------//

        /// <summary>
        /// Calculates the within class scatter.
        /// </summary>
        /// <returns></returns>
        private IMatrix CalculateWithinclassScatter()
        {
            IMatrix SW = new Matrix(DIM, DIM); //Square Matrix
            foreach (KeyValuePair<int, FaceClass> entry in FacesByClass)
            {
                double[] mean = entry.Value.MeanOfClass;
                IMatrix S = CalculateCovarianceMatrixForClass(entry.Value.FacesInClass, mean);
                SW = SW.Addition(S);
            }
            return SW;
        }

        /// <summary>
        /// It calculates the covariance matrix for a class.
        /// </summary>
        /// <param name="Faces"> List of ATTFaces</param>
        /// <param name="mean"> mean for the class</param>
        /// <returns></returns>
        private IMatrix CalculateCovarianceMatrixForClass(List<ATTFace> Faces, double[] mean)
        {
            IMatrix S = new Matrix(DIM, DIM); //S is a square matrix
            foreach (ATTFace Face in Faces)
            {
                double[] vector = SubstractArrays(Face.ImageVectorTransformed, mean);
                IMatrix X = Covariance(vector);
                S = S.Addition(X);
            }
            return S;
        }

        //----------------------------------------- Between Scatter Calculation functions ------------------- //

        /// <summary>
        /// Calculates Betweenclass Scatter of a dataset
        /// </summary>
        /// <returns></returns>
        public IMatrix CalculateBetweenclassScatter()
        {
            IMatrix SB = new Matrix(DIM, DIM); //We accumulate the sum here
            foreach (KeyValuePair<int, FaceClass> entry in FacesByClass)
            {
                double[] mean = entry.Value.MeanOfClass;
                double[] vector = SubstractArrays(mean, meanImage);
                IMatrix S = Covariance(vector);
                S = S.Multiply(entry.Value.NumberOfElements);
                SB = SB.Addition(S);
            }
            return SB;
        }


        //----------------------------- For prediction -------------------------------------//


        /// <summary>
        /// Predicts the class of a unknown face using a linear discriminant. It works in the original DIM space.
        /// </summary>
        /// <param name="Face"> Face to be categorized</param>
        /// <returns></returns>
        public int PredictClassUsingDiscriminant(ATTFace Face)
        {
            double[] x = Face.ImageVectorTransformed; //We like to work on the PCA Space for classification
            IMatrix SigmaInv = this.SW.Inverse;
            int ID = -1;
            double maxValue = 0.0;
            int i = 0;
            foreach(KeyValuePair<int, FaceClass> entry in FacesByClass)
            {
                double[] ui = entry.Value.MeanOfClass;
                double pi = entry.Value.ProbabilityOfBelonging;
                double discriminant = Math.Abs(CalculateDiscriminantValue(x, ui, pi, SigmaInv));
                Console.WriteLine("Discriminant for Class (" + entry.Value.ID + ")" + " = " + discriminant);
                if (i == 0) maxValue = discriminant;
                i++;
                if (discriminant < maxValue)
                {
                    ID = entry.Value.ID;
                    maxValue = discriminant;
                }
            }
            return ID;
        }

        /// <summary>
        /// Computes the equation x^T*Sigma*x
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="Sigma"></param>
        /// <returns></returns>
        private double CalculateCorrelation(double[] vectorT, IMatrix Sigma, double[] vector)
        {
            if (!Sigma.IsSquare || vector.Length != Sigma.Rows) throw new ArgumentException("Sigma should be a square matrix and vector of same length");
            double[] horizontalVector = new double[vector.Length];
            double res = 0.0; //This is our output
            for (int j = 0; j < Sigma.Columns; j++)
            {
                double temp = 0.0;
                for (int i = 0; i < Sigma.Rows; i++)
                {
                    temp += vectorT[i] * Sigma[i, j];
                }
                horizontalVector[j] = temp;
            }
            for (int i = 0; i < horizontalVector.Length; i++)
            {
                res += horizontalVector[i] * vector[i];
            }
            return res;
        }

        /// <summary>
        /// Calculate a discriminant function value for a class i
        /// </summary>
        /// <param name="xi"> unknown datum</param>
        /// <param name="ui"> mean of the class</param>
        /// <param name="pi"> probability of a datum to belong to this i-th class</param>
        /// <param name="SigmaInv"> Inverse of a covariance matrix</param>
        /// <returns></returns>
        private double CalculateDiscriminantValue(double[] xi, double[] ui, double pi, IMatrix SigmaInv)
        {
            double res = Math.Log(pi) - 0.5 * CalculateCorrelation(ui, SigmaInv, ui) + CalculateCorrelation(xi, SigmaInv, ui);
            return res;
        }


        /// <summary>
        /// Allows capabilities of comparing vectors in the projected space and give an ID to the unknown data.
        /// </summary>
        /// <param name="Face"> Face to be categorized</param>
        /// <param name="Decision"> Decision type. Either KNN or ClossestNeighbor</param>
        /// <param name="neighborNumber">How many neighbors to consider if using KNN</param>
        /// <returns></returns>
        public int PredictClassInProjectedSpace(ATTFace Face, DecisionType Decision = DecisionType.ClossestNeighbor, int neighborNumber = 3)
        {
            double[] projected = ComputeLDAProjection(Face);
            int ID = -1;
            foreach(ATTFace ReferenceFace in FaceList)
            {
                double[] y = ReferenceFace.LDAProjection;
                double dist = EuclideanDistance(y, projected);
                ReferenceFace.Closeness = dist;
            }
            FaceList.Sort();
            if (Decision == DecisionType.ClossestNeighbor)
            {
                ID = FaceList[0].personID;
            }
            else if (Decision == DecisionType.KNN)
            {
                IDictionary<int, int> Tally = new Dictionary<int, int>();
                int maxVotes = 0;
                ID = -1;
                for (int i = 0; i < neighborNumber; i++)
                {
                    ATTFace Person = FaceList[i];
                    if (Tally.ContainsKey(Person.personID))
                    {
                        Tally[Person.personID]++;
                        if (Tally[Person.personID] > maxVotes)
                        {
                            //To be here, a personID needs at leats two votes
                            maxVotes = Tally[Person.personID];
                            ID = Person.personID;
                        }
                    }
                    else
                    {
                        Tally.Add(Person.personID, 1);
                    }
                }

            }
            return ID;
        }


        //----------------------- For Accuracy ---------------------//
        public double ComputeAccuracy(List<ATTFace> FacesForTesting)
        {
            Console.WriteLine("ACCURACY TESTING ------------- ");
            int good = 0;
            foreach(ATTFace Face in FacesForTesting)
            {
                int expectedID = Face.personID;
                //int actualID = PredictClass(Face);
                int actualID = PredictClassInProjectedSpace(Face);
                Console.WriteLine("Expected = " + expectedID + " | Actual = " + actualID);
                if (expectedID == actualID) good++;
            }
            return (1.0 * good)/ FacesForTesting.Count;
        }

        //-------------------------------------- Helper functions ----------------------------------------//
        /// <summary>
        /// Returns the covariance x*x^T in the Holder IMatrix
        /// </summary>
        /// <param name="x"></param>
        /// <param name="Holder"></param>
        private IMatrix Covariance(double[] x)
        {
            IMatrix Holder = new Matrix(x.Length, x.Length);
            for (int i = 0; i < Holder.Rows; i++)
            {
                for (int j = 0; j < Holder.Columns; j++)
                {
                    Holder[i, j] = x[i] * x[j];
                }
            }
            return Holder;
        }

        /// <summary>
        /// Returns the substraction of two arrays. Left - Right
        /// </summary>
        /// <param name="left">Left array</param>
        /// <param name="right">Right array</param>
        /// <returns></returns>
        private double[] SubstractArrays(double[] left, double[] right)
        {
            if (left.Length != right.Length) throw new ArgumentException("Arrays must be of the same size");
            double[] res = new double[left.Length];
            for (int i = 0; i < left.Length; i++)
            {
                res[i] = left[i] - right[i];
            }
            return res;
        }

        /// <summary>
        /// Calculates mean of a list of ATTFaces by averaging their ImageVector
        /// </summary>
        /// <param name="Faces"> List of ATTFaces</param>
        /// <returns>array representing the mean. Same length as ImageVector</returns>
        private double[] CalculateMean(List<ATTFace> Faces)
        {
            if (Faces.Count == 0) throw new ArgumentException("Cannot calculate mean of an emmpty list!");
            double[] mean = new double[DIM];
            foreach (ATTFace Person in Faces)
            {
                double[] arr = Person.ImageVectorTransformed;
                for (int i = 0; i < arr.Length; i++)
                {
                    mean[i] += arr[i] / Faces.Count;
                }
            }
            return mean;
        }

        /// <summary>
        /// Normalizes a columns vectors of a column-vector composed Matrix.
        /// </summary>
        /// <param name="M"> Matrix</param>
        /// <returns></returns>
        public IMatrix NormalizeByColumn(IMatrix M)
        {
            IMatrix R = new Matrix(M.Rows, M.Columns);
            double[] columnSum = new double[M.Columns];
            for (int j = 0; j < M.Columns; j++)
            {
                double sum = 0.0;
                for (int i = 0; i < M.Rows; i++)
                {
                    sum += M[i, j] * M[i, j];
                }
                columnSum[j] = Math.Sqrt(sum);
            }
            for (int j = 0; j < M.Columns; j++)
            {
                for (int i = 0; i < M.Rows; i++)
                {
                    R[i, j] = M[i, j] / columnSum[j];
                }
            }
            return R;
        }

        /// <summary>
        /// Normal Euclidean distance.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        private double EuclideanDistance(double[] v1, double[] v2)
        {
            double dist = 0.0;
            for (int i = 0; i < v1.Length; i++)
            {
                dist += (v1[i] - v2[i]) * (v1[i] - v2[i]);
            }
            return dist;
        }
    }
}
