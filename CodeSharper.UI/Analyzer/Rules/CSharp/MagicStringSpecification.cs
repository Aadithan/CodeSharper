
using System.Linq;
using CodeSharper.UI.Analyzer.Engine;
using CodeSharper.UI.Analyzer.Specifications;

namespace CodeSharper.UI.Analyzer.Rules.CSharp
{
    public class MagicStringSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string codeLine)
        {
            string codeLineTrimmed = Utilities.GetSpacesRemoved(codeLine);
            return Constants.MagicStringCharSets.Any(codeLineTrimmed.Contains);
        }
    }
}
