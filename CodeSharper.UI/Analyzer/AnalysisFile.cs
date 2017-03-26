
namespace CodeSharper.UI.Analyzer
{
    /// <summary>
    /// Class that contains details of all types of files that would be analysed using code frisker
    /// </summary>
    public class AnalysisFile
    {
        /// <summary>
        /// The type of file used for analysis
        /// </summary>
        public AnalysisFileType FileType { get; set; }

        /// <summary>
        /// Flag to mark the type as default in UI controls
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// A string that represents the extension of the file type
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Creates an instance of AnalysisFile. Default constructor.
        /// </summary>
        public AnalysisFile()
        {
            
        }

        /// <summary>
        /// Creates an instance of AnalysisFile
        /// </summary>
        /// <param name="fileType">The file type associated</param>
        /// <param name="isDefault">Specifies whether the file type is default in UI controls</param>
        /// <param name="extension">Extension associated with the file type</param>
        public AnalysisFile(AnalysisFileType fileType, bool isDefault, string extension)
        {
            FileType = fileType;
            IsDefault = isDefault;
            Extension = extension;
        }

        public override string ToString()
        {
            return ApplicationConstants.AnalysisFileTypeStrings[this.FileType];
        }

    }
}
