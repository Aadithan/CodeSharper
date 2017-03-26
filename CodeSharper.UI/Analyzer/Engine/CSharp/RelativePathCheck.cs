
using CodeSharper.UI.Analyzer.Engine.Common;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UI.Analyzer.Engine.CSharp
{
    public class RelativePathCheck : SingleLineCodeCheck, ICommand
    {
        public RelativePathCheck(int lineNumber, string codeLine)
            : base(lineNumber, codeLine)
        {
        }

        public Issue Execute()
        {
            var specification = new RelativePathSpecification();
            return specification.IsSatisfiedBy(CodeLine) ? new Issue(LineNumber, IssueType.RelativePath, CodeLine) : null;
        }
    }
}
