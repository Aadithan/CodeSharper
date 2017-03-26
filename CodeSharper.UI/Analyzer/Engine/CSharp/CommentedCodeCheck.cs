
using CodeSharper.UI.Analyzer.Engine.Common;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UI.Analyzer.Engine.CSharp
{
    public class CommentedCodeCheck : SingleLineCodeCheck, ICommand
    {
        public CommentedCodeCheck(int lineNumber, string codeLine)
            : base(lineNumber, codeLine)
        {
        }
        
        public Issue Execute()
        {
            var specification = new CommentedCodeSpecification();
            return specification.IsSatisfiedBy(CodeLine) ? new Issue(LineNumber, IssueType.CodeComment, CodeLine) : null;
        }
    }
}
