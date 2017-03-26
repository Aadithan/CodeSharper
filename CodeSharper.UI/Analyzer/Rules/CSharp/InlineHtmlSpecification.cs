

using CodeSharper.UI.Analyzer.Specifications;

namespace CodeSharper.UI.Analyzer.Rules.CSharp
{
    public class InlineHtmlSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string codeLine)
        {
            var summarySpec = new SummaryCommentSpecification();
            bool isSummary = summarySpec.IsSatisfiedBy(codeLine);

            if (isSummary)
            {
                return false;
            }
            
            int tagIndex = codeLine.IndexOf("\"<", System.StringComparison.Ordinal);

            if (tagIndex < 0)
            {
                return false;
            }

            return codeLine[tagIndex + 1] != ' ' && codeLine[tagIndex + 1] != '=';
        }

    }
}
