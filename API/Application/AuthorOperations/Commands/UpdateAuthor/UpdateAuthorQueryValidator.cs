using FluentValidation;

namespace api.Application.AuthorOperations.Commdans.UpdateAuthor
{
    public class UpdateAuthorQueryValidator : AbstractValidator<UpdateAuthorQuery>
    {
        public UpdateAuthorQueryValidator()
        {
            RuleFor(query => query.AuthorId).GreaterThan(0);
            RuleFor(query => query.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(query => query.Model.Surname).NotEmpty().MinimumLength(2);
            RuleFor(query => query.Model.DateOfBirthDay).NotEmpty().LessThan(DateTime.Now);
        }
    }
}