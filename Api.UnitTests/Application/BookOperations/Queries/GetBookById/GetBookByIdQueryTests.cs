using api.DBOperations;
using api.Application.BookOperations.Queries.GetBookById;
using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.BookOperations.Queries.GetBookById
{
    public class GetBookByIdQueryTests : IClassFixture<CommonTestFixture>
    {
        private GetBookByIdQuery query;
        public GetBookByIdQueryTests(CommonTestFixture fixture)
        {
            this.query = new GetBookByIdQuery(fixture.Context, fixture.Mapper);
        }
        
        [Fact]
        public void WhenInvalidInputAreGiven_Exception_ShoulBeReturn()
        {
            query.BookId = 2999;

            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>().And.Message.Should().Be($"{query.BookId} id'sine sahip kitap bulunamadi!");
        }

        [Fact]
        public void WhenCorrectExistInputAreGiven_Book_ShouldBeReturn()
        {
            query.BookId = 2;   

            FluentActions.Invoking(() => query.Handle()).Should().As<BookDetailViewModel>();
        }
    }
}