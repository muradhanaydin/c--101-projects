using AutoMapper;
using api.DBOperations;
using System.Linq;

namespace api.Application.CategoryOperations.Queries.GetBook
{
    public class GetCategoryByIdQuery
    {
        public int CategoryId { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCategoryByIdQuery(BookStoreDbContext _context , IMapper _mapper)
        {
            this._mapper = _mapper;
            this._context = _context;
        }

        public CategoryDetailViewModel Handle()
        {
            var category = _context.Category.SingleOrDefault(x => x.IsActive && x.Id == CategoryId);
            if(category is null){
                throw new Exception($"{CategoryId} id'sine sahip kategor bulunamadi!");
            }
            return _mapper.Map<CategoryDetailViewModel>(category);
        }
    }
    public class CategoryDetailViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}