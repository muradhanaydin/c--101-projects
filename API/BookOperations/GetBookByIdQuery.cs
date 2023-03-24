using api.Common;
using api.DBOperations;
using api.Modal;
using AutoMapper;

namespace api.BookOperations
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBookByIdQuery(BookStoreDbContext _context , IMapper _mapper){
            this._context = _context;
            this._mapper = _mapper;
        }

        public BookViewModel Handle(string id)
        {
            var result = _context.Books.Where(b => b.Id == int.Parse(id)).SingleOrDefault();
            BookViewModel vm = _mapper.Map<BookViewModel>(result);
            return vm;
        }
    }
}
