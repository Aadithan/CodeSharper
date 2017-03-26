using NUnit.Framework;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class StartsWithAccessSpecifierSpecificationTests
    {
        [Test]
        public void StartsWithAccessSpeficierNormal01()
        {
            const string codeLine = "public class";
            var specification = new StartsWithAccessSpecifierSpecification();
            specification.IsSatisfiedBy(codeLine);
        }

        [Test]
        public void StartsWithAccessSpeficierNormal02()
        {
            const string codeLine = "internal class";
            var specification = new StartsWithAccessSpecifierSpecification();
            specification.IsSatisfiedBy(codeLine);
        }

        [Test]
        public void StartsWithAccessSpeficierNormal03()
        {
            const string codeLine = "private int";
            var specification = new StartsWithAccessSpecifierSpecification();
            specification.IsSatisfiedBy(codeLine);
        }

        [Test]
        public void StartsWithAccessSpeficierNormal04()
        {
            const string codeLine = "protected int";
            var specification = new StartsWithAccessSpecifierSpecification();
            specification.IsSatisfiedBy(codeLine);
        }
    }
}
