using api.Application.CategoryOperations.Commands.CreateCategory;
using api.DBOperations;
using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.CategoryOperations.Commands.CreateCategory
{
    public class CreateCategoryQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public CreateCategoryQueryTests(CommonTestFixture fixture)
        {
            this._context = fixture.Context;
        }
        
        [Fact]
        public void WhenAlreadyExistInputAreGiven_Exception_ShouldBeReturn()
        {
            CreateCategoryQuery query = new CreateCategoryQuery(_context);
            query.Model = new CreateCategoryModel(){
                Name = "Education"
            };
            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>().And.Message.Should().Be($"{query.Model.Name} turunde zaten bir kategori mevcut!");
        }
    }
}