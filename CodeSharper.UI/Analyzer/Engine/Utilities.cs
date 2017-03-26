using System;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UI.Analyzer.Engine
{
    public class Utilities
    {
        public static string GetSpacesRemoved(string codeLine)
        {
            return codeLine.Trim().Replace(Constants.Space, String.Empty);
        }

    }
}
