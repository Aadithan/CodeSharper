using NUnit.Framework;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class RelativePathSpecificationTests
    {
        [Test]
        public void RelativePathTestNormal01()
        {
            const string codeLine = "imagePath = \"..\\..\\abc.jpg";
            var specification = new RelativePathSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void RelativePathTestNormal02()
        {
            const string codeLine = "imagePath = \"../../abc.jpg";
            var specification = new RelativePathSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }
    }
}