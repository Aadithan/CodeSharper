using CodeSharper.UI.Analyzer.Engine;
using CodeSharper.UI.Analyzer.Specifications;

namespace CodeSharper.UI.Analyzer.Rules.CSharp
{
    public class MagicNumberSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string codeLine)
        {
            string codeLineTrimmed = Utilities.GetSpacesRemoved(codeLine);
            foreach(var charSet in Constants.ComparisonOperatorCharSets)
            {
                int occurrenceIndex = codeLineTrimmed.IndexOf(charSet, System.StringComparison.Ordinal);
                int occurrenceIndexRight = occurrenceIndex + charSet.Length;
                int occurrenceIndexLeft = occurrenceIndex - 1;
                
                if (occurrenceIndexRight < codeLineTrimmed.Length)
                {
                    int magicValueRight;
                    bool isNumber = int.TryParse(codeLineTrimmed.Substring(occurrenceIndexRight, 1), out magicValueRight);
                    if (isNumber)
                    {
                        return true;
                    }
                }

                if(occurrenceIndexLeft>0)
                {
                    int magicValueLeft;
                    bool isNumber = int.TryParse(codeLineTrimmed.Substring(occurrenceIndexLeft, 1), out magicValueLeft);
                    if (isNumber)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
