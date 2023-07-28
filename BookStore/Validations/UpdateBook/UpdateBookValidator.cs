using BookStore.BookOperations.UpdateBook;
using FluentValidation;

namespace BookStore.Validations.UpdateBook
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.BookID).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.Title)
                .NotEmpty().WithMessage("Title field cannot be empty.")
                .MinimumLength(2).WithMessage("Title must be at least 2 characters long.");
            RuleFor(x => x.Model.GenreID)
                .GreaterThan(0).WithMessage("Please provide a valid GenreID.")
                .LessThan(10).WithMessage("Please provide a valid GenreID.");

        }
    }
}
