

namespace CodeSharper.UI.Analyzer.Engine
{
    /// <summary>
    /// Common interface that binds all commands of the execution
    /// </summary>
    public interface ICommand
    {
        Issue Execute();
    }
}
