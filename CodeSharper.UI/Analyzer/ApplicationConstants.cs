
using System.Collections.Generic;

namespace CodeSharper.UI.Analyzer
{
    public class ApplicationConstants
    {


        public static readonly Dictionary<AnalysisFileType, string> AnalysisFileTypeStrings = new Dictionary<AnalysisFileType, string>()
                                                                                                  {
                                                                                                      {AnalysisFileType.CSharp, "C# (*.cs)"}
                                                                                                  };
        public static readonly Dictionary<AnalysisFileType, string> AnalysisFileTypeExtensionStrings = new Dictionary<AnalysisFileType, string>()
                                                                                                  {
                                                                                                      {AnalysisFileType.CSharp, "*.cs"}
                                                                                                  };

        public const string ZeroLabel = "0";

        public const string NoItemsFoundToExport = "No items listed to export.";
        public const string ApplicationTitle = "Code Frisker";
        public const string ApplicationVersion = "2.0";
        public const string Space = " ";
        public const string ApplicationDevelopers = "";
        public const string ApplicationCompanyName = "";
        public const string CopyrightMessage = "";

        public const string CouldNotLaunchVisualStudioMessage = "Could not launch Visual Studio.";
        public const string CouldNotLocateFileMessage = "Could not locate file: ";

        public const string EasterEggMessage =
            "Code Frisker";

        public const string AboutFriskerMessage = "Code Frisker";
        public const string AboutFriskerTitle = "About Code Frisker";
        public const string AccessDeniedReadMessage = "You do not have read permissions on the specified folder.";
        public const string ErrorMessageTitle = "Error";
        public const string AccessDeniedWriteMessage = "You do not have write permissions on the specified folder.";
        public const string FolderDoesNotExistMessage = "The specified folder does not exist.";
        public const string FatalErrorMessage = "Code Frisker encountered a fatal error and therefore, needs to close.";
        public const string UnauthorizedAccessMessage = "Unauthorized access to a direcotry or file attempted.";
        public const string PathTooLongMessage = "The folder path is too long to process. Please ensure that fully qualified file paths are less than 260 characters in length.";
        public const string FriskerExceptionMessage = "Error accessing file or directory.";
        public const string LocationNotSpecifiedMessage = "Please select a valid location.";
        public const string ExclusionsFileName = "Exceptions.xml";
        public const string PathDelimiter = "\\";
        public const string FileUriPrefix = "file:\\";
        public const string FileExclusionsNodeText = "exceptions/fileExceptions";
        public const string ExtensionExclusionsNodeText = "exceptions/extensionExceptions";
        public const string ContentExclusionsNodeText = "exceptions/contentExceptions";
        public const string ValueAttributeName = "value";
        public const string StatusLoadingFiles = "Loading files for analysis. Please wait...";
        public const string StatusAnalyzingFile = "Analyzing file ";
        public const string StatusComplete = "Analysis complete.";
        public const string NoOptionSelectedMessage = "Please select at least one option for analysis.";
        public const string NoOptionSelectedTitle = "No option selected";

        public const string FileExportFilter = "Tab delimited files (*.xls)|*.xls";
        public const string FileExportTitle = "Save Results";
        public const string FileExportErrorMessage = "Error occurred while exporting contents: ";
        public const string FileExportErrorTitle = "Error exporting results";
        public const string NoItemSelectedMessage = "No item selected";
        public const string ErrorOpeningItemMessage = "Opening the item in Visual Studio encountered an error: ";

        public const string ExclusionsFileNotFoundMessage = "The file \"Exceptions.xml\" could not be loaded. Please ensure that the file exists in the Code Frisker application's root directory.";

    }
}
