using api.Application.CategoryOperations.Commands.CreateCategory;
using FluentAssertions;
using TestSetup;

namespace Application.CategoryOperations.Commands.CreateCategory
{
    public class CreateCategoryQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private CreateCategoryQueryValidator  validator;
        public CreateCategoryQueryValidatorTests()
        {
            this.validator = new CreateCategoryQueryValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("Den")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string categoryName)
        {
            validator.Validate(new CreateCategoryModel(){
                Name = categoryName
            }).Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenCorrectInputAreGiven_Validator_ShouldBeReturnTrue()
        {
           validator.Validate(new CreateCategoryModel(){
                Name = "DENEME"
            }).IsValid.Should().Be(true);
        }
    }
}