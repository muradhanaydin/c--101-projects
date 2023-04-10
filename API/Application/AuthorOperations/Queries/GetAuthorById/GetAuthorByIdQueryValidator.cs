using FluentValidation;

namespace api.Application.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorById>
    {
        public GetAuthorByIdQueryValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThan(0);
        }
    }
}