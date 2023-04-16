using api.DBOperations;
using AutoMapper;

namespace api.Application.AuthorOperations.Commdans.UpdateAuthor
{
    public class UpdateAuthorQuery
    {
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateAuthorQuery(IBookStoreDbContext _context, IMapper _mapper)
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

            author.Name = Model.Name != author.Name? Model.Name:author.Name;
            author.Surname = Model.Surname != author.Surname? Model.Surname:author.Surname;
            author.DateOfBirthDay = Model.DateOfBirthDay != author.DateOfBirthDay? Model.DateOfBirthDay:author.DateOfBirthDay;
            _context.SaveChanges();
        }
    }
    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirthDay { get; set; }
    }
}
