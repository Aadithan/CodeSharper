

namespace CodeSharper.UI.Analyzer.Specifications
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(Specification<T> leftSide, Specification<T> rightSide)
            : base(leftSide, rightSide)
        {
        }

        public override bool IsSatisfiedBy(T obj)
        {
            return _leftSide.IsSatisfiedBy(obj) && _rightSide.IsSatisfiedBy(obj);
        }
    }
}
