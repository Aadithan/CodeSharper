using System.Windows.Forms;
using CodeSharper.UI.Analyzer.Engine;

namespace CodeSharper.UI.Controls
{
    /// <summary>
    /// Class that should be used to create all check boxes for the check conditions
    /// </summary>
    public class ConditionCheckBox
    {
        /// <summary>
        /// The CheckBox control associated with the condition
        /// </summary>
        public CheckBox CheckBox { get; set; }

        /// <summary>
        /// The type of issue associated with the condition check
        /// </summary>
        public IssueType IssueType { get; set; }

        /// <summary>
        /// The position in which the CheckBox should appear in display
        /// </summary>
        public int OrdinalPosition { get; set; }

        /// <summary>
        /// Creates a new instance of ConditionCheckBox and instatiates a new CheckBox required.
        /// </summary>
        public ConditionCheckBox()
        {
            CheckBox = new CheckBox();
        }

        /// <summary>
        /// Creates a new instance of ConditionCheckBox
        /// </summary>
        /// <param name="issueType">The issue type associated with the control</param>
        /// <param name="isEnabled">Flag to determine whether the CheckBox is enabled or disabled by default. By default, the CheckBox is disabled</param>
        public ConditionCheckBox(IssueType issueType, bool isEnabled)
        {
            IssueType = issueType;
            CheckBox.Enabled = isEnabled;
        }

        /// <summary>
        /// Creates a new instance of ConditionCheckBox
        /// </summary>
        /// <param name="issueType">The issue type associated with the control</param>
        /// <param name="isEnabled">Flag to determine whether the CheckBox is enabled or disabled by default. By default, the CheckBox is disabled</param>
        /// <param name="ordinalPosition">The order in which the CheckBox should get displayed in the screen</param>
        public ConditionCheckBox(IssueType issueType, bool isEnabled, int ordinalPosition)
        {
            CheckBox= new CheckBox();
            IssueType = issueType;
            CheckBox.Enabled = isEnabled;
            OrdinalPosition = ordinalPosition;
        }

    }
}
