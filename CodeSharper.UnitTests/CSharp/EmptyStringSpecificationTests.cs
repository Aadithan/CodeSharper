using NUnit.Framework;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class EmptyStringSpecificationTests
    {

        [Test]
        public void EmptyStringSpecificationTestNormal()
        {
            const string codeLine = "stringValue = \"\"";
            var specification = new EmptyStringSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void EmptyStringSpecificationLogicalCheck01()
        {
            const string codeLine = "stringValue == string.Empty";
            var specification = new EmptyStringSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void EmptyStringSpecificationLogicalCheck02()
        {
            const string codeLine = "stringValue == String.Empty";
            var specification = new EmptyStringSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void EmptyStringSpecificationLogicalCheck03()
        {
            const string codeLine = "String.Empty == stringValue";
            var specification = new EmptyStringSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }
        
        [Test]
        public void EmptyStringSpecificationLogicalCheck04()
        {
            const string codeLine = "string.Empty == stringValue";
            var specification = new EmptyStringSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }
    }
}
