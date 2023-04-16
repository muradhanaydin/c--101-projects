using api.Application.AuthorOperations.Commdans.UpdateAuthor;
using api.DBOperations;
using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateAuthorQueryTests(CommonTestFixture fixture){
            this._context = fixture.Context;
            this._mapper = fixture.Mapper;
        }
        
        [Fact]
        public void WhenInvalidInputAreGiven_Exception_ShouldBeReturn()
        {
            UpdateAuthorQuery query = new UpdateAuthorQuery(_context, _mapper);
            query.AuthorId = 0;

            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>().And.Message.Should().Be($"{query.AuthorId} id'sine sahip yazar bulunamadi!");
        }
    }
}