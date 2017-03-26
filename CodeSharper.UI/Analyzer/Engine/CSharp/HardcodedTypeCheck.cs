using CodeSharper.UI.Analyzer.Engine.Common;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UI.Analyzer.Engine.CSharp
{
    public class HardcodedTypeCheck : SingleLineCodeCheck, ICommand
    {
        public HardcodedTypeCheck(int lineNumber, string codeLine)
            : base(lineNumber, codeLine)
        {
        }
        
        public Issue Execute()
        {
            var specification = new HardcodedTypeSpecification();
            return specification.IsSatisfiedBy(CodeLine) ? new Issue(LineNumber, IssueType.TypeInfoHardCoded, CodeLine) : null;
        }
    }
}
