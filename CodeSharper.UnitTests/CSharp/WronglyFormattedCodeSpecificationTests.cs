using NUnit.Framework;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class WronglyFormattedCodeSpecificationTests
    {
        [Test]
        public void WronglyFormattedCodeTestNormal01()
        {
            string[] codeLines = { "if (x > 5)", "return true" };
            var specification = new WronglyFormattedCodeSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLines));
        }

        [Test]
        public void WronglyFormattedCodeTestNormal02()
        {
            string[] codeLines = { "if (x > 5)", "return true;" };
            var specification = new WronglyFormattedCodeSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLines));
        }
    }
}
