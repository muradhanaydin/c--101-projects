using FluentValidation;

namespace api.Application.CategoryOperations.Commands.CreateCategory
{
    public class CreateCategoryQueryValidator : AbstractValidator<CreateCategoryModel>
    {
        public CreateCategoryQueryValidator()
        {
            RuleFor(model => model.Name).NotEmpty().MinimumLength(4);
        }
    }
}
