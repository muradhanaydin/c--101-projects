using api.Application.CategoryOperations.Commands.DeleteCategory;
using api.DBOperations;
using FluentAssertions;
using TestSetup;

namespace Application.CategoryOperations.Commands.DeleteCategory
{
    public class DeleteCategoryQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteCategoryQueryTests(CommonTestFixture fixture)
        {
            this._context = fixture.Context;
        }

        [Fact]
        public void WhenInvalidInputAreGiven_Exception_ShouldBeReturn()
        {
            DeleteCategoryQuery query = new DeleteCategoryQuery(_context);
            query.CategoryId = 0;
            
            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>().And.Message.Should().Be($"{query.CategoryId} 'sine sahip kategori bulunamadi!");
        }
    }
}