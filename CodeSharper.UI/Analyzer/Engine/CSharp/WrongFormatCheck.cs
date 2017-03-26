using CodeSharper.UI.Analyzer.Engine.Common;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UI.Analyzer.Engine.CSharp
{
    public sealed class WrongFormatCheck : MultiLineCodeCheck, ICommand
    {
        public WrongFormatCheck(int lineNumber, string[] codeLines)
            : base(lineNumber, codeLines)
        {
        }


        public Issue Execute()
        {
            var specification = new WronglyFormattedCodeSpecification();
            return specification.IsSatisfiedBy(CodeLines) ? new Issue(LineNumber, IssueType.WrongCodeFormat, CodeLines[0] + CodeLines[1]) : null;
        }
    }
}
