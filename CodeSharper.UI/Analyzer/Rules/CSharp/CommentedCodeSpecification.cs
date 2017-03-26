using CodeSharper.UI.Analyzer.Specifications;

namespace CodeSharper.UI.Analyzer.Rules.CSharp
{
   public class CommentedCodeSpecification : Specification<string>
    {
       public override bool IsSatisfiedBy(string codeLine)
       {
           var summarySpec = new SummaryCommentSpecification();
           bool isSummaryComment = summarySpec.IsSatisfiedBy(codeLine);

           if (isSummaryComment)
           {
               return false;
           }

           var containsCommentSpec = new ContainsCommentSpecification();

           bool isCommentedLine = containsCommentSpec.IsSatisfiedBy(codeLine);

           if (!isCommentedLine)
           {
               return false;
           }

           var keywordSpec = new ContainsKeywordSpecification();
           bool containsKeywords = keywordSpec.IsSatisfiedBy(codeLine);

           var codeLikeSpec = new ContainsCodeLikeCharacterSpecification();
           bool containsCodeLikeChars = codeLikeSpec.IsSatisfiedBy(codeLine);

           bool isCodeSuspect = containsKeywords || containsCodeLikeChars;

           return isCodeSuspect;
       }
    }
}
