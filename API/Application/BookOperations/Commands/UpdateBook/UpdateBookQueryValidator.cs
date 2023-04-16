using FluentValidation;

namespace api.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookQueryValidator : AbstractValidator<UpdateBookQueryModel>
    {
        public UpdateBookQueryValidator()
        {
            RuleFor(book => book.Title).NotEmpty().MinimumLength(2);            
            RuleFor(book => book.Publisher).NotEmpty().MinimumLength(2);            
            RuleFor(book => book.PageCount).GreaterThan(0);
            RuleFor(book => book.AuthorId).GreaterThan(0);
            RuleFor(book => book.CategoryId).GreaterThan(0);
            RuleFor(book => DateTime.Parse(book.PublishedDate)).NotEmpty().LessThan(DateTime.Now);
        }
    }
}
