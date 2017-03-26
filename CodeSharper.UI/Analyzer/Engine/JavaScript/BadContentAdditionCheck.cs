
using CodeSharper.UI.Analyzer.Engine.Common;

namespace CodeSharper.UI.Analyzer.Engine.JavaScript
{
    /// <summary>
    /// Class that contains methods and features to check bad content in JavaScript code
    /// </summary>
    public class BadContentAdditionCheck : SingleLineCodeCheck, ICommand
    {
        public BadContentAdditionCheck(int lineNumber, string codeLine)
            : base(lineNumber, codeLine)
        {
        }

        public Issue Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
