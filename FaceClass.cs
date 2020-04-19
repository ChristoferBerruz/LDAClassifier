using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionLDA
{
    class FaceClass
    {
        /// <summary>
        /// A class to encapsulate faces belonging to the same class
        /// </summary>
        public int ID { set; get; }
        public int NumberOfElements { set { } get { return FacesInClass.Count; } }

        public double ProbabilityOfBelonging { set { } get { return (1.0*NumberOfElements)/ TotalN; } }

        public List<ATTFace> FacesInClass { set; get; }

        public double[] MeanOfClass { set; get; }

        public double ClassificationScore { set; get; }

        public int TotalN { set; get; }

        public FaceClass()
        {
            this.FacesInClass = new List<ATTFace>();
        }

        public override string ToString()
        {
            string header =  "-----------------------\nClass ID: " + this.ID + " \nNumber Of Faces:" + this.NumberOfElements + "\n";
            foreach(ATTFace Face in this.FacesInClass)
            {
                header += Face.ToString() + " ";
            }
            return header;
        }
    }
}
