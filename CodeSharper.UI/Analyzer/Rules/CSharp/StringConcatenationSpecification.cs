using System.Linq;
using CodeSharper.UI.Analyzer.Engine;
using CodeSharper.UI.Analyzer.Specifications;

namespace CodeSharper.UI.Analyzer.Rules.CSharp
{
    public class StringConcatenationSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string codeLine)
        {
            string codeLineSpacesRemoved = Utilities.GetSpacesRemoved(codeLine);
            return Constants.ConcatenatedStringCharSets.Any(codeLineSpacesRemoved.Contains);
        }
    }
}
