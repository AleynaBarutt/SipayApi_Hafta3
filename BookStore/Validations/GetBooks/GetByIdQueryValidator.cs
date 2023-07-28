using BookStore.BookOperations.GetBooks;
using FluentValidation;

namespace BookStore.Validations.GetBooks
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(x => x.BookID).NotEmpty().GreaterThan(0).WithMessage("Please provide a valid BookID.");
        }
    }
}
