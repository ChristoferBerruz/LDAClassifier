using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionLDA
{
    enum DecisionType
    {
        ClossestNeighbor = 0,
        KNN = 1
    }

    enum ClossenessMeasure
    {
        Euclidean = 0,
        Projection = 1
    }
}
