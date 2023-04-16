using api.Application.AuthorOperations.Queries.GetAuthor;
using api.DBOperations;
using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorsQueryTests(CommonTestFixture fixture)
        {
            this._context = fixture.Context;
            this._mapper = fixture.Mapper;
        }
        [Fact]
        public void WhenCorrectRequestIsMade_AuthorList_ShouldBeReturn()
        {
            GetAuthorQuery query = new GetAuthorQuery(_context, _mapper);
            FluentActions.Invoking(() => query.Handle()).Should().As<List<AuthorViewModel>>();
        }
    }
}