using CodeSharper.UI.Analyzer.Engine.Common;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UI.Analyzer.Engine.CSharp
{
    public class EmptyStringCheck : SingleLineCodeCheck, ICommand
    {
        public EmptyStringCheck(int lineNumber, string codeLine)
            : base(lineNumber, codeLine)
        {
        }
        
        public Issue Execute()
        {
            var specification = new EmptyStringSpecification();
            return specification.IsSatisfiedBy(CodeLine) ? new Issue(LineNumber, IssueType.EmptyString, CodeLine) : null;
        }
    }
}
