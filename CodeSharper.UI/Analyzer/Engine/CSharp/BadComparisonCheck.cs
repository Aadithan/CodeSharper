using CodeSharper.UI.Analyzer.Engine.Common;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UI.Analyzer.Engine.CSharp
{
    public class BadComparisonCheck : SingleLineCodeCheck, ICommand
    {
        public BadComparisonCheck(int lineNumber, string codeLine)
            : base(lineNumber, codeLine)
        {
        }

        public Issue Execute()
        {
            var specification = new BadComparisonSpecification();
            return specification.IsSatisfiedBy(CodeLine) ? new Issue(LineNumber, IssueType.BadComparison, CodeLine) : null;
        }
    }
}
