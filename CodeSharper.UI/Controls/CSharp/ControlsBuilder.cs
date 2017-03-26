
using System.Collections.Generic;
using CodeSharper.UI.Analyzer;
using CodeSharper.UI.Analyzer.Engine;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UI.Controls.CSharp
{
    /// <summary>
    /// Class to build crontrols required for CSharp code analysis
    /// </summary>
    public class ControlsBuilder : IControlsBuilder
    {
        /// <summary>
        /// Get all condition check boxes for CSharp code analysis
        /// </summary>
        /// <returns>List containing all check boxes required for CSharp analysis</returns>
        public List<ConditionCheckBox> GetConditionControls()
        {
            var conditionCheckBoxes = new List<ConditionCheckBox>
                                          {
                                              new ConditionCheckBox(IssueType.CodeComment, true, 0), 
                                              new ConditionCheckBox(IssueType.MagicString, true, 1), 
                                              new ConditionCheckBox(IssueType.BadComparison, true, 2),
                                              new ConditionCheckBox(IssueType.ObsoleteMethodOrClass, true, 3),
                                              new ConditionCheckBox(IssueType.Todo, true, 4),
                                              new ConditionCheckBox(IssueType.WrongCodeFormat, true, 5),
                                              new ConditionCheckBox(IssueType.InlineHtml, true, 6),
                                              new ConditionCheckBox(IssueType.IncompleteSummaryComment, true, 7),
                                              new ConditionCheckBox(IssueType.ValueComparison, true, 8),
                                              new ConditionCheckBox(IssueType.StringConcatenation, true, 9),
                                              new ConditionCheckBox(IssueType.EmptyString, true, 10),
                                              new ConditionCheckBox(IssueType.RelativePath, true, 11),
                                              new ConditionCheckBox(IssueType.TypeInfoHardCoded, true, 12)
                                          };

            foreach (var conditionCheckBox in conditionCheckBoxes)
            {
                conditionCheckBox.CheckBox.Text = Constants.IssueTypeStrings[conditionCheckBox.IssueType];
                conditionCheckBox.CheckBox.Tag = conditionCheckBox.IssueType;
            }
            return conditionCheckBoxes;
        }
    }
}
