namespace CodeSharper.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fbrLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblIssuesFound = new System.Windows.Forms.Label();
            this.lblFilesWithIssues = new System.Windows.Forms.Label();
            this.lblExcludedFiles = new System.Windows.Forms.Label();
            this.lblTotalFiles = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpCSharp = new System.Windows.Forms.GroupBox();
            this.btnAbout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lvwReport = new CodeSharper.UI.CustomControls.NfListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpenInVisualStudio = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.sdlgExport = new System.Windows.Forms.SaveFileDialog();
            this.pnlDetails.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mnuResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDetails.Controls.Add(this.groupBox2);
            this.pnlDetails.Controls.Add(this.gpCSharp);
            this.pnlDetails.Controls.Add(this.btnAbout);
            this.pnlDetails.Controls.Add(this.pictureBox1);
            this.pnlDetails.Controls.Add(this.btnExport);
            this.pnlDetails.Controls.Add(this.pgbProgress);
            this.pnlDetails.Controls.Add(this.lblCurrentStatus);
            this.pnlDetails.Controls.Add(this.label2);
            this.pnlDetails.Controls.Add(this.btnSelect);
            this.pnlDetails.Controls.Add(this.btnList);
            this.pnlDetails.Controls.Add(this.cboType);
            this.pnlDetails.Controls.Add(this.lblType);
            this.pnlDetails.Controls.Add(this.txtLocation);
            this.pnlDetails.Controls.Add(this.lblLocation);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(1260, 278);
            this.pnlDetails.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblIssuesFound);
            this.groupBox2.Controls.Add(this.lblFilesWithIssues);
            this.groupBox2.Controls.Add(this.lblExcludedFiles);
            this.groupBox2.Controls.Add(this.lblTotalFiles);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(1023, 68);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(219, 146);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // lblIssuesFound
            // 
            this.lblIssuesFound.AutoSize = true;
            this.lblIssuesFound.Location = new System.Drawing.Point(131, 113);
            this.lblIssuesFound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIssuesFound.Name = "lblIssuesFound";
            this.lblIssuesFound.Size = new System.Drawing.Size(16, 17);
            this.lblIssuesFound.TabIndex = 7;
            this.lblIssuesFound.Text = "0";
            this.lblIssuesFound.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFilesWithIssues
            // 
            this.lblFilesWithIssues.AutoSize = true;
            this.lblFilesWithIssues.Location = new System.Drawing.Point(131, 84);
            this.lblFilesWithIssues.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilesWithIssues.Name = "lblFilesWithIssues";
            this.lblFilesWithIssues.Size = new System.Drawing.Size(16, 17);
            this.lblFilesWithIssues.TabIndex = 6;
            this.lblFilesWithIssues.Text = "0";
            this.lblFilesWithIssues.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblExcludedFiles
            // 
            this.lblExcludedFiles.AutoSize = true;
            this.lblExcludedFiles.Location = new System.Drawing.Point(131, 54);
            this.lblExcludedFiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExcludedFiles.Name = "lblExcludedFiles";
            this.lblExcludedFiles.Size = new System.Drawing.Size(16, 17);
            this.lblExcludedFiles.TabIndex = 5;
            this.lblExcludedFiles.Text = "0";
            this.lblExcludedFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.AutoSize = true;
            this.lblTotalFiles.Location = new System.Drawing.Point(131, 30);
            this.lblTotalFiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(16, 17);
            this.lblTotalFiles.TabIndex = 4;
            this.lblTotalFiles.Text = "0";
            this.lblTotalFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Issues found:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Files with issues:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Excluded files:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total files:";
            // 
            // gpCSharp
            // 
            this.gpCSharp.Location = new System.Drawing.Point(8, 68);
            this.gpCSharp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpCSharp.Name = "gpCSharp";
            this.gpCSharp.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpCSharp.Size = new System.Drawing.Size(1007, 146);
            this.gpCSharp.TabIndex = 5;
            this.gpCSharp.TabStop = false;
            this.gpCSharp.Text = "Options";
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(1141, 238);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(100, 28);
            this.btnAbout.TabIndex = 16;
            this.btnAbout.Text = "&About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.BtnAboutClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            //this.pictureBox1.Image = global::CodeSharper.UI.Properties.Resources.cptlogo;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(957, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 62);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1033, 238);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 28);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "&Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExportClick);
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(116, 249);
            this.pgbProgress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(799, 17);
            this.pgbProgress.TabIndex = 12;
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Location = new System.Drawing.Point(9, 209);
            this.lblCurrentStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lblCurrentStatus.Size = new System.Drawing.Size(99, 29);
            this.lblCurrentStatus.TabIndex = 16;
            this.lblCurrentStatus.Text = "Analysing file: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 238);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.label2.Size = new System.Drawing.Size(105, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Total Progress:";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(783, 32);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(32, 25);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.BtnSelectClick);
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(923, 238);
            this.btnList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(100, 28);
            this.btnList.TabIndex = 14;
            this.btnList.Text = "&List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.BtnListClick);
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(827, 32);
            this.cboType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(121, 24);
            this.cboType.TabIndex = 4;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.CboTypeSelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(823, 12);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(40, 17);
            this.lblType.TabIndex = 10;
            this.lblType.Text = "Type";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(8, 32);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(765, 22);
            this.txtLocation.TabIndex = 2;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(4, 12);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(62, 17);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "Location";
            // 
            // lvwReport
            // 
            this.lvwReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvwReport.ContextMenuStrip = this.mnuResults;
            this.lvwReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvwReport.FullRowSelect = true;
            this.lvwReport.GridLines = true;
            this.lvwReport.Location = new System.Drawing.Point(0, 269);
            this.lvwReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvwReport.Name = "lvwReport";
            this.lvwReport.Size = new System.Drawing.Size(1260, 644);
            this.lvwReport.TabIndex = 17;
            this.lvwReport.UseCompatibleStateImageBehavior = false;
            this.lvwReport.View = System.Windows.Forms.View.Details;
            this.lvwReport.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvwReportColumnClick);
            this.lvwReport.SelectedIndexChanged += new System.EventHandler(this.LvwReportSelectedIndexChanged);
            this.lvwReport.DoubleClick += new System.EventHandler(this.LvwReportDoubleClick);
            this.lvwReport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LvwReportKeyPress);
            this.lvwReport.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LvwReportKeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sl#";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File Name";
            this.columnHeader2.Width = 241;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Line#";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Category";
            this.columnHeader4.Width = 156;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Contents";
            this.columnHeader5.Width = 330;
            // 
            // mnuResults
            // 
            this.mnuResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenInVisualStudio,
            this.mnuShowDetails});
            this.mnuResults.Name = "mnuResults";
            this.mnuResults.Size = new System.Drawing.Size(224, 52);
            // 
            // mnuOpenInVisualStudio
            // 
            this.mnuOpenInVisualStudio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mnuOpenInVisualStudio.Name = "mnuOpenInVisualStudio";
            this.mnuOpenInVisualStudio.Size = new System.Drawing.Size(223, 24);
            this.mnuOpenInVisualStudio.Text = "&Open in Visual Studio";
            this.mnuOpenInVisualStudio.Click += new System.EventHandler(this.MnuOpenInVisualStudioClick);
            // 
            // mnuShowDetails
            // 
            this.mnuShowDetails.Name = "mnuShowDetails";
            this.mnuShowDetails.Size = new System.Drawing.Size(223, 24);
            this.mnuShowDetails.Text = "&Show Details";
            this.mnuShowDetails.Click += new System.EventHandler(this.MnuShowDetailsClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 913);
            this.Controls.Add(this.lvwReport);
            this.Controls.Add(this.pnlDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Code Frisker";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.Resize += new System.EventHandler(this.MainFormResize);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mnuResults.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbrLocation;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label label2;
        private CodeSharper.UI.CustomControls.NfListView lvwReport;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog sdlgExport;
        private System.Windows.Forms.ContextMenuStrip mnuResults;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenInVisualStudio;
        private System.Windows.Forms.ToolStripMenuItem mnuShowDetails;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblIssuesFound;
        private System.Windows.Forms.Label lblFilesWithIssues;
        private System.Windows.Forms.Label lblExcludedFiles;
        private System.Windows.Forms.Label lblTotalFiles;
        private System.Windows.Forms.GroupBox gpCSharp;
    }
}

