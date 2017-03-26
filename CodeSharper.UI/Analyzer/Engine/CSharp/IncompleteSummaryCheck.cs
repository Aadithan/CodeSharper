using CodeSharper.UI.Analyzer.Engine.Common;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UI.Analyzer.Engine.CSharp
{
    public class IncompleteSummaryCheck : SingleLineCodeCheck, ICommand
    {
        public IncompleteSummaryCheck(int lineNumber, string codeLine)
            : base(lineNumber, codeLine)
        {
        }

        public Issue Execute()
        {
            var specification = new IncompleteSummaryCommentSpecification();
            return specification.IsSatisfiedBy(CodeLine) ? new Issue(LineNumber, IssueType.IncompleteSummaryComment, CodeLine) : null;
        }
    }
}
