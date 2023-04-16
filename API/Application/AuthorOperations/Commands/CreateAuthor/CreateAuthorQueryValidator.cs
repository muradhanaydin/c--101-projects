using FluentValidation;

namespace api.Application.AuthorOperations.Commdans.CreateAuthor
{
    public class CreateAuthorQueryValidator : AbstractValidator<CreateAuthorQueryModel>
    {
        public CreateAuthorQueryValidator()
        {
            RuleFor(author => author.Name).NotEmpty().MinimumLength(2);
            RuleFor(author => author.Surname).NotEmpty().MinimumLength(2);
            RuleFor(author => author.DateOfBirthDay).NotEmpty().LessThan(DateTime.Now);
        }
    }
}
