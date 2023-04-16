using api.Application.BookOperations.Queries.GetBook;
using api.DBOperations;
using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.BookOperations.Queries.GetBook
{
    public class GetBooksQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBooksQueryTests(CommonTestFixture fixture)
        {
            this._context = fixture.Context;
            this._mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenCorrectRequestIsMade_Books_ShouldBeReturn()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            FluentActions.Invoking(() => query.Handle()).Should().As<List<BookViewModel>>();
        }
    }
}