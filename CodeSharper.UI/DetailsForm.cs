using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeSharper.UI.Analyzer;
using CodeSharper.UI.Analyzer.Engine;

namespace CodeSharper.UI
{
    internal partial class DetailsForm : Form
    {
        public string FileName;
        public int LineNumber;
        public string Contents;
        public string Guidelines;
        public string IssueText;
        public IssueType TypeOfIssue;

        public DetailsForm ()
        {
            InitializeComponent();
        }

        private void DetailsForm_Load ( object sender, EventArgs e )
        {
            CenterToParent();
            lblFileInfo.Text = FileName + " (Line: " + LineNumber.ToString() + ")";

            lblContents.Text = Contents;
            lblIssueType.Text = IssueText;
            lblDetails.Text = Guidelines;
            ttpFileInfo.SetToolTip( lblFileInfo, "Click on the link to open the line with issue in Visual Studio." );
        }

        private void btnClose_Click ( object sender, EventArgs e )
        {
            this.Close();
        }

        private void lblFileInfo_Click ( object sender, EventArgs e )
        {
            try
            {
                VsHelper.LaunchSourceFile(this.Owner, FileName, LineNumber.ToString() );
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Opening the item in Visual Studio encountered an error: " + ex.Message, "Error Opening Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
            }
        }
    }
}
