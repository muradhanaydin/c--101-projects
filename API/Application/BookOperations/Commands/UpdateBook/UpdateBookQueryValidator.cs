using FluentValidation;

namespace api.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookQueryValidator : AbstractValidator<UpdateBookViewModal>
    {
        public UpdateBookQueryValidator()
        {
            RuleFor(book => book.Category).NotEmpty();
            RuleFor(book => book.Title).NotEmpty().MinimumLength(2);
            RuleFor(book => DateTime.Parse(book.PublishedDate)).LessThan(DateTime.Now);
            RuleFor(book => book.PageCount).GreaterThan(0);
            RuleFor(book => book.Publisher).NotEmpty();
        }
    }
}