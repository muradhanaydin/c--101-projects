using api.DBOperations;
using AutoMapper;

namespace api.Application.AuthorOperations.Queries.GetAuthor
{
    public class GetAuthorQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public GetAuthorQuery(IBookStoreDbContext _context , IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var query = _context.Author.OrderBy(x => x.Id);
            List<AuthorViewModel> res = _mapper.Map<List<AuthorViewModel>>(query);
            return res;
        }
    }
    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirthDay { get; set; }
    }
}
