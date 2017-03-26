// -------------------------------------------------------------------------------------------------------------------------
// Extended styles for the default ListView control of the Framework Control Library
// This enumeration is part of code that makes the report ListView non-flickering.
// Solution provided by Brian Gillespie as posted by Jonas in stackoverflow
// http://stackoverflow.com/questions/87795/how-to-prevent-flickering-in-listview-when-updating-a-single-listviewitems-text
// -------------------------------------------------------------------------------------------------------------------------

namespace CodeSharper.UI.ListViewExtensions
{
    public enum ListViewMessages
    {
        First = 0x1000,
        SetExtendedStyle = (First + 54),
        GetExtendedStyle = (First + 55)
    }
}
