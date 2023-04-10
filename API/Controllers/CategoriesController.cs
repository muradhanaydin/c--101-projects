using Microsoft.AspNetCore.Mvc;
using api.DBOperations;
using AutoMapper;
using api.Application.CategoryOperations.Queries;
using api.Application.CategoryOperations.Queries.GetBook;
using FluentValidation;
using api.Application.CategoryOperations.Commands.CreateCategory;
using api.Application.CategoryOperations.Commands.UpdateCategory;
using api.Application.CategoryOperations.Commands.DeleteCategory;

namespace api.Controllers{

    [ApiController]
    [Route("api/[controller]s")]
    public class CategoryController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CategoryController(BookStoreDbContext _context , IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }

        [HttpGet]
        public ActionResult GetCategories()
        {
            GetCategoryQuery query = new GetCategoryQuery(_context , _mapper);
            var res = query.Handle();
            return Ok(res);
        }

        [HttpGet("id")]
        public ActionResult GetCategoryById(int id)
        {
            GetCategoryByIdQuery query = new GetCategoryByIdQuery(_context , _mapper);
            query.CategoryId = id;
            GetCategoryByIdQueryValidator validator = new GetCategoryByIdQueryValidator();
            validator.ValidateAndThrow(query);
            var res = query.Handle();
            return Ok(res);
        }
        
        [HttpPost]
        public IActionResult AddCategory([FromBody] CreateCategoryModel category)
        {
            CreateCategoryQuery query = new CreateCategoryQuery(_context);
            query.Model = category;
            CreateCategoryQueryValidator validator =  new CreateCategoryQueryValidator();
            validator.ValidateAndThrow(query);
            query.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateCategory(int id , [FromBody] UpdateCategoryModel category)
        {
            UpdateCategoryQuery query = new UpdateCategoryQuery(_context);
            query.CategoryId = id;
            query.Model = category;
            UpdateCategoryQueryValidator validator = new UpdateCategoryQueryValidator();
            validator.ValidateAndThrow(query);
            query.Handle();
            return Ok($"{id} ye sahip kategori basarili bir sekilde guncellendi!");
        }

        [HttpDelete("id")]
        public IActionResult DeleteCategory(int id)
        {
            DeleteCategoryQuery query = new DeleteCategoryQuery(_context);
            query.CategoryId = id;
            DeleteCategoryQueryValidator validator = new DeleteCategoryQueryValidator();
            validator.ValidateAndThrow(query);
            query.Handle();
            return Ok($"{id} ye sahip kategori basarili bir sekilde silindi!");
        }
    }
}
