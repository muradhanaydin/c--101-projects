using api.Common;
using api.DBOperations;
using api.Modal;
using AutoMapper;

namespace api.BookOperations
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext _context , IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public List<BookViewModel> Handle(){
            var booklist = _context.Books.OrderBy(b => b.Id).ToList<Book>();
            List<BookViewModel> viewModel = _mapper.Map<List<BookViewModel>>(booklist);
            return viewModel;
        }
    }
}
