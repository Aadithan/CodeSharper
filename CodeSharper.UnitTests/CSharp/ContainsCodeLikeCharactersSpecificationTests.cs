
using NUnit.Framework;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class ContainsCodeLikeCharactersSpecificationTests
    {
        [Test]
        public void ContainsCodeLikeCharsTestNormal01()
        {
            const string codeLine = "abcd (covered in parantheses)";
            var specification = new ContainsCodeLikeCharacterSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void ContainsCodeLikeCharsTestNormal02()
        {
            const string codeLine = "content ended with semicolon;";
            var specification = new ContainsCodeLikeCharacterSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }
    }
}
