using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShreyaGramBackend.Model;
using ShreyaGramBackend.Services.Book;

namespace ShreyaGramBackend.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private IBookService _bookservice;
        public BooksController(IBookService bookservice){
            _bookservice = bookservice;
        }
        [HttpPost("addbook")]
        public async Task<ActionResult<List<BookModel>>>AddBook(BookModel book){
            return Ok(await _bookservice.BookAdd(book));    
        }
        [HttpGet("getallbooks")]
        public async Task<ActionResult<List<BookModel>>>GetAllBooks(){
            return Ok(await _bookservice.GetAllBooks());
        }
    }
}