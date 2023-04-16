using api.DBOperations;
using api.Entities;

namespace api.Application.CategoryOperations.Commands.DeleteCategory
{
    public class DeleteCategoryQuery
    {
        public int CategoryId { get; set; }
        private readonly IBookStoreDbContext _context;
        public DeleteCategoryQuery(IBookStoreDbContext _context)
        {
            this._context = _context;
        }

        public void Handle()
        {
            var category = _context.Category.SingleOrDefault(x => x.Id == CategoryId);
            if(category is null){
                throw new Exception($"{CategoryId} id'sine sahip kategori bulunamadi!");
            }
            _context.Category.Remove(category);
            _context.SaveChanges();
        }
    }
}
