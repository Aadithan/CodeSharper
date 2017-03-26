using NUnit.Framework;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class SummaryCommentSpecificationTests
    {
        [Test]
        public void SummaryCommentTestNormal01()
        {
            const string codeLine = "///<param></param>";
            var specification = new SummaryCommentSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void SummaryCommentTestNormal02()
        {
            const string codeLine = "////This is a genuine comment";
            var specification = new SummaryCommentSpecification();
            Assert.That(!specification.IsSatisfiedBy(codeLine));
        }
    }
}
