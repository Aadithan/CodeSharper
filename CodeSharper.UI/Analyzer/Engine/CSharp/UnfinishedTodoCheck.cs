using CodeSharper.UI.Analyzer.Engine.Common;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UI.Analyzer.Engine.CSharp
{
    public class UnfinishedTodoCheck : SingleLineCodeCheck, ICommand
    {
        public UnfinishedTodoCheck(int lineNumber, string codeLine)
            : base(lineNumber, codeLine)
        {
        }
        public Issue Execute()
        {
            var specification = new UnfinishedTodoSpecification();
            return specification.IsSatisfiedBy(CodeLine) ? new Issue(LineNumber, IssueType.Todo, CodeLine) : null;
        }
    }
}
