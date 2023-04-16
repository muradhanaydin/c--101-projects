using api.Application.CategoryOperations.Queries.GetBook;
using api.DBOperations;
using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.CategoryOperations.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCategoryByIdQueryTests(CommonTestFixture fixture)
        {
            this._context = fixture.Context;
            this._mapper = fixture.Mapper;
        }
        
        [Fact]
        public void WhenInvalidInputAreGiven_Exception_ShouldBeReturn()
        {
            GetCategoryByIdQuery query = new GetCategoryByIdQuery(_context, _mapper);
            query.CategoryId = 0;
            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>().And.Message.Should().Be($"{query.CategoryId} id'sine sahip kategor bulunamadi!");
        }
    }
}