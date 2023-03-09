using api.DBOperations;

namespace api.BookOperations.CreateBook
{
    public class CreateBookQuery
    {
        private BookStoreDbContext _context;
        public CreateBookQuery(BookStoreDbContext _context)
        {
            this._context = _context;
        }
        public void Handle(CreateBookViewModal modal)
        {
            Console.WriteLine(modal.Title);
            var book = _context.Books.SingleOrDefault(b => b.Title == modal.Title);
            if(book is not null){
                throw new InvalidOperationException($"{book.Title} isimli kitap zaten kayitli! Kitap ID: {book.Id}");
            }
            book = new Book();
            book.Title = modal.Title;
            book.Category = modal.Category;
            book.PageCount = modal.PageCount;
            book.PublishDate = modal.PublishDate;
            book.Publisher = modal.Publisher;
            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }
}