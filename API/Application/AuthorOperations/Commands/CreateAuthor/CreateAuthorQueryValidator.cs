using FluentValidation;

namespace api.Application.AuthorOperations.Commdans.CreateAuthor
{
    public class CreateAuthorQueryValidator : AbstractValidator<CreateAuthorQuery>
    {
        public CreateAuthorQueryValidator()
        {
            RuleFor(query => query.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(query => query.Model.Surname).NotEmpty().MinimumLength(2);
            RuleFor(query => query.Model.DateOfBirthDay).NotEmpty().LessThan(DateTime.Now);
        }
    }
}