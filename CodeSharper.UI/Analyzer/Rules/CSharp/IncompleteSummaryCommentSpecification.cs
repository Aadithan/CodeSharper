using CodeSharper.UI.Analyzer.Specifications;

namespace CodeSharper.UI.Analyzer.Rules.CSharp
{
    public class IncompleteSummaryCommentSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string codeLine)
        {
            var summarySpec = new SummaryCommentSpecification();
            bool isSummaryComment = summarySpec.IsSatisfiedBy(codeLine);

            if(!isSummaryComment)
            {
                return false;
            }

            return codeLine.Contains(Constants.IncompleteSummaryCommentCharSet);
        }
    }
}
