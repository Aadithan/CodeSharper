
using NUnit.Framework;
using CodeSharper.UI.Analyzer.Rules.CSharp;

namespace CodeSharper.UnitTests.CSharp
{
    [TestFixture]
    public class CommentedCodepecificationTests
    {
        [Test]
        public void CommentedCodeStraightForward()
        {
            const string codeLine = "//for (var i=0; i < collection.Count; i++)";
            var specification = new CommentedCodeSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void CommentedCodeMultiLineStart()
        {
            const string codeLine = "/*for (var i=0; i < collection.Count; i++)";
            var specification = new CommentedCodeSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void CommentedCodeMultiLineEnd()
        {
            const string codeLine = "for (var i=0; i < collection.Count; i++)*/";
            var specification = new CommentedCodeSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void CommentedCodeGenuineComment()
        {
            const string codeLine = "//This is a genuine comment";
            var specification = new CommentedCodeSpecification();
            Assert.That(!specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void CommentedCodeSuspect01()
        {
            const string codeLine = "//Code (like) pattern; ";
            var specification = new CommentedCodeSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void CommentedCodeSuspect02()
        {
            const string codeLine = "//Code [like] pattern; ";
            var specification = new CommentedCodeSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void CommentedCodeSuspect03()
        {
            const string codeLine = "//Code like pattern with volatile keyword ";
            var specification = new CommentedCodeSpecification();
            Assert.That(specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void CommentedCodeSuspect04()
        {
            const string codeLine = "//Code like pattern with excluded keyword as ";
            var specification = new CommentedCodeSpecification();
            Assert.That(!specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void CommentedCodeSuspect05()
        {
            const string codeLine = "//Code like pattern with excluded keyword in ";
            var specification = new CommentedCodeSpecification();
            Assert.That(!specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void CommentedCodeSuspect06()
        {
            const string codeLine = "//Code like pattern with excluded keyword is ";
            var specification = new CommentedCodeSpecification();
            Assert.That(!specification.IsSatisfiedBy(codeLine));
        }

        [Test]
        public void CommentedCodeSuspect07()
        {
            const string codeLine = "//Temporary variable to be used in predicate ";
            var specification = new CommentedCodeSpecification();
            Assert.That(!specification.IsSatisfiedBy(codeLine));
        }
    }
}
