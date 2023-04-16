using api.Application.AuthorOperations.Commdans.DeleteAuthor;
using api.DBOperations;
using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorQueryTests : IClassFixture<CommonTestFixture>
    {
        private DeleteAuthorQuery query;
        public DeleteAuthorQueryTests(CommonTestFixture fixture)
        {
            this.query = new DeleteAuthorQuery(fixture.Context);
        }

        [Fact]
        public void WhenInvalidInputAreGiven_Exception_ShouldBeReturn()
        {
            query.AuthorId = 20;

            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>().And.Message.Should().Be($"{query.AuthorId} id'sine sahip yazar bulunamadi!");
        }
        
        [Fact]
        public void WhenAuthorHasActiveBook_Exception_ShouldBeReturn()
        {
            query.AuthorId = 1;

            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>().And.Message.Should().Be($"{query.AuthorId} id'li yazarin aktif olarak kitaplari bulunmakta. Once kitaplari silmelisiniz!");
        }
    }
}