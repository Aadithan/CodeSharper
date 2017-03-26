
namespace CodeSharper.UI.Analyzer.Engine.Common
{
    public class SingleLineCodeCheck
    {
        protected string CodeLine;
        protected int LineNumber;
        
        public SingleLineCodeCheck(int lineNumber, string codeLine)
        {
            LineNumber = lineNumber;
            CodeLine = codeLine;
        }
    }
}
