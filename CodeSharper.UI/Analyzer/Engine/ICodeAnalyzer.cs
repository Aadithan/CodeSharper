
using System.Collections.Generic;

namespace CodeSharper.UI.Analyzer.Engine
{
    public interface ICodeAnalyzer
    {
        List<Issue> GetIssuesFromCode(string fileName, string[] codeLines);
        void BuildConditions(List<IssueType> issueTypes);
        string GetIssueTypeString(IssueType issueType);
        string GetIssueGuidelines(IssueType issueType);
        bool HasConditions();
    }
}
