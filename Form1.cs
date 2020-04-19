using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognitionLDA
{
    public partial class Form1 : Form
    {
        private LDA LDAClassifier { set; get; }
        private PCA PCAClassifier { set; get; }


        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            String folderName = "C:\\Users\\chris\\Documents\\UNIVERSITY OF BRIDGEPORT\\2020SP Semester\\CPEG 585 - Computer Vision\\ATTFaceDataSet\\Training";
            PCAClassifier = new PCA(folderName);
            PCAClassifier.Train(50);
            LDAClassifier = new LDA(PCAClassifier.DataSet);
            int C = LDAClassifier.C; //C-classes
            Console.WriteLine("Number of classes: " + C);
            LDAClassifier.Train(C-1);
            Bitmap bmp = DataUnit.ArrayToBitmap(PCAClassifier.MeanFaceAsArray);
            ShowImage(bmp, picMeanFace);
            for (int i = 1; i < 6; i++)
            {
                double[] eigen = PCAClassifier.GetEigenFace(i - 1);
                Bitmap face = DataUnit.ArrayToBitmap(eigen);
                ShowImage(face, GetEigenBox(i));
            }
        }

        private void ShowImage(Bitmap bmp, PictureBox pictureBox)
        {
            Bitmap FittedBitmap = DisplayHandeler.ResizeBitmap(bmp, pictureBox.Width, pictureBox.Height);
            pictureBox.Image = FittedBitmap;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(PCAClassifier == null)
            {
                MessageBox.Show("Classifiers have not been trained. Please press Train first!");
            }
            else 
            {
                String folderName = "C:\\Users\\chris\\Documents\\UNIVERSITY OF BRIDGEPORT\\2020SP Semester\\CPEG 585 - Computer Vision\\ATTFaceDataSet\\Testing";
                List<ATTFace> TrainingFaces = DataUnit.GetTestingData(folderName);
                PCAClassifier.CalculateProjectedImages(TrainingFaces);
                double accuracy = LDAClassifier.ComputeAccuracy(TrainingFaces);
                MessageBox.Show("Current accuracy: " + accuracy * 100 + "%");
            }
            
        }

        private PictureBox GetEigenBox(int i)
        {
            switch (i)
            {
                case 1:
                    return picEigenFace1;
                case 2:
                    return picEigenFace2;
                case 3:
                    return picEigenFace3;
                case 4:
                    return picEigenFace4;
                case 5:
                    return picEigenFace5;
                default:
                    throw new ArgumentException("Not a valid integer for Picture boxes");
            }
        }

        private PictureBox GetBestMatchBox(int i)
        {
            switch (i)
            {
                case 1:
                    return picBestMatch1;
                case 2:
                    return picBestMatch2;
                case 3:
                    return picBestMatch3;
                case 4:
                    return picBestMatch4;
                case 5:
                    return picBestMatch5;
                case 6:
                    return picBestMatch6;
                default:
                    throw new ArgumentException("Not a valid integer for Best Match Boxes");
            }
        }

        private Label GetBestMatchLabel(int i)
        {
            switch (i)
            {
                case 1:
                    return lblScore1;
                case 2:
                    return lblScore2;
                case 3:
                    return lblScore3;
                case 4:
                    return lblScore4;
                case 5:
                    return lblScore5;
                case 6:
                    return lblScore6;
                default:
                    throw new ArgumentException("Invalid Label number!");
            }
        }

        private void DisplayBestMatches(List<ATTFace> Faces)
        {
            for(int i = 0; i < 5; i++)
            {
                Bitmap bmp = DataUnit.ArrayToBitmap(Faces[i].ImageVector);
                ShowImage(bmp, GetBestMatchBox(i + 1));
                String name = Faces[i].FileName;
                Label lbl = GetBestMatchLabel(i + 1);
                lbl.Text = name;
            }
        }

        private void btnTestImage_Click(object sender, EventArgs e)
        {
            if (LDAClassifier == null)
            {
                MessageBox.Show("Classifier not trained. Please press Train!");
            }
            else
            {
                OpenFileDialog Dialog = new OpenFileDialog();
                Dialog.Filter = "jpeg files (*.jpg)|*.jpg|(*.gif)|gif||";
                if (DialogResult.OK == Dialog.ShowDialog())
                {
                    ATTFace face = DataUnit.GetATTFace(Dialog.FileName);
                    double[] projectedPCA = PCAClassifier.ComputeProjection(face.ImageVector); // Do not forget to project in PCA Space
                    face.ImageVectorTransformed = projectedPCA;
                    Bitmap TestBitmap = face.getImagesAsBmp();
                    ShowImage(TestBitmap, picTestImage);
                    FileInfo fileInfo = new FileInfo(Dialog.FileName);
                    lblTestImage.Text = fileInfo.Name;
                    int guessID = LDAClassifier.PredictClassInProjectedSpace(face);
                    MessageBox.Show("Guessed Class: " + guessID);
                    List<ATTFace> BestFaces = LDAClassifier.FacesByClass[guessID].FacesInClass; //By default, we print the images in the class
                    DisplayBestMatches(BestFaces);
                }
            }
        }
    }
}
