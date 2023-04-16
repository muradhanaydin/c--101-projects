using api.Application.CategoryOperations.Queries;
using api.DBOperations;
using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.CategoryOperations.Queries.GetCategory
{
    public class GetCategoryQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCategoryQueryTests(CommonTestFixture fixture)
        {
            this._context = fixture.Context;
            this._mapper = fixture.Mapper;
        }
        
        [Fact]
        public void WhenCorrectRequestIsMade_CategoryList_ShouldBeReturn()
        {
            GetCategoryQuery query = new GetCategoryQuery(_context, _mapper);
            FluentActions.Invoking(() => query.Handle()).Should().As<List<CategoryViewModel>>();
        }
    }
}