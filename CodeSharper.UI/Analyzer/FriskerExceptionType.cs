
namespace CodeSharper.UI.Analyzer
{
    /// <summary>
    /// Enumeration that contains list of all errors that would occur in Code Frisker
    /// </summary>
    public enum FriskerExceptionType
    {
        /// <summary>
        /// The application encountered a fatal error, from which it could not recover
        /// </summary>
        Fatal = 0,

        /// <summary>
        /// Access denied for the user to read content from the specified folder
        /// </summary>
        AccessDeniedRead = 1,

        /// <summary>
        /// Access denied for the user to write content to the specified folder
        /// </summary>
        AccessDeniedWrite = 2,

        /// <summary>
        /// The folder specified does not exist
        /// </summary>
        FolderDoesNotExist = 3,

        /// <summary>
        /// Unauthorized access to folder or its contents
        /// </summary>
        UnauthorizedAccess = 4,

        /// <summary>
        /// Given path exceeds the limit of characters in length
        /// </summary>
        PathTooLong = 5,

        /// <summary>
        /// The exclusions file could not be loaded
        /// </summary>
        ExclusionsNotFound = 6
    }
}
