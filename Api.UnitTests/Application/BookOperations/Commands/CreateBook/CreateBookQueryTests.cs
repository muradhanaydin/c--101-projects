using api.Application.BookOperations.Commands.CreateBook;
using api.DBOperations;
using api.Entities;
using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        
        [Fact]
        public void WhenAlreadyExistInputAreGiven_Exception_ShouldBeReturn()
        {
            var book = new Book(){
                Title = "LOREM IPSUM",
                PageCount = 123 ,
                PublishDate = new System.DateTime(1990,12,21),
                CategoryId = 1,
                AuthorId = 2
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookQuery query = new CreateBookQuery(_context , _mapper);
            CreateBookQueryModel modal = new CreateBookQueryModel(){
                Title = book.Title,
            };
            query.Model = modal;
            
            FluentActions.Invoking(() => query.Handle()).Should().Throw<Exception>().And.Message.Should().Be($"{book.Title} isimli kitap zaten kayitli!");
            
        }
    }
}