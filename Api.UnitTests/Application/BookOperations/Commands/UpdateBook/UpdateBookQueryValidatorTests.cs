using api.Application.BookOperations.Commands.UpdateBook;
using FluentAssertions;
using TestSetup;

namespace Application.BookOperations.Commands.UpdateBook
{   
    public class UpdateBookQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private UpdateBookQueryValidator validator;
        public UpdateBookQueryValidatorTests()
        {
            this.validator = new UpdateBookQueryValidator();
        }
        
        [Theory]
        [InlineData("","",0,0,0)]        
        [InlineData("","",1,1,100)]
        [InlineData("","",1,0,100)]
        [InlineData("","",0,1,100)]
        [InlineData("","",1,1,0)]
        [InlineData("Tit","",0,0,0)]
        [InlineData("Tit","",1,0,0)]
        [InlineData("Tit","",0,1,0)]
        [InlineData("Tit","",0,0,1)]
        [InlineData("","Pub",0,0,0)]
        [InlineData("","Pub",1,0,0)]
        [InlineData("","Pub",0,1,0)]
        [InlineData("","Pub",0,0,1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title , string publisher , int categoryId , int authorId , int pageCount)
        {
            validator.Validate(new UpdateBookQueryModel(){
                Title = title,
                Publisher = publisher,
                PublishedDate = DateTime.Now.AddYears(-10).ToString(),
                CategoryId = categoryId,
                AuthorId = authorId,
                PageCount = pageCount
            }).Errors.Count.Should().BeGreaterThan(0);
        }
        
        [Fact]
        public void WhenCorrectInputAreGiven_Validator_ShouldBeReturnTrue()
        {
            validator.Validate(new UpdateBookQueryModel(){
                Title = "LOREM TITLE",
                Publisher = "LOREM PUBLISHER",
                PublishedDate = DateTime.Now.AddYears(-10).ToString(),
                CategoryId = 2,
                AuthorId = 1,
                PageCount = 250
            }).IsValid.Should().Be(true);
        }
    }
}