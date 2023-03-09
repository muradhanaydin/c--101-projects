using api.DBOperations;

namespace api.BookOperations
{
    public class DeleteBookQuery
    {
        private BookStoreDbContext _context;
        public DeleteBookQuery(BookStoreDbContext _context)
        {
            this._context = _context;
        }
        public void Handle(string id)
        {
            var book = _context.Books.Where(b => b.Id == int.Parse(id)).SingleOrDefault();
            if(book is null)
            {
                throw new InvalidOperationException($"{id}'li kitap sistemde bulunamadi!");
            }
            _context.Remove(book);
            _context.SaveChanges();
        }
    }
}