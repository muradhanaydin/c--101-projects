using api.Application.BookOperations.Commands.DeleteBook;
using api.DBOperations;
using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteBookQueryTests(CommonTestFixture testFixture)
        {
            this._context = testFixture.Context;
        }
        
        [Fact]
        public void WhenInvalidInputAreGiven_Exception_ShouldBeReturn()
        {
            int bookId = 2000;
            
            DeleteBookQuery query = new DeleteBookQuery(_context);
            query.BookId = bookId;

            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>().And.Message.Should().Be($"{bookId} id'sine sahip bir kitap sistemde bulunamadi!");
        }
    }
}