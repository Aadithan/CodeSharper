namespace CodeSharper.UI.Analyzer.Engine
{
    public class Issue
    {
        public string FileName { get; set; }
        public int LineNumber { get; set; }
        public IssueType TypeOfIssue { get; set; }
        public string Contents { get; set; }

        /// <summary>
        /// Creates an instance of Issue.
        /// </summary>
        public Issue ()
        {
        }

        /// <summary>
        /// Creates an instance of Issue.
        /// </summary>
        /// <param name="lineNumber">The line number in which the issue is found in the file</param>
        /// <param name="typeOfIssue">The type of issue identified in the line</param>
        /// <param name="contents">The contents of the line</param>
        public Issue (int lineNumber, IssueType typeOfIssue, string contents)
        {
            LineNumber = lineNumber;
            TypeOfIssue = typeOfIssue;
            Contents = contents;
        }

        /// <summary>
        /// Creates an instance of Issue.
        /// </summary>
        /// <param name="fileName">Name of the file on which the issue is found</param>
        /// <param name="lineNumber">The line number in which the issue is found in the file</param>
        /// <param name="typeOfIssue">The type of issue identified in the line</param>
        /// <param name="contents">The contents of the line</param>
        public Issue(string fileName,int lineNumber, IssueType typeOfIssue, string contents)
        {
            FileName = fileName;
            LineNumber = lineNumber;
            TypeOfIssue = typeOfIssue;
            Contents = contents;
        }

    }
}
