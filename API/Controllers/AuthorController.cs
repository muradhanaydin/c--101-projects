using api.Application.AuthorOperations.Commdans.CreateAuthor;
using api.Application.AuthorOperations.Commdans.DeleteAuthor;
using api.Application.AuthorOperations.Commdans.UpdateAuthor;
using api.Application.AuthorOperations.Queries.GetAuthor;
using api.Application.AuthorOperations.Queries.GetAuthorById;
using api.DBOperations;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(BookStoreDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorQuery authors = new GetAuthorQuery(_context, _mapper);
            var res = authors.Handle();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            GetAuthorById author = new GetAuthorById(_context, _mapper);
            author.AuthorId = id;
            var res = author.Handle();
            return Ok(res);
        }
        
        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel model)
        {
            CreateAuthorQuery query = new CreateAuthorQuery(_context, _mapper);
            query.Model = model;
            CreateAuthorQueryValidator validator = new CreateAuthorQueryValidator();
            validator.ValidateAndThrow(query);
            query.Handle();
            return Ok($"{model.Name} {model.Surname} isimli yazar basarili bir sekilde eklendi!");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id , [FromBody] UpdateAuthorModel model)
        {
            UpdateAuthorQuery query = new UpdateAuthorQuery(_context, _mapper);
            UpdateAuthorQueryValidator validator = new UpdateAuthorQueryValidator();
            query.Model = model;
            query.AuthorId = id;
            validator.ValidateAndThrow(query);
            query.Handle();
            return Ok($"{id} id'sine sahip yazar basarili bir sekilde guncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorQuery query = new DeleteAuthorQuery(_context, _mapper);
            DeleteAuthorQueryValidator validator = new DeleteAuthorQueryValidator();
            query.AuthorId = id;
            validator.ValidateAndThrow(query);
            query.Handle();
            return Ok($"{id} id'sine sahip yazar basarili bir sekilde silindi!");
        }
    }
}