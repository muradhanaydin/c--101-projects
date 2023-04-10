using FluentValidation;

namespace api.Application.CategoryOperations.Commands.CreateCategory
{
    public class CreateCategoryQueryValidator : AbstractValidator<CreateCategoryQuery>
    {
        public CreateCategoryQueryValidator()
        {
            RuleFor(query => query.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}