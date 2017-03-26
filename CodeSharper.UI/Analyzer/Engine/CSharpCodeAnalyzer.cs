using System.Collections.Generic;
using System.Linq;
using CodeSharper.UI.Analyzer.Engine.CSharp;
using CodeSharper.UI.Analyzer.Engine.Common;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UI.Analyzer.Engine
{
    public sealed class CSharpCodeAnalyzer : ICodeAnalyzer
    {
        public CheckConditions CheckConditions { get; set; }
        public List<ICommand> CodeChecks { get; private set; }

        /// <summary>
        /// Builds all conditions required in CSharpCodeAnalyzer using a set of issue types selected by the user.
        /// </summary>
        /// <param name="issueTypes">List of issues selected by the user for analysis</param>
        public void BuildConditions(List<IssueType> issueTypes)
        {
            CheckConditions = new CSharpCheckConditions();
            var cSharpConditions = CheckConditions as CSharpCheckConditions;

            cSharpConditions.CheckBadComparison = issueTypes.Contains(IssueType.BadComparison);
            cSharpConditions.CheckCommentedCodes = issueTypes.Contains(IssueType.CodeComment);
            cSharpConditions.CheckEmptyStrings = issueTypes.Contains(IssueType.EmptyString);
            cSharpConditions.CheckIncompleteSummary = issueTypes.Contains(IssueType.IncompleteSummaryComment);
            cSharpConditions.CheckInlineHtml = issueTypes.Contains(IssueType.InlineHtml);
            cSharpConditions.CheckMagicStrings = issueTypes.Contains(IssueType.MagicString);
            cSharpConditions.CheckObsolete = issueTypes.Contains(IssueType.ObsoleteMethodOrClass);
            cSharpConditions.CheckRelativePaths = issueTypes.Contains(IssueType.RelativePath);
            cSharpConditions.CheckStringContenations = issueTypes.Contains(IssueType.StringConcatenation);
            cSharpConditions.CheckTypeHardcoded = issueTypes.Contains(IssueType.TypeInfoHardCoded);
            cSharpConditions.CheckUnfinishedTodos = issueTypes.Contains(IssueType.Todo);
            cSharpConditions.CheckValueComparisons = issueTypes.Contains(IssueType.ValueComparison);
            cSharpConditions.CheckWronglyFormatted = issueTypes.Contains(IssueType.WrongCodeFormat);
        }

        /// <summary>
        /// Returns if at least one condition is selected for analysis
        /// </summary>
        /// <returns>True if at least one check box is selected. Else, false</returns>
        public bool HasConditions()
        {
            if (CheckConditions==null)
            {
                return false;
            }
            else
            {
                return ConditionIsValid(CheckConditions as CSharpCheckConditions);
            }
        }

        /// <summary>
        /// Method that gets all issues from the given set of code lines
        /// </summary>
        /// <param name="fileName">Name of the file on which the code check is done</param>
        /// <param name="codeLines">Lines of code to check for issues</param>
        /// <returns>Issues </returns>
        public List<Issue> GetIssuesFromCode(string fileName, string[] codeLines)
        {
            if (!ConditionIsValid(CheckConditions as CSharpCheckConditions))
            {
                return null;
            }

            CodeChecks = new List<ICommand>();

            for (var i = 0; i < codeLines.Length; i++)
            {
                CreateSingleLineCommands(i + 1, codeLines[i]);

                if (i < (codeLines.Length - 1))
                {
                    var multiCheckCodeLines = new[] { codeLines[i], codeLines[i + 1] };
                    CreateMultiLineCommands(i + 1, multiCheckCodeLines);
                }
            }

            if (CodeChecks.Count <= 0)
            {
                return null;
            }

            List<Issue> issues = CodeChecks.Select(codeCheck => codeCheck.Execute()).Where(issue => issue != null).ToList();

            foreach (var issue in issues)
            {
                issue.FileName = fileName;
            }
            return issues;
        }

        private void CreateSingleLineCommands(int lineNumber, string codeLine)
        {
            var conditions = CheckConditions as CSharpCheckConditions;

            if (conditions == null)
            {
                return;
            }

            AddConditionalCheck(conditions.CheckBadComparison, new BadComparisonCheck(lineNumber, codeLine));
            AddConditionalCheck(conditions.CheckCommentedCodes, new CommentedCodeCheck(lineNumber, codeLine));
            AddConditionalCheck(conditions.CheckEmptyStrings, new EmptyStringCheck(lineNumber, codeLine));
            AddConditionalCheck(conditions.CheckIncompleteSummary, new IncompleteSummaryCheck(lineNumber, codeLine));
            AddConditionalCheck(conditions.CheckInlineHtml, new InlineHtmlCheck(lineNumber, codeLine));
            AddConditionalCheck(conditions.CheckMagicStrings, new MagicStringCheck(lineNumber, codeLine));
            AddConditionalCheck(conditions.CheckObsolete, new ObsoleteCheck(lineNumber, codeLine));
            AddConditionalCheck(conditions.CheckRelativePaths, new RelativePathCheck(lineNumber, codeLine));
            AddConditionalCheck(conditions.CheckStringContenations, new StringConcatenationCheck(lineNumber, codeLine));
            AddConditionalCheck(conditions.CheckTypeHardcoded, new HardcodedTypeCheck(lineNumber, codeLine));
            AddConditionalCheck(conditions.CheckUnfinishedTodos, new UnfinishedTodoCheck(lineNumber, codeLine));
            AddConditionalCheck(conditions.CheckValueComparisons, new ValueComparisonCheck(lineNumber, codeLine));

        }

        private void CreateMultiLineCommands(int lineNumber, string[] codeLines)
        {
            var conditions = CheckConditions as CSharpCheckConditions;

            if (conditions == null)
            {
                return;
            }

            AddConditionalCheck(conditions.CheckWronglyFormatted, new WrongFormatCheck(lineNumber, codeLines));
        }

        private void AddConditionalCheck(bool flag, ICommand command)
        {
            if (flag)
            {
                CodeChecks.Add(command);
            }
        }

        private bool ConditionIsValid(CSharpCheckConditions conditions)
        {
            return (conditions.CheckBadComparison || conditions.CheckCommentedCodes || conditions.CheckEmptyStrings ||
                    conditions.CheckIncompleteSummary || conditions.CheckInlineHtml || conditions.CheckMagicStrings ||
                    conditions.CheckObsolete || conditions.CheckRelativePaths || conditions.CheckStringContenations ||
                    conditions.CheckTypeHardcoded || conditions.CheckUnfinishedTodos || conditions.CheckValueComparisons ||
                    conditions.CheckWronglyFormatted);
        }

        public string GetIssueTypeString(IssueType issueType)
        {
            return Constants.IssueTypeStrings[issueType];
        }

        public string GetIssueGuidelines(IssueType issueType)
        {
            return Constants.IssueGuidelines[issueType];
        }

    }
}
