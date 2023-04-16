using api.DBOperations;
using AutoMapper;

namespace api.Application.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery
    {
        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorByIdQuery(IBookStoreDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _context.Author.SingleOrDefault(x => x.Id == AuthorId);
            if(author is null)
            {
                throw new Exception($"{AuthorId} id'sine sahip bir yazar bulunamadi!");
            }
            return _mapper.Map<AuthorDetailViewModel>(author);
        }
    }
    public class AuthorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirthDay { get; set; }
    }
}
