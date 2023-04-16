using api.DBOperations;
using api.Entities;
using AutoMapper;

namespace api.Application.AuthorOperations.Commdans.CreateAuthor
{
    public class CreateAuthorQuery
    {
        public CreateAuthorModel Model;
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorQuery(IBookStoreDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public void Handle()
        {
            var author = _context.Author.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname && x.DateOfBirthDay == Model.DateOfBirthDay);
            if(author is not null)
            {
                throw new Exception($"'{author.Name} {author.Surname}' ismine sahip yazar zaten sistemde kayitlidir!");
            }
            author = new Author();
            author.Name = Model.Name;
            author.Surname = Model.Surname;
            author.DateOfBirthDay = Model.DateOfBirthDay;
            _context.Author.Add(author);
            _context.SaveChanges();
        }
    }
    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirthDay { get; set; }
    }
}
