using api.DBOperations;
using api.Entities;

namespace api.Application.CategoryOperations.Commands.CreateCategory
{
    public class CreateCategoryQuery
    {
        public CreateCategoryModel Model { get; set; }
        private readonly IBookStoreDbContext _context;
        public CreateCategoryQuery(IBookStoreDbContext _context)
        {
            this._context = _context;
        }
        public void Handle()
        {
            var category = _context.Category.SingleOrDefault(x => x.Name == Model.Name);
            if(category is not null)
            {
                throw new Exception($"{Model.Name} turunde zaten bir kategori mevcut!");
            }
            category = new Category();
            category.Name = Model.Name;
            _context.Category.Add(category);
            _context.SaveChanges();
        }
    }
    public class CreateCategoryModel
    {
        public string Name { get; set; }
    }
}
