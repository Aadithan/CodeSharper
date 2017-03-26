
using CodeSharper.UI.Analyzer.Rules.CSharp;
using NUnit.Framework;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class BadComparisonSpecificationTests
    {
        [Test]
        public void BadComparisonNormalConditionTrueTest()
        {
            const string codeLine = "if(IsValid == true)";
            var specification = new BadComparisonSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void BadComparisonNormalConditionFalseTest()
        {
            const string codeLine = "if(IsValid == false)";
            var specification = new BadComparisonSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void BadComparisonNormalConditionNotTrueTest()
        {
            const string codeLine = "if(IsValid != true)";
            var specification = new BadComparisonSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void BadComparisonNormalConditionNotFalseTest()
        {
            const string codeLine = "if(IsValid != false)";
            var specification = new BadComparisonSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void BadComparisonNormalConditionTernaryTrueFalseTest()
        {
            const string codeLine = "(a > b) ? true:false";
            var specification = new BadComparisonSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void BadComparisonNormalConditionTernaryFalseTrueTest()
        {
            const string codeLine = "(a > b) ? false:true";
            var specification = new BadComparisonSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

    }
}
