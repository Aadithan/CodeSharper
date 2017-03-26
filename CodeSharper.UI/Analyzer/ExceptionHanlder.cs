
using System;

namespace CodeSharper.UI.Analyzer
{
    /// <summary>
    /// Class that handles exceptions in Code Frisker
    /// </summary>
    public class ExceptionHanlder
    {
        /// <summary>
        /// Method that handles all exceptions in Code Frisker
        /// </summary>
        /// <param name="exception">The exception that needs to be handled</param>
        public static void HandleFriskerException(FriskerException exception)
        {
            switch (exception.ExceptionType)
            {
                case FriskerExceptionType.Fatal:
                    UiHelper.ShowExclamationMessageBox(ApplicationConstants.FatalErrorMessage, ApplicationConstants.ErrorMessageTitle);
                    throw new ApplicationException("Fatal error occurred in Code Frisker and needs to close", exception);
                case FriskerExceptionType.AccessDeniedRead:
                    UiHelper.ShowExclamationMessageBox(ApplicationConstants.AccessDeniedReadMessage, ApplicationConstants.ErrorMessageTitle);
                    break;
                case FriskerExceptionType.AccessDeniedWrite:
                    UiHelper.ShowExclamationMessageBox(ApplicationConstants.AccessDeniedWriteMessage, ApplicationConstants.ErrorMessageTitle);
                    break;
                case FriskerExceptionType.FolderDoesNotExist:
                    UiHelper.ShowExclamationMessageBox(ApplicationConstants.FolderDoesNotExistMessage, ApplicationConstants.ErrorMessageTitle);
                    break;
                case FriskerExceptionType.PathTooLong:
                    UiHelper.ShowExclamationMessageBox(ApplicationConstants.PathTooLongMessage, ApplicationConstants.ErrorMessageTitle);
                    break;
                case FriskerExceptionType.UnauthorizedAccess:
                    UiHelper.ShowExclamationMessageBox(ApplicationConstants.UnauthorizedAccessMessage, ApplicationConstants.ErrorMessageTitle);
                    break;
                case FriskerExceptionType.ExclusionsNotFound:
                    UiHelper.ShowErrorMessageBox(ApplicationConstants.ExclusionsFileNotFoundMessage, ApplicationConstants.ApplicationTitle);
                    break;
                default:
                    throw new NotImplementedException("Unhandled Exception Type in Code Frisker");
            }
        }

    }
}
