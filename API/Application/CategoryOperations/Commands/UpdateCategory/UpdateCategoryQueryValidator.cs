using FluentValidation;

namespace api.Application.CategoryOperations.Commands.UpdateCategory
{
    public class UpdateCategoryQueryValidator : AbstractValidator<UpdateCategoryModel>
    {
        public UpdateCategoryQueryValidator()
        {
            RuleFor(model => model.Name).MinimumLength(4).When(m => !string.IsNullOrEmpty(m.Name));
        }
    }
}
