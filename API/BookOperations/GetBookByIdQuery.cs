using api.Common;
using api.DBOperations;
using api.Modal;

namespace api.BookOperations
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _context;
        public GetBookByIdQuery(BookStoreDbContext _context){
            this._context = _context;
        }

        public BookViewModel Handle(string id)
        {
            var result = _context.Books.Where(b => b.Id == int.Parse(id)).SingleOrDefault();
            return new BookViewModel(){
                Title = result.Title, 
                Category = ((CategoryEnum)result.Category).ToString(),
                PublishedDate = result.PublishDate.Date.ToString("dd/MM/yyy"),
                Publisher = result.Publisher,
                PageCount = result.PageCount
            };
        }
    }
}