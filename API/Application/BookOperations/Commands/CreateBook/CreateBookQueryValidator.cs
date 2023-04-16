
using FluentValidation;

namespace api.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookQueryValidator : AbstractValidator<CreateBookQueryModel>
    {
        public CreateBookQueryValidator()
        {
            RuleFor(book => book.Title).NotEmpty().MinimumLength(2);            
            RuleFor(book => book.Publisher).NotEmpty().MinimumLength(2);            
            RuleFor(book => book.PageCount).GreaterThan(0);
            RuleFor(book => book.AuthorId).GreaterThan(0);
            RuleFor(book => book.CategoryId).GreaterThan(0);
            RuleFor(book => book.PublishDate).NotEmpty().LessThan(DateTime.Now);
        }
    }
}
