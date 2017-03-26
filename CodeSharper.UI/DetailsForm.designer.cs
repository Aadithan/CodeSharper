namespace CodeSharper.UI
{
    partial class DetailsForm
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
            this.lblFile = new System.Windows.Forms.Label();
            this.lblIssueType = new System.Windows.Forms.Label();
            this.lblCause = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblContents = new System.Windows.Forms.Label();
            this.lblFileInfo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ttpFileInfo = new System.Windows.Forms.ToolTip( this.components );
            this.SuspendLayout();
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.lblFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFile.Location = new System.Drawing.Point( 15, 27 );
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size( 31, 13 );
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "File:";
            // 
            // lblIssueType
            // 
            this.lblIssueType.AutoSize = true;
            this.lblIssueType.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.lblIssueType.Location = new System.Drawing.Point( 15, 57 );
            this.lblIssueType.Name = "lblIssueType";
            this.lblIssueType.Size = new System.Drawing.Size( 77, 13 );
            this.lblIssueType.TabIndex = 1;
            this.lblIssueType.Text = "Issue Type: ";
            // 
            // lblCause
            // 
            this.lblCause.AutoSize = true;
            this.lblCause.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.lblCause.Location = new System.Drawing.Point( 15, 150 );
            this.lblCause.Name = "lblCause";
            this.lblCause.Size = new System.Drawing.Size( 46, 13 );
            this.lblCause.TabIndex = 2;
            this.lblCause.Text = "Cause:";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point( 40, 173 );
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size( 99, 13 );
            this.lblDetails.TabIndex = 3;
            this.lblDetails.Text = "No details available";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.label1.Location = new System.Drawing.Point( 15, 90 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 61, 13 );
            this.label1.TabIndex = 4;
            this.label1.Text = "Contents:";
            // 
            // lblContents
            // 
            this.lblContents.AutoSize = true;
            this.lblContents.Font = new System.Drawing.Font( "Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.lblContents.ForeColor = System.Drawing.Color.FromArgb( ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))) );
            this.lblContents.Location = new System.Drawing.Point( 40, 112 );
            this.lblContents.Name = "lblContents";
            this.lblContents.Size = new System.Drawing.Size( 176, 16 );
            this.lblContents.TabIndex = 5;
            this.lblContents.Text = "No contents available";
            // 
            // lblFileInfo
            // 
            this.lblFileInfo.AutoSize = true;
            this.lblFileInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFileInfo.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.lblFileInfo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFileInfo.Location = new System.Drawing.Point( 51, 27 );
            this.lblFileInfo.Name = "lblFileInfo";
            this.lblFileInfo.Size = new System.Drawing.Size( 41, 13 );
            this.lblFileInfo.TabIndex = 6;
            this.lblFileInfo.Text = "label2";
            this.lblFileInfo.Click += new System.EventHandler( this.lblFileInfo_Click );
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point( 345, 226 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 94, 23 );
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close Details";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // ttpFileInfo
            // 
            this.ttpFileInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpFileInfo.ToolTipTitle = "Click to open in Visual Studio";
            // 
            // DetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size( 797, 257 );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.lblFileInfo );
            this.Controls.Add( this.lblContents );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.lblDetails );
            this.Controls.Add( this.lblCause );
            this.Controls.Add( this.lblIssueType );
            this.Controls.Add( this.lblFile );
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetailsForm";
            this.Text = "Issue Details";
            this.Load += new System.EventHandler( this.DetailsForm_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblIssueType;
        private System.Windows.Forms.Label lblCause;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.Label lblFileInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolTip ttpFileInfo;
    }
}