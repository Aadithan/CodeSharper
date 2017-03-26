namespace CodeSharper.UI.Analyzer.Engine
{
    public enum IssueType
    {
        /// <summary>
        /// The issue is a commented line of code or a comment provided inline
        /// </summary>
        CodeComment = 0,
        /// <summary>
        /// The issue is a potential magic string used for business logic
        /// </summary>
        MagicString = 1,
        /// <summary>
        /// The issue is a potential Visual Studio TODO item.
        /// </summary>
        Todo = 2,
        /// <summary>
        /// Potential bad logic
        /// </summary>
        BadComparison = 3,
        /// <summary>
        /// Potential inline HTML scripts
        /// </summary>
        InlineHtml = 4,
        /// <summary>
        /// Usage of an obsolete Method or Class in the code when better alternatives exist.
        /// </summary>
        ObsoleteMethodOrClass = 5,
        /// <summary>
        /// Issue due to wrong indent or non availability of braces or misplaced braces in code
        /// </summary>
        WrongCodeFormat = 6,
        /// <summary>
        /// Issue due to unfinished summary comment for a method or class.
        /// </summary>
        IncompleteSummaryComment = 7,
        /// <summary>
        /// Possible comparison of string values in business logic.
        /// </summary>
        ValueComparison = 8,
        /// <summary>
        /// Direct concatenation of strings using the + or += operator.
        /// </summary>
        StringConcatenation = 9,
        /// <summary>
        /// Usage of an empty string
        /// </summary>
        EmptyString = 10,
        /// <summary>
        /// Usage of relative paths to refer to URL or file path.
        /// </summary>
        RelativePath = 11,
        /// <summary>
        /// Usage of type information in string format.
        /// </summary>
        TypeInfoHardCoded = 12,
        /// <summary>
        /// A method call done wrongly, especially in Javascript with arguments ignored.
        /// </summary>
        WrongMethodCall = 13,
        /// <summary>
        /// Direct element reference by using document.getElementById, document.all or document.getElementsByTagName
        /// </summary>
        DirectElementReference = 14
    }
}
