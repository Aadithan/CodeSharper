using System;
using System.Windows.Forms;
using CodeSharper.UI.Analyzer;

namespace CodeSharper.UI
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
           
            ApplicationNameLabel.Text = String.Concat(ApplicationConstants.ApplicationTitle, ApplicationConstants.Space,
                                                      ApplicationConstants.ApplicationVersion);
            ToolFromLabel.Text = ApplicationConstants.ApplicationDevelopers;
            CopyrightMessageLabel.Text = ApplicationConstants.CopyrightMessage;

            CenterControl(ApplicationNameLabel);
            CenterControl(ToolFromLabel);
            CenterControl(CopyrightMessageLabel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CenterControl(Control control)
        {
            //control.Left = (Left - control.Left)/2;
            control.Refresh();
        }
    }
}
