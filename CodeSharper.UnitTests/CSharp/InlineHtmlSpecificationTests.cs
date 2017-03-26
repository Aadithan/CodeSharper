
using CodeSharper.UI.Analyzer.Rules.CSharp;
using NUnit.Framework;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class InlineHtmlSpecificationTests
    {
        [Test]
        public void InlineHtmlTestNormal()
        {
            const string codeLine = "\"<div>";
            var specification = new InlineHtmlSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void InlineHtmlTestExclusion01()
        {
            const string codeLine = "///<param></param>";
            var specification = new InlineHtmlSpecification();
            Assert.That(!specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void InlineHtmlTestExclusion02()
        {
            const string codeLine = "if (x <= 5)";
            var specification = new InlineHtmlSpecification();
            Assert.That(!specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void InlineHtmlTestExclusion03()
        {
            const string codeLine = "if (x < 5)";
            var specification = new InlineHtmlSpecification();
            Assert.That(!specification.IsSatisfiedBy(codeLine));
        }
    }
}
