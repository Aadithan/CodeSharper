
using System;
using System.Collections.Generic;

namespace CodeSharper.UI.Analyzer.Engine
{
    public sealed class JavaScriptCodeAnalyzer : ICodeAnalyzer
    {

        public List<Issue> GetIssuesFromCode(string fileName, string[] codeLines)
        {
            throw new NotImplementedException();
        }

        public void BuildConditions(List<IssueType> issueTypes)
        {
            throw new NotImplementedException();
        }

        public string GetIssueTypeString(IssueType issueType)
        {
            throw new NotImplementedException();
        }

        public bool HasConditions()
        {
            throw new NotImplementedException();
        }

        public string GetIssueGuidelines(IssueType issueType)
        {
            throw new NotImplementedException();
        }
    }
}
