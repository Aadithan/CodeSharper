
namespace CodeSharper.UI.Analyzer.Engine
{
    public class AnalyzerFactory
    {
        public static ICodeAnalyzer GetAnalyzer(AnalysisFileType fileType)
        {
            switch (fileType)
            {
                case AnalysisFileType.CSharp:
                    return new CSharpCodeAnalyzer();
                case AnalysisFileType.Javascript:
                    return new JavaScriptCodeAnalyzer();
                default:
                    return null;
            }
        }
    }
}
