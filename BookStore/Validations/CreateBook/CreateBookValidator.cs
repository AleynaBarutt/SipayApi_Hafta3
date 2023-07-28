using BookStore.BookOperations.CreateBook;
using FluentValidation;
using System;

namespace BookStore.Validations.CreateBook
{
    public class CreateBookValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Model.Title)
                .NotEmpty().WithMessage("Title field cannot be empty.")
                .MinimumLength(2).WithMessage("Title must be at least 2 characters long.");

            RuleFor(x => x.Model.GenreID)
                .GreaterThan(0).WithMessage("Please provide a valid GenreID.")
                .LessThan(10).WithMessage("Please provide a valid GenreID.");

            RuleFor(x => x.Model.PageCount)
                .GreaterThan(0).WithMessage("Page count must be greater than 0.");

            RuleFor(x => x.Model.PublishDate)
                .NotEmpty().WithMessage("Publish date cannot be empty.")
                .LessThan(DateTime.Now.Date).WithMessage("Publish date must be before today.");

        }
    }
}
