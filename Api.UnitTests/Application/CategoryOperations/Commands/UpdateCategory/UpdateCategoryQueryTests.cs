using api.Application.CategoryOperations.Commands.UpdateCategory;
using api.DBOperations;
using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.CategoryOperations.Commands.UpdateCategory
{
    public class UpdateCategoryQueryTests : IClassFixture<CommonTestFixture>
    {
        private UpdateCategoryQuery query;
        public UpdateCategoryQueryTests(CommonTestFixture fixture)
        {
            this.query = new UpdateCategoryQuery(fixture.Context);
        }

        [Fact]
        public void WhenInvalidInputAreGiven_Exception_ShouldBeReturn()
        {
            query.CategoryId = 0;
            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>().And.Message.Should().Be($"{query.CategoryId} 'sine sahip kategori bulunamadi!");
        }

        [Fact]
        public void WhenAlreadyExistInputAreGiven_Exception_ShouldBeReturn()
        {
            query.CategoryId = 4;
            query.Model = new UpdateCategoryModel()
            {
                Name = "Education",
                IsActive = true
            };
            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>().And.Message.Should().Be($"{query.Model.Name} isimli bir kitap turu zaten mevcut");
        }

    }
}