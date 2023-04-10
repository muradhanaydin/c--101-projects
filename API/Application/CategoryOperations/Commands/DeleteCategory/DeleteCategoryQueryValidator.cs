using FluentValidation;

namespace api.Application.CategoryOperations.Commands.DeleteCategory
{
    public class DeleteCategoryQueryValidator : AbstractValidator<DeleteCategoryQuery>
    {
        public DeleteCategoryQueryValidator()
        {
            RuleFor(query => query.CategoryId).GreaterThan(0);
        }
    }
}