using api.Common;
using api.DBOperations;
using api.Modal;

namespace api.BookOperations
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _context;
        public GetBooksQuery(BookStoreDbContext _context)
        {
            this._context = _context;
        }

        public List<BookViewModel> Handle(){
            var booklist = _context.Books.OrderBy(b => b.Id).ToList<Book>();
            List<BookViewModel> viewModel = new List<BookViewModel>();
            foreach(var book in booklist)
            {
                viewModel.Add(new BookViewModel(){
                    Title = book.Title,
                    Category = ((CategoryEnum)book.Category).ToString(),
                    PageCount = book.PageCount,
                    PublishedDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                    Publisher = book.Publisher
                });
            }
            return viewModel;
        }
    }
}