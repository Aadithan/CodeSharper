
using CodeSharper.UI.Analyzer.Engine.Common;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UI.Analyzer.Engine.CSharp
{
    public class MagicStringCheck : SingleLineCodeCheck, ICommand
    {
        public MagicStringCheck(int lineNumber, string codeLine)
            : base(lineNumber, codeLine)
        {
        }
        public Issue Execute()
        {
            var specification = new MagicStringSpecification();
            return specification.IsSatisfiedBy(CodeLine) ? new Issue(LineNumber, IssueType.MagicString, CodeLine) : null;
        }
    }
}
