namespace CodeSharper.UI
{
    partial class AboutForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ApplicationNameLabel = new System.Windows.Forms.Label();
            this.ToolFromLabel = new System.Windows.Forms.Label();
            this.CopyrightMessageLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            //this.pictureBox1.Image = global::CodeSharper.UI.Properties.Resources.cptlogo;
            this.pictureBox1.Location = new System.Drawing.Point(46, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ApplicationNameLabel
            // 
            this.ApplicationNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationNameLabel.Location = new System.Drawing.Point(46, 65);
            this.ApplicationNameLabel.Name = "ApplicationNameLabel";
            this.ApplicationNameLabel.Size = new System.Drawing.Size(215, 24);
            this.ApplicationNameLabel.TabIndex = 1;
            this.ApplicationNameLabel.Text = "Code Frisker";
            this.ApplicationNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ToolFromLabel
            // 
            this.ToolFromLabel.Location = new System.Drawing.Point(46, 98);
            this.ToolFromLabel.Name = "ToolFromLabel";
            this.ToolFromLabel.Size = new System.Drawing.Size(215, 22);
            this.ToolFromLabel.TabIndex = 2;
            this.ToolFromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CopyrightMessageLabel
            // 
            this.CopyrightMessageLabel.Location = new System.Drawing.Point(46, 120);
            this.CopyrightMessageLabel.Name = "CopyrightMessageLabel";
            this.CopyrightMessageLabel.Size = new System.Drawing.Size(215, 19);
            this.CopyrightMessageLabel.TabIndex = 3;
            this.CopyrightMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(316, 175);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CopyrightMessageLabel);
            this.Controls.Add(this.ToolFromLabel);
            this.Controls.Add(this.ApplicationNameLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Text = "About Code Frisker";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ApplicationNameLabel;
        private System.Windows.Forms.Label ToolFromLabel;
        private System.Windows.Forms.Label CopyrightMessageLabel;
        private System.Windows.Forms.Button button1;
    }
}