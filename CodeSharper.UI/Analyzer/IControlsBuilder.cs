
using System.Collections.Generic;
using CodeSharper.UI.Analyzer.Engine;
using CodeSharper.UI.Controls;

namespace CodeSharper.UI.Analyzer
{

    /// <summary>
    /// Interface that is used to create ControlBuilders at runtime
    /// </summary>
    public interface IControlsBuilder
    {
        /// <summary>
        /// Method that should be used to build and return condition controls for the specified code analysis
        /// </summary>
        /// <returns>List of condition check boxes to be rendered for code analysis</returns>
        List<ConditionCheckBox> GetConditionControls();
    }
}
