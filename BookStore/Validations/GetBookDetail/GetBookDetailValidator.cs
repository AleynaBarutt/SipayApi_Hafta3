using BookStore.BookOperations.GetBookDetail;
using FluentValidation;

namespace BookStore.Validations.GetBookDetail
{
    public class GetBookDetailValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailValidator()
        {
            RuleFor(x => x.BookID).NotEmpty().GreaterThan(0).WithMessage("Please provide a valid BookID.");
        }
    }
}
