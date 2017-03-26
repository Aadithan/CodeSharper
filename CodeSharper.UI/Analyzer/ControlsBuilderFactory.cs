using System;
using CodeSharper.UI.Controls.CSharp;

namespace CodeSharper.UI.Analyzer
{
    /// <summary>
    /// Factory to create control builders for UI controls
    /// </summary>
    public class ControlsBuilderFactory
    {
        /// <summary>
        /// Creates a ControlsBuilder for the specified AnalysisFileType
        /// </summary>
        /// <param name="fileType">The file type for which the Controls Builder requires to be created</param>
        /// <returns>The respective ControlsBuilder object</returns>
        public static IControlsBuilder GetControlsBuilder(AnalysisFileType fileType)
        {
            switch (fileType)
            {
                case AnalysisFileType.CSharp:
                    return new ControlsBuilder();
                default:
                    throw new NotImplementedException("There is no control builder implemented for this AnalysisFileType");
            }
        }
    }
}
