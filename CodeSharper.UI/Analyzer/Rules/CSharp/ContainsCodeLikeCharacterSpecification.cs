
using System.Linq;
using CodeSharper.UI.Analyzer.Specifications;

namespace CodeSharper.UI.Analyzer.Rules.CSharp
{
    public class ContainsCodeLikeCharacterSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string codeLine)
        {
            return Constants.CodeLikeCharSets.Any(codeLine.Contains);
        }
    }
}
