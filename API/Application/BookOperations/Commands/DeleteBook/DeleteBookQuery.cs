using api.DBOperations;

namespace api.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookQuery
    {
        public int BookId { get; set; }
        private IBookStoreDbContext _context;
        public DeleteBookQuery(IBookStoreDbContext _context)
        {
            this._context = _context;
        }
        public void Handle()
        {
            var book = _context.Books.Where(b => b.Id == BookId).SingleOrDefault();
            if(book is null)
            {
                throw new Exception($"{BookId} id'sine sahip bir kitap sistemde bulunamadi!");
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
