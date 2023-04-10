using FluentValidation;

namespace api.Application.CategoryOperations.Commands.UpdateCategory
{
    public class UpdateCategoryQueryValidator : AbstractValidator<UpdateCategoryQuery>
    {
        public UpdateCategoryQueryValidator()
        {
            RuleFor(query => query.Model.Name).MinimumLength(4).When(x => x.Model.Name != string.Empty);
        }
    }
}