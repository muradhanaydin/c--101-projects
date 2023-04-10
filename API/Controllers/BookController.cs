using Microsoft.AspNetCore.Mvc;
using api.DBOperations;
using AutoMapper;
using api.Application.BookOperations.Queries.GetBook;
using api.Application.BookOperations.Commands.CreateBook;
using api.Application.BookOperations.Commands.UpdateBook;
using api.Application.BookOperations.Commands.DeleteBook;
using api.Application.BookOperations.Queries.GetBookById;
using FluentValidation;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class BookController : ControllerBase
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public BookController(BookStoreDbContext context , IMapper mapper){
        _context = context;
        _mapper = mapper;
    }
    
    //GET
    [HttpGet]
    public IActionResult GetBooks(){
        GetBooksQuery query = new GetBooksQuery(_context , _mapper);
        var result = query.Handle();
        return Ok(result);
    } 

    [HttpGet("{id}")]
    public IActionResult GetById(int id){
        GetBookByIdQuery query = new GetBookByIdQuery(_context , _mapper);
        GetBookByIdQueryValidator validator = new GetBookByIdQueryValidator();
        query.BookId = id;
        validator.ValidateAndThrow(query);
        var result = query.Handle();
        return Ok(result);
    }

    //POST
    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookViewModal book)
    {
        CreateBookQuery query = new CreateBookQuery(_context , _mapper);
        query.Handle(book);
        return Ok("Kitap Basariyla eklendi!");
    }

    //Update
    [HttpPut("{id}")]
    public IActionResult UpdateBook(string id , [FromBody] UpdateBookViewModal book){
        UpdateBookQuery query = new UpdateBookQuery(_context);
        query.Handle(id,book);
        return Ok("Kitap Basariyla guncellendi!");
    }

    //Delete
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(string id){
        DeleteBookQuery query = new DeleteBookQuery(_context);
        query.Handle(id);
        return Ok("Kitap basariyla silindi!");
    }
}