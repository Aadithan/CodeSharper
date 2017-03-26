using NUnit.Framework;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class MagicNumberSpecificationTests
    {
        [Test]
        public void MagicNumberTestNormal01()
        {
            const string codeLine = "if (numberOfObjects == 5)";
            var specification = new MagicNumberSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void MagicNumberTestNormal02()
        {
            const string codeLine = "if (numberOfObjects >= 5)";
            var specification = new MagicNumberSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void MagicNumberTestNormal03()
        {
            const string codeLine = "if (numberOfObjects > 5)";
            var specification = new MagicNumberSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void MagicNumberTestNormal04()
        {
            const string codeLine = "if (5 >= numberOfObjects)";
            var specification = new MagicNumberSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void MagicNumberTestNormal05()
        {
            const string codeLine = "if (5 != numberOfObjects)";
            var specification = new MagicNumberSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }
    }
}
