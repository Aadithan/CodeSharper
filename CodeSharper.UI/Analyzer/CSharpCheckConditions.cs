namespace CodeSharper.UI.Analyzer
{
    internal class CSharpCheckConditions : CheckConditions
    {
        public bool CheckMagicStrings;
        public bool CheckInlineHtml;
        public bool CheckIncompleteSummary;
        public bool CheckWronglyFormatted;
        public bool CheckUnfinishedTodos;
        public bool CheckBadComparison;
        public bool CheckObsolete;
        public bool CheckValueComparisons;
        public bool CheckStringContenations;
        public bool CheckEmptyStrings;
        public bool CheckRelativePaths;
        public bool CheckTypeHardcoded;
    }
}
