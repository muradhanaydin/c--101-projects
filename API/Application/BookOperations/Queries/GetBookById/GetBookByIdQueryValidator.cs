using api.Application.BookOperations.Queries.GetBook;
using FluentValidation;

namespace api.Application.BookOperations.Queries.GetBookById
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(query => query.BookId).GreaterThan(0);
        }
    }
}