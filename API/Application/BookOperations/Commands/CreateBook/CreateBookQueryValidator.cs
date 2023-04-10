
using FluentValidation;

namespace api.Application.BookOperations.Commands.CreateBook
{
    public class CreateBokQueryValidator : AbstractValidator<CreateBookViewModal>
    {
        public CreateBokQueryValidator()
        {
            RuleFor(book => book.Category).GreaterThan(0);
            RuleFor(book => book.Title).NotEmpty().MinimumLength(2);
            RuleFor(book => book.PublishDate).NotEmpty().LessThan(DateTime.Now);
            RuleFor(book => book.PageCount).GreaterThan(0);
        }
    }
}