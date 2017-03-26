
using System;

namespace CodeSharper.UI.Analyzer
{
    /// <summary>
    /// Exception class to handle exceptions in Code Frisker
    /// </summary>
    public class FriskerException : ApplicationException
    {
        public FriskerExceptionType ExceptionType; 
        
        public FriskerException(string message, Exception innerException, FriskerExceptionType exceptionType)
            : base(message, innerException)
        {
            ExceptionType = exceptionType;
        }
    }
}
