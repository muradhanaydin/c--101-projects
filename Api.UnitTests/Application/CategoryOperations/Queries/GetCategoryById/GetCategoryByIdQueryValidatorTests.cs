using api.Application.CategoryOperations.Queries.GetBook;
using FluentAssertions;
using TestSetup;

namespace Application.CategoryOperations.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private GetCategoryByIdQuery query;
        private GetCategoryByIdQueryValidator validator;
        public GetCategoryByIdQueryValidatorTests(CommonTestFixture fixture)
        {
            this.query = new GetCategoryByIdQuery(fixture.Context, fixture.Mapper);
            this.validator = new GetCategoryByIdQueryValidator();
        }

        [Fact]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors()
        {
            query.CategoryId = 0;
            validator.Validate(query).Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenCorrectInputAreGiven_Validator_ShouldBeReturnTrue()
        {
            query.CategoryId = 1;
            validator.Validate(query).IsValid.Should().Be(true);
        }
    }
}