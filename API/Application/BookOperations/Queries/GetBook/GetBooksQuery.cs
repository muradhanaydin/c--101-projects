using api.Common;
using api.DBOperations;
using api.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Application.BookOperations.Queries.GetBook
{
    public class GetBooksQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBooksQuery(IBookStoreDbContext _context , IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public List<BookViewModel> Handle(){
            var booklist = _context.Books.Include(x => x.Category).Include(x => x.Author).OrderBy(b => b.Id).ToList<Book>();
            List<BookViewModel> res = _mapper.Map<List<BookViewModel>>(booklist);
            return res;
        }

    }
    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishedDate { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; } 
    }
}
