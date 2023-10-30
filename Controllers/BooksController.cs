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

        [HttpGet("getbookbyid")]
        public async Task<ActionResult<List<BookModel>>>GetBookById([FromQuery] int bookId){
            return Ok(await _bookservice.GetBookById(bookId));
        }
        [HttpPost("createcart")]
        public async Task<ActionResult<List<BookModel>>>CreateCart(string userName){
            return Ok(await _bookservice.CreateCart(userName));
        }

        [HttpPost("addtocart")]
        public async Task<ActionResult<List<BookModel>>>AddToCart([FromBody] CartRequestModel cartRequest){
            return Ok(await _bookservice.AddProductToCart(cartRequest));
        }
    }
}