using api.Common;
using api.DBOperations;
using api.Modal;

namespace api.BookOperations.UpdateBook
{
    public class UpdateBookQuery
    {
        private BookStoreDbContext _context;
        public UpdateBookQuery(BookStoreDbContext _context)
        {
            this._context = _context;
        }
        public void Handle(string id, UpdateBookViewModal modal)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == int.Parse(id));
            if(book is null){
                throw new InvalidOperationException($"{id}'ye sahip kitap bulunamadi!");
            }   
            UpdateBookQueryValidator validator = new UpdateBookQueryValidator();
            var result = validator.Validate(modal);
            if(result.IsValid){
                book.Category = book.Category != default?(int)Enum.Parse(typeof(CategoryEnum), modal.Category):book.Category;
                book.PageCount = book.PageCount != default?modal.PageCount:book.PageCount;
                book.Title = book.Title != default?modal.Title:book.Title;
                book.PublishDate = book.PublishDate != default?(DateTime.Parse(modal.PublishedDate)):book.PublishDate;
                book.Publisher = book.Publisher != default?modal.Publisher:book.Publisher;
                _context.SaveChanges();
            }else{
                string errorMessage = "";
                result.Errors.ForEach(error => {
                    errorMessage += error.ErrorMessage+"\n";
                });
                throw new InvalidOperationException(errorMessage);
            }
        }
    }
}
