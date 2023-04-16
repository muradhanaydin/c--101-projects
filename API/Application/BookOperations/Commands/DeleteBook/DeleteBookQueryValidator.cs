using FluentValidation;

namespace api.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookQueryValidator : AbstractValidator<DeleteBookQuery>
    {
        public DeleteBookQueryValidator()
        {
            RuleFor(book => book.BookId).GreaterThan(0);
        }
    }
}