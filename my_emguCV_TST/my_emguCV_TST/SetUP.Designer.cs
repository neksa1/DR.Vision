namespace my_emguCV_TST
{
    partial class SetUP
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
            this.CaptureImageBox = new Emgu.CV.UI.ImageBox();
            this.Start = new System.Windows.Forms.Button();
            this.Left = new System.Windows.Forms.Button();
            this.Right = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSetupPort = new System.Windows.Forms.ComboBox();
            this.btnSetComSetup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CaptureImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CaptureImageBox
            // 
            this.CaptureImageBox.Location = new System.Drawing.Point(12, 42);
            this.CaptureImageBox.Name = "CaptureImageBox";
            this.CaptureImageBox.Size = new System.Drawing.Size(411, 345);
            this.CaptureImageBox.TabIndex = 3;
            this.CaptureImageBox.TabStop = false;
            this.CaptureImageBox.Click += new System.EventHandler(this.CaptureImageBox_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(13, 408);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 4;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Left
            // 
            this.Left.Location = new System.Drawing.Point(94, 408);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(75, 23);
            this.Left.TabIndex = 5;
            this.Left.Text = "Left";
            this.Left.UseVisualStyleBackColor = true;
            this.Left.Click += new System.EventHandler(this.Left_Click);
            // 
            // Right
            // 
            this.Right.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Right.Location = new System.Drawing.Point(175, 408);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(75, 23);
            this.Right.TabIndex = 8;
            this.Right.Text = "Right";
            this.Right.UseVisualStyleBackColor = false;
            this.Right.Click += new System.EventHandler(this.Right_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(348, 408);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 7;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(9, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Port:";
            // 
            // cmbSetupPort
            // 
            this.cmbSetupPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSetupPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSetupPort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSetupPort.FormattingEnabled = true;
            this.cmbSetupPort.ItemHeight = 13;
            this.cmbSetupPort.Location = new System.Drawing.Point(57, 12);
            this.cmbSetupPort.Name = "cmbSetupPort";
            this.cmbSetupPort.Size = new System.Drawing.Size(80, 21);
            this.cmbSetupPort.TabIndex = 17;
            // 
            // btnSetComSetup
            // 
            this.btnSetComSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetComSetup.Location = new System.Drawing.Point(143, 11);
            this.btnSetComSetup.Name = "btnSetComSetup";
            this.btnSetComSetup.Size = new System.Drawing.Size(80, 25);
            this.btnSetComSetup.TabIndex = 16;
            this.btnSetComSetup.Text = "Set";
            this.btnSetComSetup.UseVisualStyleBackColor = true;
            this.btnSetComSetup.Click += new System.EventHandler(this.btnSetComSetup_Click);
            // 
            // SetUP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(439, 443);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSetupPort);
            this.Controls.Add(this.btnSetComSetup);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Right);
            this.Controls.Add(this.Left);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.CaptureImageBox);
            this.Name = "SetUP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetUP";
            ((System.ComponentModel.ISupportInitialize)(this.CaptureImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox CaptureImageBox;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Left;
        private System.Windows.Forms.Button Right;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSetupPort;
        private System.Windows.Forms.Button btnSetComSetup;
    }
}