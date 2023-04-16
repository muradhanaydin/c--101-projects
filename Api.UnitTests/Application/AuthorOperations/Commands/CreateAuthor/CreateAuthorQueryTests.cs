using api.Application.AuthorOperations.Commdans.CreateAuthor;
using api.DBOperations;
using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorQueryTests(CommonTestFixture fixture)
        {
            this._context = fixture.Context;
            this._mapper = fixture.Mapper;
        }
        
        [Fact]
        public void WhenAlreadyExistInputAreGiven_Exception_ShouldBeReturn()
        {
            CreateAuthorQuery query = new CreateAuthorQuery(_context, _mapper);
            query.Model = new CreateAuthorQueryModel(){
                Name = "MUSTAFA",
                Surname = "KARAHANLI",
                DateOfBirthDay = DateTime.Parse("12/12/2000")
            };

            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>().And.Message.Should().Be($"{query.Model.Name} {query.Model.Surname} isimli yazar zaten sistemde kayitlidir!");
        }
    }
}