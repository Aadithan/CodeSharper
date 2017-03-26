//using System;
//using System.IO;
//using System.Collections;
//using System.Xml;
//using System.Reflection;
//using CodeSharper.UI.Analyzer.Engine;

//namespace CodeSharper.UI.Analyzer
//{
//    internal class IssuesManager
//    {
//        ArrayList files = new ArrayList();
//        ArrayList fileExceptions = new ArrayList();
//        ArrayList extensionExceptions = new ArrayList();
//        ArrayList contentExceptions = new ArrayList();

//        public CheckConditions Condition;

//        public AnalysisFileType FileType;

//        //public string[] GetMatchingFiles ( string directory )
//        //{
//        //    try
//        //    {
//        //        foreach (string subdirectory in Directory.GetDirectories( directory ))
//        //        {
//        //            foreach (string filename in Directory.GetFiles( subdirectory, GetExtensionForAnalysisType( FileType ) ))
//        //            {
//        //                files.Add( filename );
//        //            }
//        //            GetMatchingFiles( subdirectory );
//        //        }
//        //    }
//        //    catch (System.Exception excpt)
//        //    {
//        //        Console.WriteLine( excpt.Message );
//        //    }
//        //    return (string[])files.ToArray( typeof( string ) );
//        //}

//        /// <summary>
//        /// Load all files, extensions and contents to be ignored while checking for issues.
//        /// </summary>
//        public void LoadExceptions ()
//        {
//            XmlDocument doc = new XmlDocument();
//            string path = Path.GetDirectoryName( Assembly.GetExecutingAssembly().GetName().CodeBase );
//            string filePath = path.EndsWith( "\\" ) ? path + "exceptions.xml" : path + "\\exceptions.xml";
//            filePath = filePath.Replace( "file:\\", string.Empty );
//            string xmlContent = File.ReadAllText( filePath );
//            doc.LoadXml( xmlContent );
//            XmlNode fileNodeMain = doc.SelectSingleNode( "exceptions/fileExceptions" );
//            XmlNode extensionNodeMain = doc.SelectSingleNode( "exceptions/extensionExceptions" );
//            XmlNode contentNodeMain = doc.SelectSingleNode( "exceptions/contentExceptions" );

//            XmlNodeList fileNodes = fileNodeMain.ChildNodes;
//            XmlNodeList extensionNodes = extensionNodeMain.ChildNodes;
//            XmlNodeList contentNodes = contentNodeMain.ChildNodes;

//            foreach (XmlNode file in fileNodes)
//            {
//                string fileExc = file.Attributes["value"].Value;
//                fileExceptions.Add( fileExc );
//            }

//            foreach (XmlNode extension in extensionNodes)
//            {
//                extensionExceptions.Add( extension.Attributes["value"].Value );
//            }

//            foreach (XmlNode content in contentNodes)
//            {
//                contentExceptions.Add( content.Attributes["value"].Value );
//            }
//        }

//        public bool IsExcludedFile ( string filePath )
//        {
//            string fileName = Path.GetFileName( filePath );

//            foreach (string file in fileExceptions)
//            {
//                if (fileName.Equals( file, StringComparison.OrdinalIgnoreCase ))
//                {
//                    return true;
//                }
//            }

//            foreach (string extension in extensionExceptions)
//            {
//                if (fileName.EndsWith( extension, StringComparison.OrdinalIgnoreCase ))
//                {
//                    return true;
//                }
//            }

//            return false;
//        }


//        public ArrayList GetIssuesInFile ( string filePath )
//        {
//            ArrayList issues = new ArrayList();

//            string fileName = Path.GetFileName( filePath );

//            string fileContents = File.ReadAllText( filePath );
//            string[] codeLines = fileContents.Split( '\n' );


//            #region C Sharp Code
//            if (FileType == AnalysisFileType.CSharp)
//            {
//                CSharpCheckConditions checkCondition = (CSharpCheckConditions)Condition;

//                for (int i = 0; i < codeLines.Length; i++)
//                {

//                    if (!codeLines[i].Trim().StartsWith( "///" ))
//                    {

//                        if (checkCondition.CheckCommentedCodes)
//                        {
//                            if (codeLines[i].Trim().StartsWith( "/*" ))
//                            {
//                                issues.Add( new Issue( filePath, i + 1, IssueType.CodeComment, codeLines[i].Trim() ) );
//                            }
//                        }

//                        if (checkCondition.CheckUnfinishedTodos)
//                        {
//                            if (codeLines[i].Trim().StartsWith( "//todo", StringComparison.OrdinalIgnoreCase ) || codeLines[i].Trim().StartsWith( "//(todo", StringComparison.OrdinalIgnoreCase ))
//                            {
//                                issues.Add( new Issue( filePath, i + 1, IssueType.Todo, codeLines[i].Trim() ) );
//                            }
//                        }

//                        if (checkCondition.CheckCommentedCodes)
//                        {
//                            string codeLineTrimmed = codeLines[i].Trim().Replace( " ", string.Empty );

//                            if (codeLineTrimmed.StartsWith( "//if(" ) || codeLineTrimmed.StartsWith( "//for(" ) || codeLineTrimmed.StartsWith( "//else" ) || codeLineTrimmed.StartsWith( "//while(" ) || codeLineTrimmed.StartsWith( "//switch(" ))
//                            {
//                                if (!codeLines[i].Trim().StartsWith( "//form" ))
//                                {
//                                    issues.Add( new Issue( filePath, i + 1, IssueType.CodeComment, codeLines[i].Trim() ) );
//                                }
//                            }
//                            else if (codeLineTrimmed.StartsWith( "//" ) && !codeLineTrimmed.ToLower().Contains( "todo" ))
//                            {
//                                if (codeLineTrimmed.Contains( ";" ) || codeLineTrimmed.Contains( "(" ) || codeLineTrimmed.Contains( ")" ) || codeLineTrimmed.Contains( "[" ) || codeLineTrimmed.Contains( "]" ) || codeLineTrimmed.Contains( "=" ) || codeLineTrimmed.Contains( "{" ) || codeLineTrimmed.Contains( "}" ))
//                                {
//                                    issues.Add( new Issue( filePath, i + 1, IssueType.CodeComment, codeLines[i].Trim() ) );
//                                }
//                            }

//                        }

//                        if (checkCondition.CheckInlineHtml)
//                        {
//                            int tagIndex = codeLines[i].IndexOf( "\"<" );
//                            if (tagIndex >= 0)
//                            {
//                                if (codeLines[i][tagIndex + 1] != ' ' && codeLines[i][tagIndex + 1] != '=')
//                                {
//                                    issues.Add( new Issue( filePath, i + 1, IssueType.InlineHtml, codeLines[i].Trim() ) );
//                                }
//                            }
//                        }
//                    }

//                    if (checkCondition.CheckMagicStrings)
//                    {
//                        if (codeLines[i].Contains( "== \"" ) || codeLines[i].Contains( "== '" ))
//                        {
//                            issues.Add( new Issue( filePath, i + 1, IssueType.MagicString, codeLines[i].Trim() ) );
//                        }
//                        else if (codeLines[i].Contains( "!= \"" ) || codeLines[i].Contains( "!= '" ))
//                        {
//                            issues.Add( new Issue( filePath, i + 1, IssueType.MagicString, codeLines[i].Trim() ) );
//                        }
//                    }

//                    if (checkCondition.CheckBadComparison)
//                    {
//                        if (codeLines[i].Contains( "true : false" ) || codeLines[i].Contains( "false : true" ) || codeLines[i].Contains( "== true" ) || codeLines[i].Contains( "== false" ) || codeLines[i].Contains( "!= true" ) || codeLines[i].Contains( "!= false" ))
//                        {
//                            issues.Add( new Issue( filePath, i + 1, IssueType.BadComparison, codeLines[i].Trim() ) );
//                        }
//                    }

//                    if (checkCondition.CheckWronglyFormatted)
//                    {
//                        if (codeLines[i].Trim().Length > 1 && codeLines[i].Trim().EndsWith( "{" ))
//                        {
//                            issues.Add( new Issue( filePath, i + 1, IssueType.WrongCodeFormat, codeLines[i].Trim() ) );
//                        }

//                        if (codeLines[i].Trim().StartsWith( "if" ) || codeLines[i].Trim().StartsWith( "else" ) || codeLines[i].Trim().StartsWith( "for" ) || codeLines[i].Trim().StartsWith( "while" ) || codeLines[i].Trim().StartsWith( "switch" ))
//                        {
//                            if (!codeLines[i].Trim().StartsWith( "form" ) && codeLines[i].Trim().EndsWith( ")" ))
//                            {
//                                if (!codeLines[i + 1].Trim().StartsWith( "{" ))
//                                {
//                                    issues.Add( new Issue( filePath, i + 1, IssueType.WrongCodeFormat, codeLines[i].Trim() + "\n" + codeLines[i + 1] ) );
//                                }
//                            }
//                        }
//                        if (codeLines[i].Trim().StartsWith("if") || codeLines[i].Trim().StartsWith("else"))
//                        {
//                            if (codeLines[i].Contains(";"))
//                            {
//                                issues.Add(new Issue(filePath, i + 1, IssueType.WrongCodeFormat, codeLines[i].Trim()));
//                            }
//                        }
//                    }

//                    if (checkCondition.CheckObsolete)
//                    {
//                        if (codeLines[i].Contains( "ConfigurationSettings" ))
//                        {
//                            issues.Add( new Issue( filePath, i + 1, IssueType.ObsoleteMethodOrClass, codeLines[i].Trim() ) );
//                        }
//                    }

//                    if (checkCondition.CheckIncompleteSummary)
//                    {
//                        if (codeLines[i].Contains( "><" ))
//                        {
//                            issues.Add( new Issue( filePath, i + 1, IssueType.IncompleteSummaryComment, codeLines[i].Trim() ) );
//                        }
//                    }

//                    if (checkCondition.CheckValueComparisons)
//                    {
//                        string codeCheckLine = codeLines[i].ToLower();
//                        if (codeCheckLine.Contains( "string.contains" ))
//                        {
//                            issues.Add( new Issue( filePath, i + 1, IssueType.ValueComparison, codeLines[i].Trim() ) );
//                        }

//                        if (codeCheckLine.Contains( "== " ))
//                        {
//                            int occurrenceIndex = codeCheckLine.IndexOf( "== " );
//                            occurrenceIndex = occurrenceIndex + 3;

//                            int magicValue;
//                            if (int.TryParse( codeCheckLine.Substring( occurrenceIndex, 1 ), out magicValue ))
//                            {
//                                issues.Add( new Issue( filePath, i + 1, IssueType.ValueComparison, codeLines[i].Trim() ) );
//                            }
//                        }
//                    }

//                    if (checkCondition.CheckStringContenations)
//                    {
//                        if (codeLines[i].Contains( "+ \"" ) || codeLines[i].Contains( "+= \"" ))
//                        {
//                            issues.Add( new Issue( filePath, i + 1, IssueType.StringConcatenation, codeLines[i].Trim() ) );
//                        }
//                    }

//                    if (checkCondition.CheckEmptyStrings)
//                    {
//                        if (codeLines[i].Replace( "\\\"", "&dbquot" ).Contains( "\"\"" ))
//                        {
//                            issues.Add( new Issue( filePath, i + 1, IssueType.EmptyString, codeLines[i].Trim() ) );
//                        }
//                    }
//                    if (checkCondition.CheckRelativePaths)
//                    {
//                        if (codeLines[i].Contains( "../" ) || codeLines[i].Contains( "..\\" ))
//                        {
//                            issues.Add( new Issue( filePath, i + 1, IssueType.RelativePath, codeLines[i].Trim() ) );
//                        }
//                    }

//                    if (checkCondition.CheckTypeHardcoded)
//                    {
//                        if (!codeLines[i].Contains( "GeneratedCode" ) && codeLines[i].Contains( "\"System." ))
//                        {
//                            issues.Add( new Issue( filePath, i + 1, IssueType.TypeInfoHardCoded, codeLines[i].Trim() ) );
//                        }
//                    }
//                }
//            }

//            #endregion

//            #region Javascript Code

//            else if (FileType == AnalysisFileType.Javascript)
//            {
//                JavascriptCheckCondition checkCondition = (JavascriptCheckCondition)Condition;

//                for (int i = 0; i < codeLines.Length; i++)
//                {

//                    if (!codeLines[i].Trim().StartsWith( "///" ))
//                    {

//                        if (checkCondition.CheckCommentedCodes)
//                        {
//                            if (codeLines[i].Trim().StartsWith( "/*" ))
//                            {
//                                issues.Add( new Issue( filePath, i + 1, IssueType.CodeComment, codeLines[i].Trim() ) );
//                            }
//                        }

//                        if (checkCondition.CheckCommentedCodes)
//                        {
//                            if (codeLines[i].Trim().StartsWith( "//if" ) || codeLines[i].Trim().StartsWith( "//for" ) || codeLines[i].Trim().StartsWith( "//else" ) || codeLines[i].Trim().StartsWith( "//while" ) || codeLines[i].Trim().StartsWith( "//switch" ))
//                            {
//                                if (!codeLines[i].Trim().StartsWith( "//form" ))
//                                {
//                                    issues.Add( new Issue( filePath, i + 1, IssueType.CodeComment, codeLines[i].Trim() ) );
//                                }
//                            }
//                            else if (codeLines[i].Trim().StartsWith( "//" ) && codeLines[i].Trim().EndsWith( ";" ))
//                            {
//                                issues.Add( new Issue( filePath, i + 1, IssueType.CodeComment, codeLines[i].Trim() ) );
//                            }
//                        }
//                    }

//                    if (checkCondition.CheckMagicStrings)
//                    {
//                        if (codeLines[i].Contains( "== \"" ) || codeLines[i].Contains( "== '" ))
//                        {
//                            issues.Add( new Issue( filePath, i + 1, IssueType.MagicString, codeLines[i].Trim() ) );
//                        }
//                    }

//                    if (checkCondition.CheckBadComparison)
//                    {
//                        if (codeLines[i].Contains( "true : false" ) || codeLines[i].Contains( "false : true" ) || codeLines[i].Contains( "== true" ) || codeLines[i].Contains( "== false" ) || codeLines[i].Contains( "!= true" ) || codeLines[i].Contains( "!= false" ))
//                        {
//                            issues.Add( new Issue( filePath, i + 1, IssueType.BadComparison, codeLines[i].Trim() ) );
//                        }
//                    }

//                    if (checkCondition.CheckBadComparison)
//                    {
//                        if (codeLines[i].Contains( "==" ))
//                        {
//                            string tempLine = codeLines[i].Replace( "==", "chkQuot" );

//                            if (!tempLine.Contains( "chkQuot=" ))
//                            {
//                                issues.Add( new Issue( filePath, i + 1, IssueType.BadComparison, codeLines[i].Trim() ) );
//                            }
//                        }
//                    }

//                    if (checkCondition.CheckWrongMethodCalls)
//                    {
//                        if (codeLines[i].Contains( "parseInt" ) && !codeLines[i].Contains( "10" ))
//                        {
//                            issues.Add( new Issue( filePath, i + 1, IssueType.WrongMethodCall, codeLines[i].Trim() ) );
//                        }
//                    }

//                    if (checkCondition.CheckDirectElementReferences)
//                    {
//                        if (codeLines[i].Contains( "document.getElementById" ) || codeLines[i].Contains( "document.all" ) || codeLines[i].Contains( "document.getElementsByTagName" ))
//                        {
//                            issues.Add( new Issue( filePath, i + 1, IssueType.DirectElementReference, codeLines[i].Trim() ) );
//                        }
//                    }


//                }
//            }


//            #endregion

//            return issues;
//        }

//        public static string GetIssueTypeString ( IssueType issueType )
//        {
//            switch (issueType)
//            {
//                case IssueType.BadComparison:
//                    return "Bad Comparison";
//                case IssueType.CodeComment:
//                    return "Potential Commented Code";
//                case IssueType.InlineHtml:
//                    return "Potential Inline HTML script";
//                case IssueType.MagicString:
//                    return "Magic String";
//                case IssueType.Todo:
//                    return "Unfinished TODO";
//                case IssueType.ObsoleteMethodOrClass:
//                    return "Obsolete Method or Class";
//                case IssueType.WrongCodeFormat:
//                    return "Wrong Code Format";
//                case IssueType.IncompleteSummaryComment:
//                    return "Incomplete Summary Comment";
//                case IssueType.ValueComparison:
//                    return "Value Comparison";
//                case IssueType.StringConcatenation:
//                    return "String Concatenation";
//                case IssueType.EmptyString:
//                    return "Empty String";
//                case IssueType.RelativePath:
//                    return "Relative Path";
//                case IssueType.TypeInfoHardCoded:
//                    return "Type Info Hard Coded";
//                case IssueType.WrongMethodCall:
//                    return "Wrong Method Call";
//                case IssueType.DirectElementReference:
//                    return "Direct Element Reference";

//                default:
//                    return "Unrecognized issue";
//            }
//        }

//        public static string GetIssueGuidelines ( IssueType issueType )
//        {
//            string guideText;

//            switch (issueType)
//            {
//                case IssueType.BadComparison:
//                    guideText = "Verify whether you are using an unwanted check for true or false values;\n";
//                    guideText += "or the usage of ternary operator in a wrong context.";
//                    return guideText;

//                case IssueType.CodeComment:
//                    guideText = "It is a bad practice to check-in commented code to a source control repository. Alternatively, this line could be a genuine comment.\n";
//                    guideText += "If it is commented code, please remove it. ";

//                    return guideText;

//                case IssueType.InlineHtml:
//                    guideText = "This line seems to contain inline HTML tags.\n";
//                    guideText += "Move all HTML tags to configuration and use them";
//                    return guideText;

//                case IssueType.MagicString:
//                    guideText = "This line contains a string comparison within double quotes.\n";
//                    guideText = "If this is a check for an empty string, use stringValue.Length==0, which is the efficient way to check\n";
//                    guideText += "Please refactor it to use enumerations in case of checking business logic.\n";
//                    guideText += "In case of genuine comparisons, use String.Equals.\nIn case of empty string check, use stringValue.Length==0";
//                    return guideText;

//                case IssueType.Todo:
//                    guideText = "This line seems to have an unfinished todo mark. If the work is finished, please remove the todo mark\n";
//                    guideText += "If unfinished Todo, finish the work and remove the Todo from this place.";
//                    return guideText;

//                case IssueType.ObsoleteMethodOrClass:
//                    guideText = "Usage of an obsolete method or class name found. Please use the recommended alternative.\n";
//                    guideText += "For example, instead of ConfigurationSettings, use ConfigurationManager.\n";
//                    guideText += "In case the application already contains a common method implementation for this usage, please reuse it.\n";
//                    return guideText;

//                case IssueType.WrongCodeFormat:
//                    guideText = "Wrongly formatted or indented code found.\n";
//                    guideText += "Ensure that all conditional and looping constructs have braces put as the only character in next line.\n";
//                    guideText += "Also ensure that open braces are not placed within the same line of the conditional or looping construct.";
//                    return guideText;

//                case IssueType.IncompleteSummaryComment:
//                    guideText = "The summary comments in this line are incomplete\n";
//                    guideText += "Add valid and meaningful comments to all parameters/arguments of a method or constructor";
//                    return guideText;

//                case IssueType.ValueComparison:
//                    guideText = "There seems to be a potential value comparison that involves business logic in this line.\n";
//                    guideText += "Please refactor to an appropriate alternative like enumerations.\n";
//                    guideText += "If it is a valid comparison, get it reviewed and approved from your reviewer.";
//                    return guideText;

//                case IssueType.StringConcatenation:
//                    guideText = "This line contains string concatenation. Check whether better alternatives can be provided.\n";
//                    guideText += "In case of file paths or urls, use Path.Combine or UriBuilder. To join strings with delimiter, use String.Join\n";
//                    guideText += "In case of using large strings with multiple concatenations, use StringBuilder.";
//                    return guideText;

//                case IssueType.EmptyString:
//                    guideText = "This line of code uses empty string.\nPlease use an alternative such as String.Empty for assignment. Use stringValue.Length==0 for conditions";
//                    return guideText;

//                case IssueType.RelativePath:
//                    guideText = "Relative path or URL reference usage found.\n";
//                    guideText += "Please use an alternative such as UriBuilder or Path.Combine";
//                    return guideText;

//                case IssueType.TypeInfoHardCoded:
//                    guideText = "Hardcoded type information found in this line, which cannot be verified in compile time.\n";
//                    guideText += "Choose an alternative method. For example, use typeOf(string) instead of \"System.String\"";
//                    return guideText;

//                case IssueType.WrongMethodCall:
//                    guideText = "A method is called less efficiently when better alternatives exist.\n";
//                    guideText += "This especially occurs when parseInt in Javascript is called without the radix argument";
//                    return guideText;

//                case IssueType.DirectElementReference:
//                    guideText = "An element is referred directly in Javascript.\n";
//                    guideText += "Use jQuery options";
//                    return guideText;

//                default:
//                    return "Unrecognized issue";
//            }
//        }

//        //public static string GetExtensionForAnalysisType ( AnalysisFileType fileType )
//        //{
//        //    //switch (fileType)
//        //    //{
//        //    //    case AnalysisFileType.AspNetPageSource:
//        //    //        return "*.aspx, *.ascx";

//        //    //    case AnalysisFileType.CSharp:
//        //    //        return "*.cs";

//        //    //    case AnalysisFileType.Javascript:
//        //    //        return "*.js";

//        //    //    default:
//        //    //        return "Unrecognized type";
//        //    //}
//        //}

//        //public static AnalysisFileType GetAnalysisTypeFromExtension ( string extension )
//        //{
//        //    switch (extension.ToLower())
//        //    {
//        //        case "*.cs":
//        //            return AnalysisFileType.CSharp;
//        //        case "*.js":
//        //            return AnalysisFileType.Javascript;
//        //        case "*.aspx, *.ascx":
//        //            return AnalysisFileType.AspNetPageSource;
//        //        default:
//        //            throw new NotSupportedException( "The given extension is not supported" );
//        //    }
//        //}
//    }
//}
