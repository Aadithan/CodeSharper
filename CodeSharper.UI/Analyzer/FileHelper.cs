
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeSharper.UI.Analyzer
{
    /// <summary>
    /// Helper class that contains methods related to file IO
    /// </summary>
    public class FileHelper
    {
        public List<string> FilesSelected { get; private set; }

        /// <summary>
        /// Creates an instance of FileHelper and initializes the list of files that would be selected;
        /// </summary>
        public FileHelper()
        {
            FilesSelected = new List<string>();
        }

        /// <summary>
        /// Method to get files that match the given extension from a directory recursively
        /// </summary>
        /// <param name="directory">The root directory to start with</param>
        /// <param name="extension">Extension of the file name</param>
        /// <returns>List of files with fully qualified directory path</returns>
        public List<string> GetMatchingFilesFromSubDirectories(string directory, string extension)
        {
            try
            {
                foreach (var subdirectory in Directory.GetDirectories(directory))
                {
                    FilesSelected.AddRange(Directory.GetFiles(subdirectory, extension));
                    GetMatchingFilesFromSubDirectories(subdirectory, extension);
                }
            }
            catch (PathTooLongException exception)
            {
                ExceptionHanlder.HandleFriskerException(new FriskerException(ApplicationConstants.FriskerExceptionMessage, exception, FriskerExceptionType.PathTooLong));
            }
            catch (DirectoryNotFoundException exception)
            {
                ExceptionHanlder.HandleFriskerException(new FriskerException(ApplicationConstants.FriskerExceptionMessage, exception, FriskerExceptionType.FolderDoesNotExist));
            }
            catch (IOException exception)
            {
                //Any exception that is not due to non-existent directory and long path is due to non-readable file or directory
                //Identified as read type since we are trying to read from the directory
                ExceptionHanlder.HandleFriskerException(new FriskerException(ApplicationConstants.FriskerExceptionMessage, exception, FriskerExceptionType.AccessDeniedRead));
            }
            catch (UnauthorizedAccessException exception)
            {
                ExceptionHanlder.HandleFriskerException(new FriskerException(ApplicationConstants.FriskerExceptionMessage, exception, FriskerExceptionType.UnauthorizedAccess));
            }
            catch (Exception exception)
            {
                //All exceptions except the specific ones are fatal
                ExceptionHanlder.HandleFriskerException(new FriskerException(ApplicationConstants.FriskerExceptionMessage, exception, FriskerExceptionType.Fatal));
            }
            return FilesSelected;
        }

        /// <summary>
        /// Method that gets files from a directory
        /// </summary>
        /// <param name="directory">The directory to look for the files</param>
        /// <param name="extension">Extension of the file name</param>
        /// <returns>List of files with fully qualified directory path</returns>
        public List<string> GetMatchingFilesFromDirectory(string directory, string extension)
        {
            var files = new List<string>();
            try
            {
                files.AddRange(Directory.GetFiles(directory, extension));

            }
            catch (PathTooLongException exception)
            {
                ExceptionHanlder.HandleFriskerException(new FriskerException(ApplicationConstants.FriskerExceptionMessage, exception, FriskerExceptionType.PathTooLong));
            }
            catch (DirectoryNotFoundException exception)
            {
                ExceptionHanlder.HandleFriskerException(new FriskerException(ApplicationConstants.FriskerExceptionMessage, exception, FriskerExceptionType.FolderDoesNotExist));
            }
            catch (IOException exception)
            {
                //Any exception that is not due to non-existent directory and long path is due to non-readable file or directory
                //Identified as read type since we are trying to read from the directory
                ExceptionHanlder.HandleFriskerException(new FriskerException(ApplicationConstants.FriskerExceptionMessage, exception, FriskerExceptionType.AccessDeniedRead));
            }
            catch (UnauthorizedAccessException exception)
            {
                ExceptionHanlder.HandleFriskerException(new FriskerException(ApplicationConstants.FriskerExceptionMessage, exception, FriskerExceptionType.UnauthorizedAccess));
            }
            catch (Exception exception)
            {
                //All exceptions except the specific ones are fatal
                ExceptionHanlder.HandleFriskerException(new FriskerException(ApplicationConstants.FriskerExceptionMessage, exception, FriskerExceptionType.Fatal));
            }
            return files;
        }

        /// <summary>
        /// Reads all lines of code into an array of strings for analysis
        /// </summary>
        /// <param name="filePath">The fully qualified file path</param>
        /// <returns>Lines of code as a string array</returns>
        public static string[] GetCodeLinesFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string fileContents = File.ReadAllText(filePath);
                string[] codeLines = fileContents.Split('\n');
                return codeLines;
            }
            return null;
        }

        /// <summary>
        /// Method that checks whether the file meets exclusions criteria
        /// </summary>
        /// <param name="filePath">The file name with fully qualified path</param>
        /// <param name="exclusions">The exclusions populated from the configuration</param>
        /// <returns>True if the file is excluded from analysis</returns>
        public static bool IsExcludedFile(string filePath, Exclusions exclusions)
        {
            string fileName = Path.GetFileName(filePath);

            if (exclusions != null && exclusions.FileExclusions != null && exclusions.ExtensionExclusions != null)
            {
                return exclusions.FileExclusions.Any(
                    file => fileName != null && fileName.Equals(file, StringComparison.OrdinalIgnoreCase))
                       ||
                       exclusions.ExtensionExclusions.Any(
                           extension =>
                           fileName != null && fileName.EndsWith(extension, StringComparison.OrdinalIgnoreCase));
            }
            return false;
        }

    }
}
