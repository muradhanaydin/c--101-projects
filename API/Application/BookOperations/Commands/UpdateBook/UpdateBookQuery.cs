using api.DBOperations;
using api.Common;
using AutoMapper;

namespace api.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookQuery
    {
        public int BookId { get; set; }
        public UpdateBookQueryModel Model { get; set; }
        private IBookStoreDbContext _context;
        private IMapper _mapper;
        public UpdateBookQuery(IBookStoreDbContext _context , IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == BookId);
            if(book is null){
                throw new InvalidOperationException($"{BookId} id'sine sahip kitap bulunamadi!");
            }
            book.AuthorId = book.AuthorId != default?Model.AuthorId:book.AuthorId;
            book.CategoryId = book.CategoryId != default?Model.CategoryId:book.CategoryId;
            book.PageCount = book.PageCount != default?Model.PageCount:book.PageCount;
            book.Title = book.Title != default?Model.Title:book.Title;
            book.PublishDate = book.PublishDate != default?(DateTime.Parse(Model.PublishedDate)):book.PublishDate;
            book.Publisher = book.Publisher != default?Model.Publisher:book.Publisher;
            _context.SaveChanges();
        }
    }
    public class UpdateBookQueryModel
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public int PageCount { get; set; }
        public string PublishedDate { get; set; }
    }
}
