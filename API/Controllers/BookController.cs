using Microsoft.AspNetCore.Mvc;
using api.DBOperations;
using api.BookOperations;
using api.BookOperations.CreateBook;
using api.BookOperations.UpdateBook;
using api.Modal;
using AutoMapper;

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
    public IActionResult GetById(string id){
        GetBookByIdQuery query = new GetBookByIdQuery(_context , _mapper);
        var result = query.Handle(id);
        return Ok(result);
    }

    //POST
    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookViewModal book)
    {
        CreateBookQuery query = new CreateBookQuery(_context , _mapper);
        try
        {
            query.Handle(book);
            return Ok("Kitap Basariyla eklendi!");
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //Update
    [HttpPut("{id}")]
    public IActionResult UpdateBook(string id , [FromBody] UpdateBookViewModal book){
        UpdateBookQuery query = new UpdateBookQuery(_context);
        try
        {
            query.Handle(id,book);
            return Ok("Kitap Basariyla guncellendi!");
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //Delete
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(string id){
        DeleteBookQuery query = new DeleteBookQuery(_context);
        try
        {
            query.Handle(id);
            return Ok("Kitap basariyla silindi!");
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
