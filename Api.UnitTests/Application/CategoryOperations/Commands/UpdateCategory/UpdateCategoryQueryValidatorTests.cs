using api.Application.CategoryOperations.Commands.UpdateCategory;
using FluentAssertions;
using TestSetup;

namespace Application.CategoryOperations.Commands.UpdateCategory
{
    public class UpdateCategoryQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private UpdateCategoryQueryValidator validator;
        public UpdateCategoryQueryValidatorTests()
        {
            this.validator = new UpdateCategoryQueryValidator();
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("Lo")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string name)
        {
            validator.Validate(new UpdateCategoryModel(){
                Name = name,
                IsActive = true
            }).Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenCorrectInputAreGiven_Validator_ShouldBeReturnTrue()
        {
            validator.Validate(new UpdateCategoryModel(){
                Name = "Travel"
            }).IsValid.Should().Be(true);
        }
    }
}