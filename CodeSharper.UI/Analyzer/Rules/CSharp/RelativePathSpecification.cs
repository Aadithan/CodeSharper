﻿using System.Linq;
using CodeSharper.UI.Analyzer.Specifications;

namespace CodeSharper.UI.Analyzer.Rules.CSharp
{
    public class RelativePathSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string codeLine)
        {
            return Constants.RelativePathCharSet.Any(codeLine.Contains);
        }
    }
}
