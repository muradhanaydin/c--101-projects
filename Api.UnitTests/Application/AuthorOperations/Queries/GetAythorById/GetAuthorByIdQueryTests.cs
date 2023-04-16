using api.Application.AuthorOperations.Queries.GetAuthorById;
using api.DBOperations;
using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryTests : IClassFixture<CommonTestFixture>
    {
        private GetAuthorByIdQuery query;
        public GetAuthorByIdQueryTests(CommonTestFixture fixture)
        {
            this.query = new GetAuthorByIdQuery(fixture.Context, fixture.Mapper);
        }
        
        [Fact]
        public void WhenInvalidInputAreGiven_Exception_ShouldBeReturn()
        {
            query.AuthorId = 20000;

            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>().And.Message.Should().Be($"{query.AuthorId} id'sine sahip bir yazar bulunamadi!");
        }

        [Fact]
        public void WhenCorrectInputAreGiven_AuthorDetail_ShouldBeReturn()
        {
            query.AuthorId = 1;

            FluentActions.Invoking(() => query.Handle()).Should().As<AuthorDetailViewModel>();
        }
    }
}