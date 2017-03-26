using NUnit.Framework;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class HardcodedTypeSpecificationTests
    {
        [Test]
        public void HardcodedTypeTest()
        {
            const string codeLine = "typeof(\"System.string\")";
            var specification = new HardcodedTypeSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

    }
}
