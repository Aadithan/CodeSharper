using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSharper.UI.Analyzer
{
    internal class JavaScriptCheckCondition: CheckConditions
    {
        public bool CheckMagicStrings = false;
        public bool CheckWrongMethodCalls = false;
        public bool CheckBadComparison = false;
        public bool CheckDirectElementReferences = false;
    }
}
