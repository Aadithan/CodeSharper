using System.Collections.Generic;
using System.Windows.Forms;

namespace CodeSharper.UI.Analyzer
{
    /// <summary>
    /// Class that contains helper methods to create objects for UI rendering and handling
    /// </summary>
    public class UiHelper
    {
        /// <summary>
        /// Get the list of files supported for analysis
        /// </summary>
        /// <returns>The list of files supported for analysis</returns>
        public static List<AnalysisFile> GetAnalysisFiles()
        {
            var analysisFiles = new List<AnalysisFile>
                                    {
                                        new AnalysisFile(AnalysisFileType.CSharp, true, ApplicationConstants.AnalysisFileTypeExtensionStrings[AnalysisFileType.CSharp])
                                        //new AnalysisFile(AnalysisFileType.Javascript, true, ApplicationConstants.AnalysisFileTypeExtensionStrings[AnalysisFileType.Javascript])
                                    };
            return analysisFiles;
        }

        /// <summary>
        /// Method to show a message box in information mode
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        /// <param name="title">The title of the message box</param>
        public static void ShowInformationMessageBox(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Method to show a message box in exclamation mode
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        /// <param name="title">The title of the message box</param>
        public static void ShowExclamationMessageBox(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Method to show a message box in error mode
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        /// <param name="title">The title of the message box</param>
        public static void ShowErrorMessageBox(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowErrorMessageBoxOnOwner(IWin32Window owner, string message, string title)
        {
            MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
