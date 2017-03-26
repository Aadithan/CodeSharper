
using System.Collections.Generic;
using CodeSharper.UI.Analyzer.Engine;

namespace CodeSharper.UI.Analyzer.Rules.CSharp
{
    internal static class Constants
    {
        public static readonly List<string> Keywords = new List<string> {"abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char",
                                                                            "checked", "class", "const", "continue", "decimal", "default", "delegate", "do",
                                                                            "double", "else", "enum", "event", "explicit", "extern", "false", "finally",
                                                                            "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int",
                                                                            "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object",
                                                                            "operator", "out", "override", "params", "private", "protected", "public", "readonly",
                                                                            "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string",
                                                                            "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong",
                                                                            "unchecked", "unsafe", "ushort", "using", "virtual", "volatile", "void", "while"};

        //space added to var to avoid words starting with "var" being selected
        public static readonly List<string> NonExcludedKeywords = new List<string> {"abstract", "base ", "bool", "break", "byte", "case", "catch", "char",
                                                                            "checked", "class", "const", "continue", "decimal", "default", "delegate", "do",
                                                                            "double", "else", "enum", "event", "explicit", "extern", "false", "finally",
                                                                            "fixed", "float", "foreach", "goto", "implicit", "int",
                                                                            "interface", "internal", "lock", "long", "namespace", "new", "null", "object",
                                                                            "operator", "out", "override", "params", "private", "protected", "public", "readonly",
                                                                            "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string",
                                                                            "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong",
                                                                            "unchecked", "unsafe", "ushort", "using", "virtual", "volatile", "void", "while", "var "};
        public static readonly List<string> KeywordExclusions = new List<string> { "is", "as", "in", "if", "for" };
        public static readonly List<string> BlockStartKeywords = new List<string> { "catch", "else", "finally", "for", "foreach", "if", "switch", "try", "while" };
        public static readonly List<string> CodeLikeCharSets = new List<string> { "{", "}", "[", "]", ";", "=", "(", ")" };
        public static readonly List<string> CommentedCodeCharSet = new List<string> { "//", "/*", "////" };
        public static readonly List<string> CommentedCodeCharSetEnd = new List<string> { "*/" };
        public static readonly List<string> HtmlLikeCharSets = new List<string> { "\"<" };
        public static readonly List<string> MagicStringCharSets = new List<string> { "==\"", "=='", "!=\"", "!='", "\"==", "\"!=", "'==", "'!=" };
        public static readonly List<string> TodoCharSets = new List<string> { "//todo", "//(todo" };
        public static readonly List<string> BadComparisonCharSets = new List<string> { "true:false", "false:true", "==true", "==false", "!=true", "!=false", "true==", "false==", "true!=", "false!=" };
        public static readonly string CodeBlockStart = "{";
        public static readonly string CodeLineEnd = ";";
        public static readonly string Space = " ";
        public static readonly string EqualToSymbol = "=";
        public static readonly string ComparisonSymbol = "==";
        public static readonly List<string> ConcatenatedStringCharSets = new List<string>{"+\"", "\"+"};
        public static readonly List<string> ObsoleteContent = new List<string>
                                                                  {
                                                                      "ConfigurationSettings.AppSettings", "AssemblyHash", "XmlDataDocument",
                                                                      "OracleCommand", "OracleCommandBuilder","OracleConnection",
                                                                      "OracleConnectionStringBuilder","OracleDataAdapter","OracleClientFactory",
                                                                      "OraclePermission","PassportAuthentication","PassportIdentity", "PassportPrincipal",
                                                                      "ObjectConverter","System.Web.Mail", "System.Web.Mobile","System.Web.UI.Mobile", 
                                                                      "XmlValidatingReader", "XslTransform","XmlSchemaCollection"
                                                                  };
        public static readonly List<string> EmptyStringCharSet = new List<string> { "\"\"", "==string.empty", "string.empty==", "== string.empty", "string.empty ==" };
        public static readonly List<string> ValueComparisonCharSet = new List<string> { "string.contains" };
        public static readonly List<string> StringContenationCharSet = new List<string> { "+\"", "+=\"" };
        public static readonly List<string> RelativePathCharSet = new List<string> { "../", "..\\" };
        public static readonly List<string> LogicalBlockStartCharSet = new List<string> { "if(", "else", "for(", "foreach(", "while(", "do", "switch(", "try", "catch", "finally" };
        public static readonly List<string> ConditionalBlockStartCharSet = new List<string> { "if", "else" };
        public static readonly string HardCodedTypeCharSet = "\"system.";
        public static readonly string SummaryCommentStart = "///";
        public static readonly string DoubleCommentStart = "////";
        public static readonly string IncompleteSummaryCommentCharSet = "><";
        public static readonly List<string> ComparisonOperatorCharSets = new List<string> { "==", "!=", ">", ">=", "<", "<=" };
        public static readonly List<string> AccessSpecifierCharSet = new List<string> { "private", "public", "internal", "protected" };

        public static readonly Dictionary<IssueType, string> IssueTypeStrings = new Dictionary<IssueType, string>
                                                                                    {
                                                                                        {IssueType.BadComparison, "Bad Comparison"}, 
                                                                                        {IssueType.CodeComment, "Potential Commented Code"},
                                                                                        {IssueType.MagicString, "Magic String"},
                                                                                        {IssueType.InlineHtml, "Inline HTML"},
                                                                                        {IssueType.ObsoleteMethodOrClass, "Obsolete Method or Class"},
                                                                                        {IssueType.WrongCodeFormat, "Wrong Code Format"},
                                                                                        {IssueType.Todo, "Unfinished Todos"},
                                                                                        {IssueType.IncompleteSummaryComment, "Incomplete Summary Comment"},
                                                                                        {IssueType.TypeInfoHardCoded, "Hardcoded Type Information"},
                                                                                        {IssueType.RelativePath, "Relative Path"},
                                                                                        {IssueType.ValueComparison, "Value Comparison"},
                                                                                        {IssueType.EmptyString, "Empty String"},
                                                                                        {IssueType.StringConcatenation, "String Concatenation"}
                                                                                        
                                                                                    };
        public static readonly Dictionary<IssueType, string> IssueGuidelines = new Dictionary<IssueType, string>
                                                                                   {
                                                                                        {IssueType.BadComparison, "Verify whether you are using an unwanted check for true or false values;\nor the usage of ternary operator in a wrong context."}, 
                                                                                        {IssueType.CodeComment, "It is a bad practice to check-in commented code to a source control repository. Alternatively, this line could be a genuine comment.\nIf it is commented code, please remove it. "},
                                                                                        {IssueType.MagicString, "This line contains a string comparison within double quotes.\nIf this is a check for an empty string, use stringValue.Length==0, which is the efficient way to check\nPlease refactor it to use enumerations in case of checking business logic.\nIn case of genuine comparisons, use String.Equals."},
                                                                                        {IssueType.InlineHtml, "This line seems to contain inline HTML tags.\nUse a HTML library to generate content, or move all HTML tags to constants/configuration and use them"},
                                                                                        {IssueType.ObsoleteMethodOrClass, "Usage of an obsolete method or class name found. Please use the recommended alternative.\nFor example, instead of ConfigurationSettings, use ConfigurationManager.\nIn case the application already contains a common method implementation for this usage, please reuse it."},
                                                                                        {IssueType.WrongCodeFormat, "Wrongly formatted or indented code found.\nEnsure that all conditional and looping constructs have braces put as the only character in next line.\nAlso ensure that open braces are not placed within the same line of the conditional or looping construct."},
                                                                                        {IssueType.Todo, "This line seems to have an unfinished todo mark. If the work is finished, please remove the todo mark\nIf unfinished Todo, finish the work and remove the Todo from this place."},
                                                                                        {IssueType.IncompleteSummaryComment, "The summary comments in this line are incomplete\nAdd valid and meaningful comments to all parameters/arguments of a method or constructor"},
                                                                                        {IssueType.TypeInfoHardCoded, "Hardcoded type information found in this line, which cannot be verified in compile time.\nChoose an alternative method. For example, use typeOf(string) instead of \"System.String\""},
                                                                                        {IssueType.RelativePath, "Relative path or URL reference usage found.\nPlease use an alternative such as UriBuilder or Path.Combine"},
                                                                                        {IssueType.ValueComparison, "There seems to be a potential value comparison that involves business logic in this line.\nPlease refactor to an appropriate alternative like enumerations.\nIf it is a valid comparison, get it reviewed and approved from your reviewer."},
                                                                                        {IssueType.StringConcatenation, "This line contains string concatenation. Check whether better alternatives can be provided.\nIn case of file paths or urls, use Path.Combine or UriBuilder. To join strings with delimiter, use String.Join\nIn case of using large strings with multiple concatenations, use StringBuilder."},
                                                                                        {IssueType.EmptyString, "This line contains one or more empty strings."}
                                                                                   };

    }
}
