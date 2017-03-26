using NUnit.Framework;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class ObsoleteContentSpecificationTests
    {
        [Test]
        public void ObsoleteContentTestNormal01()
        {
            const string codeLine = "ConfigurationSettings.AppSettings[";
            var specification = new ObsoleteContentSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void ObsoleteContentTestNormal02()
        {
            const string codeLine = "using System.Web.Mail";
            var specification = new ObsoleteContentSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }
    }
}
