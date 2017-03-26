
using CodeSharper.UI.Analyzer.Engine.Common;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UI.Analyzer.Engine.CSharp
{
    public class ObsoleteCheck : SingleLineCodeCheck, ICommand
    {
        public ObsoleteCheck(int lineNumber, string codeLine)
            : base(lineNumber, codeLine)
        {
        }
        public Issue Execute()
        {
            var specification = new ObsoleteContentSpecification();
            return specification.IsSatisfiedBy(CodeLine) ? new Issue(LineNumber, IssueType.ObsoleteMethodOrClass, CodeLine) : null;
        }
    }
}
