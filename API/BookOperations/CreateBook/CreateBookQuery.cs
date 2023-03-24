using api.DBOperations;
using AutoMapper;

namespace api.BookOperations.CreateBook
{
    public class CreateBookQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookQuery(BookStoreDbContext _context , IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public void Handle(CreateBookViewModal modal)
        {
            CreateBokQueryValidator validater = new CreateBokQueryValidator();
            var result = validater.Validate(modal);
            if(result.IsValid)
            {
                var book = _context.Books.SingleOrDefault(b => b.Title == modal.Title);
                if(book is not null){
                    throw new InvalidOperationException($"{book.Title} isimli kitap zaten kayitli! Kitap ID: {book.Id}");
                }
                book = _mapper.Map<Book>(modal);
                _context.Books.Add(book);
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
