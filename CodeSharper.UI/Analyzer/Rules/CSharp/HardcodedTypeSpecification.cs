using CodeSharper.UI.Analyzer.Specifications;

namespace CodeSharper.UI.Analyzer.Rules.CSharp
{
    public class HardcodedTypeSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string codeLine)
        {
            return codeLine.ToLower().Contains(Constants.HardCodedTypeCharSet);
        }
    }
}
