using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShreyaGramBackend.Model;

namespace ShreyaGramBackend.Services.Book
{
    public interface IBookService
    {
        Task<ServiceResponse<List<BookModel>>> BookAdd(BookModel book);
        Task<ServiceResponse<List<BookModel>>>GetAllBooks();
    }
}