
using System.Linq;
using CodeSharper.UI.Analyzer.Specifications;

namespace CodeSharper.UI.Analyzer.Rules.CSharp
{
    public class ContainsCommentSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string codeLine)
        {
            bool startsWithComment = Constants.CommentedCodeCharSet.Any(codeLine.Trim().StartsWith);
            bool endsWithComment = Constants.CommentedCodeCharSetEnd.Any(codeLine.Trim().EndsWith);

            return startsWithComment || endsWithComment;
        }
    }
}
