using api.DBOperations;
using api.Entities;
using AutoMapper;

namespace api.Application.BookOperations.Commands.CreateBook
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
    public class CreateBookViewModal
    {
        public string? Title { get; set; }
        public int Category { get; set; }
        public int PageCount { get; set; }
        public string? Publisher { get; set; }
        public DateTime PublishDate { get; set; }
    }
}