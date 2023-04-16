using api.DBOperations;
using api.Entities;
using AutoMapper;

namespace api.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookQuery
    {
        public CreateBookQueryModel Model;
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookQuery(IBookStoreDbContext _context , IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(b => b.Title == Model.Title);
            if(book is not null){
                throw new InvalidOperationException($"{book.Title} isimli kitap zaten kayitli!");
            }
            book = _mapper.Map<Book>(Model);
            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }
    public class CreateBookQueryModel
    {     
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public int PageCount { get; set; }
        public string? Publisher { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
