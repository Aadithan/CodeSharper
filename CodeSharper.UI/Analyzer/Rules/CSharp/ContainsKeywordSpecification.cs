
using System.Linq;
using CodeSharper.UI.Analyzer.Engine;
using CodeSharper.UI.Analyzer.Specifications;

namespace CodeSharper.UI.Analyzer.Rules.CSharp
{
    public class ContainsKeywordSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string codeLine)
        {
            return Constants.NonExcludedKeywords.Any(codeLine.Contains);
        }
    }
}
