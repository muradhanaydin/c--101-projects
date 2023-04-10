using api.DBOperations;
using AutoMapper;

namespace api.Application.AuthorOperations.Commdans.DeleteAuthor
{
    public class DeleteAuthorQuery
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public DeleteAuthorQuery(BookStoreDbContext _context , IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public void Handle()
        {
            var author = _context.Author.SingleOrDefault(x => x.Id == AuthorId);
            if(author is null)
            {
                throw new Exception($"{AuthorId} id'sine sahip yazar bulunamadi!");
            }
            var books = _context.Books.Where(x => x.AuthorId == AuthorId).ToList().Count;
            if(books != 0)
            {
                throw new Exception($"{author.Id} id'li yazarin aktif olarak {books} adet kitaplari bulunmakta. Once kitaplari silmelisiniz!");
            }

            _context.Author.Remove(author);
            _context.SaveChanges();
        }
    }
}