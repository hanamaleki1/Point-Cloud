namespace Point_Cloud_Downsampling
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
            this.BrowseForInput = new System.Windows.Forms.Button();
            this.inputFile = new System.Windows.Forms.TextBox();
            this.outputFolder = new System.Windows.Forms.TextBox();
            this.BrowseForOutputFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.downsamplingValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RemoveColorInfo = new System.Windows.Forms.CheckBox();
            this.Run = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BrowseForInput
            // 
            this.BrowseForInput.Location = new System.Drawing.Point(645, 56);
            this.BrowseForInput.Name = "BrowseForInput";
            this.BrowseForInput.Size = new System.Drawing.Size(75, 23);
            this.BrowseForInput.TabIndex = 0;
            this.BrowseForInput.Text = "Browse";
            this.BrowseForInput.UseVisualStyleBackColor = true;
            this.BrowseForInput.Click += new System.EventHandler(this.BrowseForInput_Click);
            // 
            // inputFile
            // 
            this.inputFile.Location = new System.Drawing.Point(82, 57);
            this.inputFile.Name = "inputFile";
            this.inputFile.Size = new System.Drawing.Size(537, 22);
            this.inputFile.TabIndex = 1;
            // 
            // outputFolder
            // 
            this.outputFolder.Location = new System.Drawing.Point(82, 113);
            this.outputFolder.Name = "outputFolder";
            this.outputFolder.Size = new System.Drawing.Size(537, 22);
            this.outputFolder.TabIndex = 3;
            // 
            // BrowseForOutputFolder
            // 
            this.BrowseForOutputFolder.Location = new System.Drawing.Point(645, 112);
            this.BrowseForOutputFolder.Name = "BrowseForOutputFolder";
            this.BrowseForOutputFolder.Size = new System.Drawing.Size(75, 23);
            this.BrowseForOutputFolder.TabIndex = 2;
            this.BrowseForOutputFolder.Text = "Browse";
            this.BrowseForOutputFolder.UseVisualStyleBackColor = true;
            this.BrowseForOutputFolder.Click += new System.EventHandler(this.BrowseForOutputFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input pts File";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Input Folder Path to save xyz File";
            // 
            // downsamplingValue
            // 
            this.downsamplingValue.Location = new System.Drawing.Point(392, 171);
            this.downsamplingValue.Name = "downsamplingValue";
            this.downsamplingValue.Size = new System.Drawing.Size(226, 22);
            this.downsamplingValue.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Input value for downsampling??? (0-1)";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // RemoveColorInfo
            // 
            this.RemoveColorInfo.AutoSize = true;
            this.RemoveColorInfo.Location = new System.Drawing.Point(81, 210);
            this.RemoveColorInfo.Name = "RemoveColorInfo";
            this.RemoveColorInfo.Size = new System.Drawing.Size(193, 21);
            this.RemoveColorInfo.TabIndex = 10;
            this.RemoveColorInfo.Text = "Remove Color Information";
            this.RemoveColorInfo.UseVisualStyleBackColor = true;
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(82, 274);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(638, 38);
            this.Run.TabIndex = 11;
            this.Run.Text = "Run Downsampling";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(389, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Number of Points Processed";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 361);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.RemoveColorInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.downsamplingValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputFolder);
            this.Controls.Add(this.BrowseForOutputFolder);
            this.Controls.Add(this.inputFile);
            this.Controls.Add(this.BrowseForInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BrowseForInput;
        private System.Windows.Forms.TextBox inputFile;
        private System.Windows.Forms.TextBox outputFolder;
        private System.Windows.Forms.Button BrowseForOutputFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox downsamplingValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox RemoveColorInfo;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Label label4;
    }
}

