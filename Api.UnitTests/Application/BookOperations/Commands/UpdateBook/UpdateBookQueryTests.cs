using api.Application.BookOperations.Commands.UpdateBook;
using TestSetup;
using FluentAssertions;
using api.DBOperations;
using AutoMapper;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateBookQueryTests(CommonTestFixture testFixture)
        {
            this._context = testFixture.Context;
            this._mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenInvalidInputAreGiven_Exception_ShouldBeReturn()
        {
            int bookId = 200;
            UpdateBookQuery query = new UpdateBookQuery(_context,_mapper);
            query.BookId = bookId;

            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>().And.Message.Should().Be($"{bookId} id'sine sahip kitap bulunamadi!");
        }
    }
}