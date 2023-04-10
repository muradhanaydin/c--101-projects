using api.DBOperations;

namespace api.Application.CategoryOperations.Commands.UpdateCategory
{
    public class UpdateCategoryQuery
    {
        public int CategoryId { get; set; }
        public UpdateCategoryModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        public UpdateCategoryQuery(BookStoreDbContext _context)
        {
            this._context = _context;
        }
        public void Handle()
        {
            var category = _context.Category.SingleOrDefault(x => x.Id == CategoryId);
            if(category is null)
            {
                throw new Exception($"{CategoryId} 'sine sahip kategori bulunamadi!");
            }
            if(_context.Category.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != CategoryId))
            {
                throw new Exception($"{Model.Name} isimli bir kitap turu zaten mevcut");
            }
            category.Name = string.IsNullOrEmpty(Model.Name.Trim())? category.Name : Model.Name;
            category.IsActive = Model.IsActive = Model.IsActive;
            _context.SaveChanges();
        }
    }
    public class UpdateCategoryModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}