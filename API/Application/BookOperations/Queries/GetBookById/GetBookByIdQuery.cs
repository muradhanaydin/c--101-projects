using api.DBOperations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Application.BookOperations.Queries.GetBook
{
    public class GetBookByIdQuery
    {
        public int BookId { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBookByIdQuery(BookStoreDbContext _context , IMapper _mapper){
            this._context = _context;
            this._mapper = _mapper;
        }
        public BookDetailViewModel Handle()
        {
            var result = _context.Books.Include(x => x.Category).Include(x => x.Author).Where(b => b.Id == BookId).SingleOrDefault();
            BookDetailViewModel res = _mapper.Map<BookDetailViewModel>(result);
            return res;
        }
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishedDate { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public string CreatedAt { get; set; }
    }
}