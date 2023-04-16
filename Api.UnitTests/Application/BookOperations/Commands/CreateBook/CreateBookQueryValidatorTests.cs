using api.Application.BookOperations.Commands.CreateBook;
using FluentAssertions;
using FluentValidation;
using TestSetup;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private CreateBookQueryValidator validator;
        public CreateBookQueryValidatorTests()
        {
            this.validator = new CreateBookQueryValidator();
        }

        [Fact]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeErrors()
        {
            validator.Validate(new CreateBookQueryModel(){
                Title = "",
                PageCount = 0,
                PublishDate = DateTime.Now,
                CategoryId = 0,
                AuthorId = 0,
                Publisher = ""
            }).Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenCorrectInputAreGiven_Validator_ShouldBeReturnTrue()
        {
            validator.Validate(new CreateBookQueryModel(){
                Title = "LOREM",
                PageCount = 125,
                AuthorId = 2,
                PublishDate = DateTime.Now.AddYears(-10),
                CategoryId = 1,
                Publisher = "XMANTR"
            }).IsValid.Should().Be(true);
        }
    }
}