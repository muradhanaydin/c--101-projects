using FluentValidation;

namespace api.Application.AuthorOperations.Commdans.DeleteAuthor
{
    public class DeleteAuthorQueryValidator : AbstractValidator<DeleteAuthorQuery>
    {
        public DeleteAuthorQueryValidator()
        {
            RuleFor(query => query.AuthorId).GreaterThan(0);
        }
    }
}