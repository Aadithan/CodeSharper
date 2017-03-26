using CodeSharper.UI.Analyzer.Engine;
using CodeSharper.UI.Analyzer.Specifications;

namespace CodeSharper.UI.Analyzer.Rules.CSharp
{
    public class SummaryCommentSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string codeLine)
        {
            string codeLineTrimmed = Utilities.GetSpacesRemoved(codeLine);

            bool isDoubleComment = codeLineTrimmed.StartsWith(Constants.DoubleCommentStart);
            bool isSummaryComment = codeLineTrimmed.StartsWith(Constants.SummaryCommentStart);

            return (!isDoubleComment && isSummaryComment);
        }
    }
}
