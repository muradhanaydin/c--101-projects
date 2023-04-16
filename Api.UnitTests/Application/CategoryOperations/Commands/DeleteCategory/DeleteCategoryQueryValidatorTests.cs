using api.Application.CategoryOperations.Commands.DeleteCategory;
using FluentAssertions;
using TestSetup;

namespace Application.CategoryOperations.Commands.DeleteCategory
{
    public class DeleteCategoryQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private DeleteCategoryQuery query;
        private DeleteCategoryQueryValidator validator;
        public DeleteCategoryQueryValidatorTests(CommonTestFixture fixture)
        {
            this.query = new DeleteCategoryQuery(fixture.Context);
            this.validator = new DeleteCategoryQueryValidator();
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