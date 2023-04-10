using AutoMapper;
using api.DBOperations;
using System.Linq;

namespace api.Application.CategoryOperations.Queries
{
    public class GetCategoryQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCategoryQuery(BookStoreDbContext _context , IMapper _mapper)
        {
            this._mapper = _mapper;
            this._context = _context;
        }

        public List<CategoryViewModel> Handle()
        {
            var Categories = _context.Category.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<CategoryViewModel> res = _mapper.Map<List<CategoryViewModel>>(Categories);
            return res;
        }
    }
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}