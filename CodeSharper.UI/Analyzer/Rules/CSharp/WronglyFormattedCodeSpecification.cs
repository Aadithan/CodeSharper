
using System.Linq;
using CodeSharper.UI.Analyzer.Engine;
using CodeSharper.UI.Analyzer.Specifications;

namespace CodeSharper.UI.Analyzer.Rules.CSharp
{
    public class WronglyFormattedCodeSpecification : Specification<string[]>
    {
        public override bool IsSatisfiedBy(string[] codeLines)
        {
            string codeFirstLineTrimmed = Utilities.GetSpacesRemoved(codeLines[0]);

            if (codeFirstLineTrimmed.Length > 1 && codeFirstLineTrimmed.EndsWith("{"))
            {
                return true;
            }

            bool firstLineIsConditiontart = Constants.ConditionalBlockStartCharSet.Any(codeFirstLineTrimmed.StartsWith);
            if (firstLineIsConditiontart && codeFirstLineTrimmed.Contains(";"))
            {
                return true;
            }

            string codeSecondLineTrimmed = Utilities.GetSpacesRemoved(codeLines[1]);
            bool firstLineIsBlockStart = Constants.LogicalBlockStartCharSet.Any(codeFirstLineTrimmed.StartsWith);

            if (firstLineIsBlockStart && !codeSecondLineTrimmed.StartsWith("{"))
            {
                return true;
            }
            return false;
        }
    }
}
