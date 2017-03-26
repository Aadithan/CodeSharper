using NUnit.Framework;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class UnfinishedTodoSpecificationTests
    {
        [Test]
        public void UnfinishedTodoTestNormal01()
        {
            const string codeLine = "//Todo: Need to do more work here";
            var specification = new UnfinishedTodoSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void UnfinishedTodoTestNormal02()
        {
            const string codeLine = "//TODO: Need to do more work here";
            var specification = new UnfinishedTodoSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void UnfinishedTodoTestNormal03()
        {
            const string codeLine = "//(TODO): Need to do more work here";
            var specification = new UnfinishedTodoSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void UnfinishedTodoTestNormal04()
        {
            const string codeLine = "//(todo): Need to do more work here";
            var specification = new UnfinishedTodoSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }
    }
}
