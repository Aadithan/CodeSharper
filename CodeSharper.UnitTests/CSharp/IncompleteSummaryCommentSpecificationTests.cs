using NUnit.Framework;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class IncompleteSummaryCommentSpecificationTests
    {
        [Test]
        public void IncompleteSummaryCommentTestNormal()
        {
            const string codeLine = "/// <returns></returns>";
            var specification = new IncompleteSummaryCommentSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void IncompleteSummaryCommentTestValidContent()
        {
            const string codeLine = "<div></div>";
            var specification = new IncompleteSummaryCommentSpecification();
            Assert.That(!specification.IsSatisfiedBy(codeLine));
        }
    }
}
