namespace MultiThreadedBulkImageConverter
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
            this.BtnStop = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.chkIncludeSubDirs = new System.Windows.Forms.CheckBox();
            this.gbxConversion = new System.Windows.Forms.GroupBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.chkDeleteAfterConvert = new System.Windows.Forms.CheckBox();
            this.cboOutputTypes = new System.Windows.Forms.ComboBox();
            this.cboSourceTypes = new System.Windows.Forms.ComboBox();
            this.prgStatus = new System.Windows.Forms.ProgressBar();
            this.gbxProgress = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtImageDirectory = new System.Windows.Forms.TextBox();
            this.lblImageDirectory = new System.Windows.Forms.Label();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.chkRunParallel = new System.Windows.Forms.CheckBox();
            this.cbParallelOptions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxConversion.SuspendLayout();
            this.gbxProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(311, 404);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(75, 23);
            this.BtnStop.TabIndex = 26;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(392, 404);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 25;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblStep3
            // 
            this.lblStep3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStep3.AutoSize = true;
            this.lblStep3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep3.Location = new System.Drawing.Point(12, 388);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(231, 13);
            this.lblStep3.TabIndex = 24;
            this.lblStep3.Text = "Step 3 - Click the Start button to begin.";
            // 
            // lblStep2
            // 
            this.lblStep2.AutoSize = true;
            this.lblStep2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep2.Location = new System.Drawing.Point(12, 141);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(528, 13);
            this.lblStep2.TabIndex = 23;
            this.lblStep2.Text = "Step 2 - Select the type of files you want to convert, and what you want to conve" +
    "rt them to.";
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreeting.Location = new System.Drawing.Point(12, 9);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(500, 13);
            this.lblGreeting.TabIndex = 22;
            this.lblGreeting.Text = "Converting your images with Bulk Image Converter is easy. Just follow the steps b" +
    "elow.";
            // 
            // chkIncludeSubDirs
            // 
            this.chkIncludeSubDirs.AutoSize = true;
            this.chkIncludeSubDirs.Location = new System.Drawing.Point(15, 104);
            this.chkIncludeSubDirs.Name = "chkIncludeSubDirs";
            this.chkIncludeSubDirs.Size = new System.Drawing.Size(129, 17);
            this.chkIncludeSubDirs.TabIndex = 16;
            this.chkIncludeSubDirs.Text = "Include subdirectories";
            this.chkIncludeSubDirs.UseVisualStyleBackColor = true;
            // 
            // gbxConversion
            // 
            this.gbxConversion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxConversion.Controls.Add(this.lblOutput);
            this.gbxConversion.Controls.Add(this.lblSource);
            this.gbxConversion.Controls.Add(this.chkDeleteAfterConvert);
            this.gbxConversion.Controls.Add(this.cboOutputTypes);
            this.gbxConversion.Controls.Add(this.cboSourceTypes);
            this.gbxConversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxConversion.Location = new System.Drawing.Point(12, 164);
            this.gbxConversion.Name = "gbxConversion";
            this.gbxConversion.Size = new System.Drawing.Size(536, 75);
            this.gbxConversion.TabIndex = 18;
            this.gbxConversion.TabStop = false;
            this.gbxConversion.Text = "Conversion";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(80, 42);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(39, 13);
            this.lblOutput.TabIndex = 4;
            this.lblOutput.Text = "to type";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(6, 19);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(113, 13);
            this.lblSource.TabIndex = 3;
            this.lblSource.Text = "Convert all files of type";
            // 
            // chkDeleteAfterConvert
            // 
            this.chkDeleteAfterConvert.Location = new System.Drawing.Point(332, 20);
            this.chkDeleteAfterConvert.Name = "chkDeleteAfterConvert";
            this.chkDeleteAfterConvert.Size = new System.Drawing.Size(197, 35);
            this.chkDeleteAfterConvert.TabIndex = 1;
            this.chkDeleteAfterConvert.Text = "Delete original files after conversion (not recommended)";
            this.chkDeleteAfterConvert.UseVisualStyleBackColor = true;
            // 
            // cboOutputTypes
            // 
            this.cboOutputTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutputTypes.FormattingEnabled = true;
            this.cboOutputTypes.Location = new System.Drawing.Point(125, 43);
            this.cboOutputTypes.Name = "cboOutputTypes";
            this.cboOutputTypes.Size = new System.Drawing.Size(180, 21);
            this.cboOutputTypes.Sorted = true;
            this.cboOutputTypes.TabIndex = 2;
            // 
            // cboSourceTypes
            // 
            this.cboSourceTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSourceTypes.FormattingEnabled = true;
            this.cboSourceTypes.Location = new System.Drawing.Point(125, 16);
            this.cboSourceTypes.Name = "cboSourceTypes";
            this.cboSourceTypes.Size = new System.Drawing.Size(180, 21);
            this.cboSourceTypes.Sorted = true;
            this.cboSourceTypes.TabIndex = 0;
            // 
            // prgStatus
            // 
            this.prgStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.prgStatus.Location = new System.Drawing.Point(9, 63);
            this.prgStatus.Name = "prgStatus";
            this.prgStatus.Size = new System.Drawing.Size(520, 23);
            this.prgStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgStatus.TabIndex = 1;
            // 
            // gbxProgress
            // 
            this.gbxProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxProgress.Controls.Add(this.prgStatus);
            this.gbxProgress.Controls.Add(this.lblStatus);
            this.gbxProgress.Location = new System.Drawing.Point(12, 258);
            this.gbxProgress.Name = "gbxProgress";
            this.gbxProgress.Size = new System.Drawing.Size(536, 100);
            this.gbxProgress.TabIndex = 19;
            this.gbxProgress.TabStop = false;
            this.gbxProgress.Text = "Progress";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BackColor = System.Drawing.Color.Black;
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(6, 29);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(523, 18);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Inactive";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(473, 404);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // txtImageDirectory
            // 
            this.txtImageDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImageDirectory.Location = new System.Drawing.Point(12, 76);
            this.txtImageDirectory.Name = "txtImageDirectory";
            this.txtImageDirectory.Size = new System.Drawing.Size(499, 20);
            this.txtImageDirectory.TabIndex = 14;
            this.txtImageDirectory.Text = "F:\\Testing";
            // 
            // lblImageDirectory
            // 
            this.lblImageDirectory.AutoSize = true;
            this.lblImageDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageDirectory.Location = new System.Drawing.Point(12, 44);
            this.lblImageDirectory.Name = "lblImageDirectory";
            this.lblImageDirectory.Size = new System.Drawing.Size(463, 26);
            this.lblImageDirectory.TabIndex = 17;
            this.lblImageDirectory.Text = "Step 1 - Select the directory which contains the image files you want to convert." +
    "\r\n(Type the full directory path below, or click the button to the right to brows" +
    "e.)";
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBrowse.Location = new System.Drawing.Point(519, 74);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(29, 23);
            this.BtnBrowse.TabIndex = 15;
            this.BtnBrowse.Text = "...";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(230, 404);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 20;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_ClickAsync);
            // 
            // chkRunParallel
            // 
            this.chkRunParallel.AutoSize = true;
            this.chkRunParallel.Enabled = false;
            this.chkRunParallel.Location = new System.Drawing.Point(378, 104);
            this.chkRunParallel.Name = "chkRunParallel";
            this.chkRunParallel.Size = new System.Drawing.Size(89, 17);
            this.chkRunParallel.TabIndex = 27;
            this.chkRunParallel.Text = "run in Parallel";
            this.chkRunParallel.UseVisualStyleBackColor = true;
            // 
            // cbParallelOptions
            // 
            this.cbParallelOptions.FormattingEnabled = true;
            this.cbParallelOptions.Items.AddRange(new object[] {
            "100%",
            "75%",
            "50%",
            "25%",
            "0%"});
            this.cbParallelOptions.Location = new System.Drawing.Point(239, 102);
            this.cbParallelOptions.Name = "cbParallelOptions";
            this.cbParallelOptions.Size = new System.Drawing.Size(121, 21);
            this.cbParallelOptions.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Parallel Amount:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 437);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbParallelOptions);
            this.Controls.Add(this.chkRunParallel);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.lblStep3);
            this.Controls.Add(this.lblStep2);
            this.Controls.Add(this.lblGreeting);
            this.Controls.Add(this.chkIncludeSubDirs);
            this.Controls.Add(this.gbxConversion);
            this.Controls.Add(this.gbxProgress);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtImageDirectory);
            this.Controls.Add(this.lblImageDirectory);
            this.Controls.Add(this.BtnBrowse);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbxConversion.ResumeLayout(false);
            this.gbxConversion.PerformLayout();
            this.gbxProgress.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.CheckBox chkIncludeSubDirs;
        private System.Windows.Forms.GroupBox gbxConversion;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.CheckBox chkDeleteAfterConvert;
        private System.Windows.Forms.ComboBox cboOutputTypes;
        private System.Windows.Forms.ComboBox cboSourceTypes;
        private System.Windows.Forms.ProgressBar prgStatus;
        private System.Windows.Forms.GroupBox gbxProgress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtImageDirectory;
        private System.Windows.Forms.Label lblImageDirectory;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkRunParallel;
        private System.Windows.Forms.ComboBox cbParallelOptions;
        private System.Windows.Forms.Label label1;
    }
}

