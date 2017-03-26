
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CodeSharper.UI.Controls
{
    /// <summary>
    /// Helper class to manage the controls required for every code analysis done using CodeSharper
    /// </summary>
    public class ControlHelper
    {
        /// <summary>
        /// Add all condition check boxes to the group box
        /// </summary>
        /// <param name="groupBox">The group box to which the check boxes should be added</param>
        /// <param name="checkBoxes">The sorted list of checkboxes</param>
        public static void RenderCheckBoxes(GroupBox groupBox, List<ConditionCheckBox> checkBoxes)
        {
            int rowCount = 1;
            int leftPos = 6;
            int topPos = 15;
            int increment = 0;
            foreach (var conditionCheckBox in checkBoxes)
            {
                CheckBox controlToAdd = conditionCheckBox.CheckBox;
                controlToAdd.Width = 172;
                controlToAdd.Left = leftPos;
                controlToAdd.Top = topPos;
                controlToAdd.TextAlign= ContentAlignment.MiddleLeft;
                leftPos += 175;
                increment++;

                if (increment % 4 == 0)
                {
                    topPos += 25;
                    leftPos = 6;
                    rowCount++;
                }
                groupBox.Controls.Add(controlToAdd);
            }
            int calcHeight = (rowCount*25) + 20;
            groupBox.Height = calcHeight;
            groupBox.Refresh();
        }
    }
}
