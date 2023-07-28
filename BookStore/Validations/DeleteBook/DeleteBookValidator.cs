using BookStore.BookOperations.DeleteBook;
using FluentValidation;

namespace BookStore.Validations.DeleteBook
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookValidator()
        {
            RuleFor(x => x.BookID).NotEmpty().GreaterThan(0).WithMessage("Please provide a valid BookID.");
        }
    }
}
