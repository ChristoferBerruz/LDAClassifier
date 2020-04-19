namespace FaceRecognitionLDA
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picMeanFace = new System.Windows.Forms.PictureBox();
            this.picEigenFace1 = new System.Windows.Forms.PictureBox();
            this.picEigenFace3 = new System.Windows.Forms.PictureBox();
            this.picEigenFace4 = new System.Windows.Forms.PictureBox();
            this.picEigenFace2 = new System.Windows.Forms.PictureBox();
            this.picEigenFace5 = new System.Windows.Forms.PictureBox();
            this.picTestImage = new System.Windows.Forms.PictureBox();
            this.picMeanAdjusted = new System.Windows.Forms.PictureBox();
            this.picReconstructed = new System.Windows.Forms.PictureBox();
            this.picBestMatch1 = new System.Windows.Forms.PictureBox();
            this.picBestMatch2 = new System.Windows.Forms.PictureBox();
            this.picBestMatch3 = new System.Windows.Forms.PictureBox();
            this.picBestMatch4 = new System.Windows.Forms.PictureBox();
            this.picBestMatch5 = new System.Windows.Forms.PictureBox();
            this.btnTrain = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lblScore1 = new System.Windows.Forms.Label();
            this.lblScore2 = new System.Windows.Forms.Label();
            this.lblScore3 = new System.Windows.Forms.Label();
            this.lblScore4 = new System.Windows.Forms.Label();
            this.lblScore5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTestImage = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnTestImage = new System.Windows.Forms.Button();
            this.lblScore6 = new System.Windows.Forms.Label();
            this.picBestMatch6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMeanFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEigenFace1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEigenFace3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEigenFace4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEigenFace2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEigenFace5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTestImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMeanAdjusted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReconstructed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch6)).BeginInit();
            this.SuspendLayout();
            // 
            // picMeanFace
            // 
            this.picMeanFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMeanFace.Location = new System.Drawing.Point(32, 160);
            this.picMeanFace.Name = "picMeanFace";
            this.picMeanFace.Size = new System.Drawing.Size(107, 111);
            this.picMeanFace.TabIndex = 0;
            this.picMeanFace.TabStop = false;
            // 
            // picEigenFace1
            // 
            this.picEigenFace1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEigenFace1.Location = new System.Drawing.Point(32, 332);
            this.picEigenFace1.Name = "picEigenFace1";
            this.picEigenFace1.Size = new System.Drawing.Size(158, 200);
            this.picEigenFace1.TabIndex = 1;
            this.picEigenFace1.TabStop = false;
            // 
            // picEigenFace3
            // 
            this.picEigenFace3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEigenFace3.Location = new System.Drawing.Point(419, 332);
            this.picEigenFace3.Name = "picEigenFace3";
            this.picEigenFace3.Size = new System.Drawing.Size(158, 200);
            this.picEigenFace3.TabIndex = 2;
            this.picEigenFace3.TabStop = false;
            // 
            // picEigenFace4
            // 
            this.picEigenFace4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEigenFace4.Location = new System.Drawing.Point(611, 332);
            this.picEigenFace4.Name = "picEigenFace4";
            this.picEigenFace4.Size = new System.Drawing.Size(158, 200);
            this.picEigenFace4.TabIndex = 3;
            this.picEigenFace4.TabStop = false;
            this.picEigenFace4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // picEigenFace2
            // 
            this.picEigenFace2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEigenFace2.Location = new System.Drawing.Point(224, 332);
            this.picEigenFace2.Name = "picEigenFace2";
            this.picEigenFace2.Size = new System.Drawing.Size(158, 200);
            this.picEigenFace2.TabIndex = 4;
            this.picEigenFace2.TabStop = false;
            // 
            // picEigenFace5
            // 
            this.picEigenFace5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEigenFace5.Location = new System.Drawing.Point(810, 332);
            this.picEigenFace5.Name = "picEigenFace5";
            this.picEigenFace5.Size = new System.Drawing.Size(158, 200);
            this.picEigenFace5.TabIndex = 5;
            this.picEigenFace5.TabStop = false;
            // 
            // picTestImage
            // 
            this.picTestImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTestImage.Location = new System.Drawing.Point(224, 28);
            this.picTestImage.Name = "picTestImage";
            this.picTestImage.Size = new System.Drawing.Size(128, 140);
            this.picTestImage.TabIndex = 6;
            this.picTestImage.TabStop = false;
            // 
            // picMeanAdjusted
            // 
            this.picMeanAdjusted.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picMeanAdjusted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMeanAdjusted.Location = new System.Drawing.Point(382, 28);
            this.picMeanAdjusted.Name = "picMeanAdjusted";
            this.picMeanAdjusted.Size = new System.Drawing.Size(128, 140);
            this.picMeanAdjusted.TabIndex = 7;
            this.picMeanAdjusted.TabStop = false;
            // 
            // picReconstructed
            // 
            this.picReconstructed.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picReconstructed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picReconstructed.Location = new System.Drawing.Point(542, 28);
            this.picReconstructed.Name = "picReconstructed";
            this.picReconstructed.Size = new System.Drawing.Size(128, 140);
            this.picReconstructed.TabIndex = 8;
            this.picReconstructed.TabStop = false;
            // 
            // picBestMatch1
            // 
            this.picBestMatch1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBestMatch1.Location = new System.Drawing.Point(735, 28);
            this.picBestMatch1.Name = "picBestMatch1";
            this.picBestMatch1.Size = new System.Drawing.Size(82, 90);
            this.picBestMatch1.TabIndex = 9;
            this.picBestMatch1.TabStop = false;
            // 
            // picBestMatch2
            // 
            this.picBestMatch2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBestMatch2.Location = new System.Drawing.Point(832, 28);
            this.picBestMatch2.Name = "picBestMatch2";
            this.picBestMatch2.Size = new System.Drawing.Size(82, 90);
            this.picBestMatch2.TabIndex = 10;
            this.picBestMatch2.TabStop = false;
            // 
            // picBestMatch3
            // 
            this.picBestMatch3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBestMatch3.Location = new System.Drawing.Point(930, 28);
            this.picBestMatch3.Name = "picBestMatch3";
            this.picBestMatch3.Size = new System.Drawing.Size(82, 90);
            this.picBestMatch3.TabIndex = 11;
            this.picBestMatch3.TabStop = false;
            // 
            // picBestMatch4
            // 
            this.picBestMatch4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBestMatch4.Location = new System.Drawing.Point(735, 171);
            this.picBestMatch4.Name = "picBestMatch4";
            this.picBestMatch4.Size = new System.Drawing.Size(82, 90);
            this.picBestMatch4.TabIndex = 12;
            this.picBestMatch4.TabStop = false;
            // 
            // picBestMatch5
            // 
            this.picBestMatch5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBestMatch5.Location = new System.Drawing.Point(832, 171);
            this.picBestMatch5.Name = "picBestMatch5";
            this.picBestMatch5.Size = new System.Drawing.Size(82, 90);
            this.picBestMatch5.TabIndex = 13;
            this.picBestMatch5.TabStop = false;
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(32, 28);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(158, 31);
            this.btnTrain.TabIndex = 15;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(32, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 34);
            this.button3.TabIndex = 17;
            this.button3.Text = "Test Accuracy";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblScore1
            // 
            this.lblScore1.AutoSize = true;
            this.lblScore1.Location = new System.Drawing.Point(732, 121);
            this.lblScore1.Name = "lblScore1";
            this.lblScore1.Size = new System.Drawing.Size(46, 17);
            this.lblScore1.TabIndex = 18;
            this.lblScore1.Text = "label1";
            // 
            // lblScore2
            // 
            this.lblScore2.AutoSize = true;
            this.lblScore2.Location = new System.Drawing.Point(838, 121);
            this.lblScore2.Name = "lblScore2";
            this.lblScore2.Size = new System.Drawing.Size(46, 17);
            this.lblScore2.TabIndex = 19;
            this.lblScore2.Text = "label2";
            // 
            // lblScore3
            // 
            this.lblScore3.AutoSize = true;
            this.lblScore3.Location = new System.Drawing.Point(939, 121);
            this.lblScore3.Name = "lblScore3";
            this.lblScore3.Size = new System.Drawing.Size(46, 17);
            this.lblScore3.TabIndex = 20;
            this.lblScore3.Text = "label3";
            // 
            // lblScore4
            // 
            this.lblScore4.AutoSize = true;
            this.lblScore4.Location = new System.Drawing.Point(732, 264);
            this.lblScore4.Name = "lblScore4";
            this.lblScore4.Size = new System.Drawing.Size(46, 17);
            this.lblScore4.TabIndex = 21;
            this.lblScore4.Text = "label4";
            // 
            // lblScore5
            // 
            this.lblScore5.AutoSize = true;
            this.lblScore5.Location = new System.Drawing.Point(838, 264);
            this.lblScore5.Name = "lblScore5";
            this.lblScore5.Size = new System.Drawing.Size(46, 17);
            this.lblScore5.TabIndex = 22;
            this.lblScore5.Text = "label5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 535);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "EigenFace1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(838, 535);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "EigenFace5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(648, 535);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "EigenFace4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 535);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "EigenFace3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 535);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "EigenFace2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Mean Face";
            // 
            // lblTestImage
            // 
            this.lblTestImage.AutoSize = true;
            this.lblTestImage.Location = new System.Drawing.Point(247, 171);
            this.lblTestImage.Name = "lblTestImage";
            this.lblTestImage.Size = new System.Drawing.Size(78, 17);
            this.lblTestImage.TabIndex = 30;
            this.lblTestImage.Text = "Test Image";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(394, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 17);
            this.label8.TabIndex = 31;
            this.label8.Text = "Mean Adjusted";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(557, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "Reconstructed";
            // 
            // btnTestImage
            // 
            this.btnTestImage.Location = new System.Drawing.Point(32, 65);
            this.btnTestImage.Name = "btnTestImage";
            this.btnTestImage.Size = new System.Drawing.Size(158, 30);
            this.btnTestImage.TabIndex = 16;
            this.btnTestImage.Text = "Test Image";
            this.btnTestImage.UseVisualStyleBackColor = true;
            this.btnTestImage.Click += new System.EventHandler(this.btnTestImage_Click);
            // 
            // lblScore6
            // 
            this.lblScore6.AutoSize = true;
            this.lblScore6.Location = new System.Drawing.Point(939, 264);
            this.lblScore6.Name = "lblScore6";
            this.lblScore6.Size = new System.Drawing.Size(46, 17);
            this.lblScore6.TabIndex = 23;
            this.lblScore6.Text = "label6";
            // 
            // picBestMatch6
            // 
            this.picBestMatch6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picBestMatch6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBestMatch6.Location = new System.Drawing.Point(930, 171);
            this.picBestMatch6.Name = "picBestMatch6";
            this.picBestMatch6.Size = new System.Drawing.Size(82, 90);
            this.picBestMatch6.TabIndex = 14;
            this.picBestMatch6.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 575);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTestImage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblScore6);
            this.Controls.Add(this.lblScore5);
            this.Controls.Add(this.lblScore4);
            this.Controls.Add(this.lblScore3);
            this.Controls.Add(this.lblScore2);
            this.Controls.Add(this.lblScore1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnTestImage);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.picBestMatch6);
            this.Controls.Add(this.picBestMatch5);
            this.Controls.Add(this.picBestMatch4);
            this.Controls.Add(this.picBestMatch3);
            this.Controls.Add(this.picBestMatch2);
            this.Controls.Add(this.picBestMatch1);
            this.Controls.Add(this.picReconstructed);
            this.Controls.Add(this.picMeanAdjusted);
            this.Controls.Add(this.picTestImage);
            this.Controls.Add(this.picEigenFace5);
            this.Controls.Add(this.picEigenFace2);
            this.Controls.Add(this.picEigenFace4);
            this.Controls.Add(this.picEigenFace3);
            this.Controls.Add(this.picEigenFace1);
            this.Controls.Add(this.picMeanFace);
            this.Name = "Form1";
            this.Text = "Face Recognition by LDA";
            ((System.ComponentModel.ISupportInitialize)(this.picMeanFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEigenFace1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEigenFace3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEigenFace4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEigenFace2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEigenFace5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTestImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMeanAdjusted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReconstructed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picMeanFace;
        private System.Windows.Forms.PictureBox picEigenFace1;
        private System.Windows.Forms.PictureBox picEigenFace3;
        private System.Windows.Forms.PictureBox picEigenFace4;
        private System.Windows.Forms.PictureBox picEigenFace2;
        private System.Windows.Forms.PictureBox picEigenFace5;
        private System.Windows.Forms.PictureBox picTestImage;
        private System.Windows.Forms.PictureBox picMeanAdjusted;
        private System.Windows.Forms.PictureBox picReconstructed;
        private System.Windows.Forms.PictureBox picBestMatch1;
        private System.Windows.Forms.PictureBox picBestMatch2;
        private System.Windows.Forms.PictureBox picBestMatch3;
        private System.Windows.Forms.PictureBox picBestMatch4;
        private System.Windows.Forms.PictureBox picBestMatch5;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblScore1;
        private System.Windows.Forms.Label lblScore2;
        private System.Windows.Forms.Label lblScore3;
        private System.Windows.Forms.Label lblScore4;
        private System.Windows.Forms.Label lblScore5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTestImage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnTestImage;
        private System.Windows.Forms.Label lblScore6;
        private System.Windows.Forms.PictureBox picBestMatch6;
    }
}

