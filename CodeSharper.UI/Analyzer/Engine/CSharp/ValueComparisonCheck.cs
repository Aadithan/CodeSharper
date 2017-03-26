
using CodeSharper.UI.Analyzer.Engine.Common;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UI.Analyzer.Engine.CSharp
{
    public class ValueComparisonCheck : SingleLineCodeCheck, ICommand
    {
        public ValueComparisonCheck(int lineNumber, string codeLine)
            : base(lineNumber, codeLine)
        {
        }

        public Issue Execute()
        {
            var specification = new MagicNumberSpecification();
            return specification.IsSatisfiedBy(CodeLine) ? new Issue(LineNumber, IssueType.ValueComparison, CodeLine) : null;
        }
    }
}
