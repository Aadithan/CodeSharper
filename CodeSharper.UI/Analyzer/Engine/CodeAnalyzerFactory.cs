
using System;

namespace CodeSharper.UI.Analyzer.Engine
{
    /// <summary>
    /// Factory to get the code analyser for the session.
    /// </summary>
    public class CodeAnalyzerFactory
    {
        public static ICodeAnalyzer GetAnalyzer(AnalysisFileType fileType)
        {
            switch (fileType)
            {
                case AnalysisFileType.CSharp:
                    return new CSharpCodeAnalyzer();
                default:
                    throw new NotImplementedException("The requested code analyser is not available for the requested file type");
            }
        }
    }
}
