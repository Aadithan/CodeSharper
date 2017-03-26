

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CodeSharper.UI.Analyzer
{
    /// <summary>
    /// Class that is used to export data from the application
    /// </summary>
    public static class ExportHelper
    {
        public static void ExportListToCsv(ListView lvwReport, string fileName)
        {
            if (lvwReport.Items.Count <= 0)
            {
                UiHelper.ShowExclamationMessageBox(ApplicationConstants.NoItemsFoundToExport, ApplicationConstants.ApplicationTitle);
                return;
            }

            var exportContents = new StringBuilder();
            exportContents.Append("Sl. No." + "\t");
            exportContents.Append("File" + "\t");
            exportContents.Append("Line Number" + "\t");
            exportContents.Append("Type of Issue" + "\t");
            exportContents.Append("Contents" + "\n");
            foreach (ListViewItem issue in lvwReport.Items)
            {
                exportContents.Append(issue.SubItems[0].Text + "\t");
                exportContents.Append(issue.SubItems[1].Text + "\t");
                exportContents.Append(issue.SubItems[2].Text + "\t");
                exportContents.Append(issue.SubItems[3].Text + "\t");
                exportContents.Append(issue.SubItems[4].Text.Replace("<", "[").Replace(">", "]") + "\n");
            }

            try
            {
                File.WriteAllText(fileName, exportContents.ToString());
            }
            catch (Exception ex)
            {
                UiHelper.ShowErrorMessageBox(String.Concat(ApplicationConstants.FileExportErrorMessage, ex.Message), ApplicationConstants.FileExportErrorTitle);
            }
        }

    }
}
