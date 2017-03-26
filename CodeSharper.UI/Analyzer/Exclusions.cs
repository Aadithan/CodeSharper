
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace CodeSharper.UI.Analyzer
{

    /// <summary>
    /// Class that handles files, extensions and contents that need to be excluded from analysis
    /// </summary>
    public class Exclusions
    {
        public List<string> FileExclusions { get; set; }
        public List<string> ExtensionExclusions { get; set; }
        public List<string> ContentExclusions { get; set; }

        /// <summary>
        /// Load Exclusions for the application
        /// </summary>
        public Exclusions()
        {
            var doc = new XmlDocument();
            try
            {
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                if (path != null)
                {
                    string filePath = path.EndsWith(ApplicationConstants.PathDelimiter) ?
                        String.Concat(path, ApplicationConstants.ExclusionsFileName) :
                        String.Concat(path, ApplicationConstants.PathDelimiter, ApplicationConstants.ExclusionsFileName);

                    filePath = filePath.Replace(ApplicationConstants.FileUriPrefix, string.Empty);
                    string xmlContent = File.ReadAllText(filePath);
                    doc.LoadXml(xmlContent);
                    XmlNode fileNodeMain = doc.SelectSingleNode(ApplicationConstants.FileExclusionsNodeText);
                    XmlNode extensionNodeMain = doc.SelectSingleNode(ApplicationConstants.ExtensionExclusionsNodeText);
                    XmlNode contentNodeMain = doc.SelectSingleNode(ApplicationConstants.ContentExclusionsNodeText);

                    FileExclusions = fileNodeMain ==null  ? null : GetFileExclusions(fileNodeMain.ChildNodes);
                    ExtensionExclusions = extensionNodeMain == null ? null : GetExtensionExclusions(extensionNodeMain.ChildNodes);
                    ContentExclusions = contentNodeMain == null ? null : GetContentExclusions(contentNodeMain.ChildNodes);
                }
            }
            catch (PathTooLongException exception)
            {
                ExceptionHanlder.HandleFriskerException(new FriskerException(ApplicationConstants.FriskerExceptionMessage, exception, FriskerExceptionType.PathTooLong));
            }
            catch(FileNotFoundException exception)
            {
                ExceptionHanlder.HandleFriskerException(new FriskerException(ApplicationConstants.FriskerExceptionMessage, exception, FriskerExceptionType.ExclusionsNotFound));
            }

        }

        /// <summary>
        /// Get File Exclusions from the selected xml nodes
        /// </summary>
        /// <param name="fileNodes">Source xml nodes</param>
        /// <returns>List of file exclusions in string format</returns>
        public List<string> GetFileExclusions(XmlNodeList fileNodes)
        {
            var fileExceptions = new List<string>();

            foreach (XmlNode file in fileNodes)
            {
                if (file.Attributes != null)
                {
                    fileExceptions.Add(file.Attributes[ApplicationConstants.ValueAttributeName].Value);
                }
            }
            return fileExceptions;
        }

        /// <summary>
        /// Get Extension Exclusions from the selected xml nodes
        /// </summary>
        /// <param name="extensionNodes">Source xml nodes</param>
        /// <returns>List of file exclusions in string format</returns>
        public List<string> GetExtensionExclusions(XmlNodeList extensionNodes)
        {
            var extensionExceptions = new List<string>();

            foreach (XmlNode extension in extensionNodes)
            {
                if (extension.Attributes != null)
                {
                    extensionExceptions.Add(extension.Attributes[ApplicationConstants.ValueAttributeName].Value);
                }
            }
            return extensionExceptions;
        }

        /// <summary>
        /// Get Content Exclusions from the selected xml nodes
        /// </summary>
        /// <param name="contentNodes">Source xml nodes</param>
        /// <returns>List of file exclusions in string format</returns>
        public List<string> GetContentExclusions(XmlNodeList contentNodes)
        {
            var contentExceptions = new List<string>();

            foreach (XmlNode content in contentNodes)
            {
                if (content.Attributes != null)
                {
                    contentExceptions.Add(content.Attributes[ApplicationConstants.ValueAttributeName].Value);
                }
            }
            return contentExceptions;
        }

    }
}
