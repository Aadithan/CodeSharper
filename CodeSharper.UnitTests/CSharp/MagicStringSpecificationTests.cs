using NUnit.Framework;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class MagicStringSpecificationTests
    {
        [Test]
        public void MagicStringTestNormal01()
        {
            const string codeLine = "if (role == \"Manager\")";
            var specification = new MagicStringSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void MagicStringTestNormal02()
        {
            const string codeLine = "if (role != \"Manager\")";
            var specification = new MagicStringSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void MagicStringTestNormal03()
        {
            const string codeLine = "if (startChar != 'M')";
            var specification = new MagicStringSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void MagicStringTestNormal04()
        {
            const string codeLine = "if (startChar == 'M')";
            var specification = new MagicStringSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }
    }
}
