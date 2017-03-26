
namespace CodeSharper.UI.Analyzer.Engine.Common
{
   public class MultiLineCodeCheck
   {
       protected int LineNumber; 
       protected string[] CodeLines;

        public MultiLineCodeCheck(int lineNumber, string[] codeLines)
        {
            LineNumber = lineNumber;
            CodeLines = codeLines;
        }
    }
}
