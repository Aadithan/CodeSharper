using CodeSharper.UI.Analyzer.Rules.CSharp;
using NUnit.Framework;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class ContainsKeywordSpecificationTests
    {
        [Test]
        public void ContainsKeywordTestWithKeywordAtBeginning()
        {
            const string codeLine = "if (number > 0)";
            var specification = new ContainsKeywordSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void ContainsKeywordTestWithKeywordAtEnd()
        {
            const string codeLine = "object x = new";
            var specification = new ContainsKeywordSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void ContainsKeywordTestWithKeywordAtMiddle()
        {
            const string codeLine = "component = new Component();";
            var specification = new ContainsKeywordSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        /// <summary>
        /// Test to ensure that a normal comment with words such as "is" are not detected as valid code
        /// </summary>
        [Test]
        public void ContainsKeywordTestWithExcludedKeyword()
        {
            const string codeLine = "This is a code with excluded keyword";
            var specification = new ContainsKeywordSpecification();
            Assert.That(!specification.IsSatisfiedBy(codeLine));
        }

        /// <summary>
        /// Test to ensure that code with excluded keyword and inluded keyword when combined are detected as valid code
        /// </summary>
        [Test]
        public void ContainsKeywordTestWithExcludedAndIncludedKeywords()
        {
            const string codeLine = "var employee = person as Employee";
            var specification = new ContainsKeywordSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }





    }
}
