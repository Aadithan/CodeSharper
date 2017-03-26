using CodeSharper.UI.Analyzer.Engine.Common;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UI.Analyzer.Engine.CSharp
{
    public class InlineHtmlCheck : SingleLineCodeCheck, ICommand
    {
        public InlineHtmlCheck(int lineNumber, string codeLine)
            : base(lineNumber, codeLine)
        {
        }
        
        public Issue Execute()
        {
            var specification = new InlineHtmlSpecification();
            return specification.IsSatisfiedBy(CodeLine) ? new Issue(LineNumber, IssueType.InlineHtml, CodeLine) : null;
        }
    }
}
