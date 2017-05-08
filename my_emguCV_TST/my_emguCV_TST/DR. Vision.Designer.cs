namespace my_emguCV_TST
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSetCom = new System.Windows.Forms.Button();
            this.AvPort = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtErr_nums = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbErrorStop = new System.Windows.Forms.ComboBox();
            this.Br_Gresaka = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnStop2 = new System.Windows.Forms.Button();
            this.maxLeft = new System.Windows.Forms.Button();
            this.maxRight = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.CannyImageBox = new Emgu.CV.UI.ImageBox();
            this.SmoothedGrayscaleImageBox = new Emgu.CV.UI.ImageBox();
            this.GrayscaleImageBox = new Emgu.CV.UI.ImageBox();
            this.CaptureImageBox = new Emgu.CV.UI.ImageBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CannyImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothedGrayscaleImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptureImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(453, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Camera ON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Green;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(658, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 25);
            this.button4.TabIndex = 7;
            this.button4.Text = "Start";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnSetCom
            // 
            this.btnSetCom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetCom.Location = new System.Drawing.Point(355, 26);
            this.btnSetCom.Name = "btnSetCom";
            this.btnSetCom.Size = new System.Drawing.Size(80, 25);
            this.btnSetCom.TabIndex = 11;
            this.btnSetCom.Text = "Set";
            this.btnSetCom.UseVisualStyleBackColor = true;
            this.btnSetCom.Click += new System.EventHandler(this.btnSetCom_Click);
            // 
            // AvPort
            // 
            this.AvPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AvPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AvPort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AvPort.FormattingEnabled = true;
            this.AvPort.ItemHeight = 13;
            this.AvPort.Location = new System.Drawing.Point(248, 29);
            this.AvPort.Name = "AvPort";
            this.AvPort.Size = new System.Drawing.Size(80, 21);
            this.AvPort.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(200, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Port:";
            // 
            // txtErr_nums
            // 
            this.txtErr_nums.Location = new System.Drawing.Point(114, 33);
            this.txtErr_nums.Name = "txtErr_nums";
            this.txtErr_nums.Size = new System.Drawing.Size(69, 20);
            this.txtErr_nums.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(8, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Broj grešaka:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(8, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Režim rada:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbErrorStop
            // 
            this.cmbErrorStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbErrorStop.FormattingEnabled = true;
            this.cmbErrorStop.Items.AddRange(new object[] {
            "AUTO",
            "MAN"});
            this.cmbErrorStop.Location = new System.Drawing.Point(114, 8);
            this.cmbErrorStop.Name = "cmbErrorStop";
            this.cmbErrorStop.Size = new System.Drawing.Size(69, 21);
            this.cmbErrorStop.TabIndex = 19;
            // 
            // Br_Gresaka
            // 
            this.Br_Gresaka.AutoSize = true;
            this.Br_Gresaka.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Br_Gresaka.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Br_Gresaka.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Br_Gresaka.Location = new System.Drawing.Point(875, 24);
            this.Br_Gresaka.Name = "Br_Gresaka";
            this.Br_Gresaka.Size = new System.Drawing.Size(114, 24);
            this.Br_Gresaka.TabIndex = 20;
            this.Br_Gresaka.Text = "Broj grešaka";
            this.Br_Gresaka.MouseHover += new System.EventHandler(this.Br_Gresaka_MouseHover);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Maroon;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(744, 26);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 25);
            this.btnStop.TabIndex = 21;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(1304, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(524, 27);
            this.label1.TabIndex = 23;
            this.label1.Text = "UPUTSTVO ZA UPOTREBU DR. VISION UREĐAJA";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox1.Location = new System.Drawing.Point(1309, 143);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(513, 217);
            this.richTextBox1.TabIndex = 22;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(1304, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 27);
            this.label2.TabIndex = 24;
            this.label2.Text = "POČETNA PODEŠAVANJA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(1357, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 27);
            this.label3.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label4.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(1304, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 27);
            this.label4.TabIndex = 27;
            this.label4.Text = "RUKOVANJE UREĐAJOM";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.richTextBox2.Enabled = false;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox2.Location = new System.Drawing.Point(1309, 406);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(513, 610);
            this.richTextBox2.TabIndex = 26;
            this.richTextBox2.Text = resources.GetString("richTextBox2.Text");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label8.Location = new System.Drawing.Point(1500, 1035);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Created by: Dejan Ristić,";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label9.Location = new System.Drawing.Point(1630, 1035);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Nemanja isajlović";
            // 
            // btnStop2
            // 
            this.btnStop2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnStop2.BackgroundImage = global::my_emguCV_TST.Properties.Resources.pause;
            this.btnStop2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStop2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop2.FlatAppearance.BorderSize = 0;
            this.btnStop2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop2.Location = new System.Drawing.Point(1172, 26);
            this.btnStop2.Name = "btnStop2";
            this.btnStop2.Size = new System.Drawing.Size(33, 25);
            this.btnStop2.TabIndex = 34;
            this.btnStop2.UseVisualStyleBackColor = false;
            this.btnStop2.Click += new System.EventHandler(this.btnStop2_Click);
            // 
            // maxLeft
            // 
            this.maxLeft.BackColor = System.Drawing.Color.LightSteelBlue;
            this.maxLeft.BackgroundImage = global::my_emguCV_TST.Properties.Resources.fast_forward_double_right_arrows;
            this.maxLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.maxLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maxLeft.FlatAppearance.BorderSize = 0;
            this.maxLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maxLeft.Location = new System.Drawing.Point(1250, 26);
            this.maxLeft.Name = "maxLeft";
            this.maxLeft.Size = new System.Drawing.Size(33, 25);
            this.maxLeft.TabIndex = 33;
            this.maxLeft.UseVisualStyleBackColor = false;
            this.maxLeft.Click += new System.EventHandler(this.maxLeft_Click);
            // 
            // maxRight
            // 
            this.maxRight.BackColor = System.Drawing.Color.LightSteelBlue;
            this.maxRight.BackgroundImage = global::my_emguCV_TST.Properties.Resources.rewind_double_arrows_angles;
            this.maxRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.maxRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maxRight.FlatAppearance.BorderSize = 0;
            this.maxRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maxRight.Location = new System.Drawing.Point(1094, 26);
            this.maxRight.Name = "maxRight";
            this.maxRight.Size = new System.Drawing.Size(33, 25);
            this.maxRight.TabIndex = 32;
            this.maxRight.UseVisualStyleBackColor = false;
            this.maxRight.Click += new System.EventHandler(this.maxRight_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pictureBox1.Location = new System.Drawing.Point(1297, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(626, 1063);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button3.BackgroundImage = global::my_emguCV_TST.Properties.Resources.left_arrow_angle;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(1133, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(33, 25);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CannyImageBox
            // 
            this.CannyImageBox.Location = new System.Drawing.Point(658, 568);
            this.CannyImageBox.Name = "CannyImageBox";
            this.CannyImageBox.Size = new System.Drawing.Size(640, 480);
            this.CannyImageBox.TabIndex = 2;
            this.CannyImageBox.TabStop = false;
            // 
            // SmoothedGrayscaleImageBox
            // 
            this.SmoothedGrayscaleImageBox.Location = new System.Drawing.Point(12, 568);
            this.SmoothedGrayscaleImageBox.Name = "SmoothedGrayscaleImageBox";
            this.SmoothedGrayscaleImageBox.Size = new System.Drawing.Size(640, 480);
            this.SmoothedGrayscaleImageBox.TabIndex = 2;
            this.SmoothedGrayscaleImageBox.TabStop = false;
            // 
            // GrayscaleImageBox
            // 
            this.GrayscaleImageBox.Location = new System.Drawing.Point(658, 59);
            this.GrayscaleImageBox.Name = "GrayscaleImageBox";
            this.GrayscaleImageBox.Size = new System.Drawing.Size(640, 480);
            this.GrayscaleImageBox.TabIndex = 2;
            this.GrayscaleImageBox.TabStop = false;
            // 
            // CaptureImageBox
            // 
            this.CaptureImageBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.CaptureImageBox.Location = new System.Drawing.Point(12, 59);
            this.CaptureImageBox.Name = "CaptureImageBox";
            this.CaptureImageBox.Size = new System.Drawing.Size(640, 480);
            this.CaptureImageBox.TabIndex = 2;
            this.CaptureImageBox.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.BackgroundImage = global::my_emguCV_TST.Properties.Resources.right_arrow_angle;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(1211, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 25);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pictureBox2.Location = new System.Drawing.Point(-26, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1324, 59);
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label10.Location = new System.Drawing.Point(1781, 1035);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "V 1.0.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(1904, 1061);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnStop2);
            this.Controls.Add(this.maxLeft);
            this.Controls.Add(this.maxRight);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.Br_Gresaka);
            this.Controls.Add(this.cmbErrorStop);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtErr_nums);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AvPort);
            this.Controls.Add(this.btnSetCom);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.CannyImageBox);
            this.Controls.Add(this.SmoothedGrayscaleImageBox);
            this.Controls.Add(this.GrayscaleImageBox);
            this.Controls.Add(this.CaptureImageBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DR. Vision";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CannyImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothedGrayscaleImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayscaleImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptureImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Emgu.CV.UI.ImageBox CaptureImageBox;
        private Emgu.CV.UI.ImageBox GrayscaleImageBox;
        private Emgu.CV.UI.ImageBox SmoothedGrayscaleImageBox;
        private Emgu.CV.UI.ImageBox CannyImageBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSetCom;
        private System.Windows.Forms.ComboBox AvPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtErr_nums;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbErrorStop;
        private System.Windows.Forms.Label Br_Gresaka;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button maxRight;
        private System.Windows.Forms.Button maxLeft;
        private System.Windows.Forms.Button btnStop2;
        private System.Windows.Forms.Label label10;
    }
}

