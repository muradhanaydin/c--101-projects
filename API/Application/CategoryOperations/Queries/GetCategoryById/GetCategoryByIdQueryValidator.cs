using FluentValidation;

namespace api.Application.CategoryOperations.Queries.GetBook
{
    public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdQueryValidator()
        {
            RuleFor(query => query.CategoryId).GreaterThan(0);
        }
    }
}