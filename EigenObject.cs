using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionLDA
{
    class EigenObject:IComparable
    {
        /// <summary>
        /// A simple class to encapsulate eigen vectors
        /// </summary>
        public double Magnitude { set; get; }
        
        public double[] Eigenvector { set; get; }

        public double Eigenvalue { set; get; }

        public int CompareTo(Object obj)
        {
            if (obj == null) return 1;
            EigenObject Other = obj as EigenObject;
            if(Other != null)
            {
                return CompareTo(Other);
            }
            else
            {
                throw new ArgumentException("Object is not an EigenFace");
            }
        }

        public int CompareTo(EigenObject Other)
        {
            if(Eigenvalue < Other.Eigenvalue)
            {
                return 1;
            }
            else if(this.Eigenvalue == Other.Eigenvalue)
            {
                return 0;
            }
            return -1;
        }
    }
}
