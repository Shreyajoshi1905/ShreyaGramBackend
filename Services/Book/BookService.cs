using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShreyaGramBackend.Data;
using ShreyaGramBackend.Model;


namespace ShreyaGramBackend.Services.Book
{
    public class BookService:IBookService
    {
        public readonly DataContext _dbcontext;
        public BookService(DataContext dbContext){
            _dbcontext = dbContext;
        }
        public async Task<ServiceResponse<List<BookModel>>> BookAdd(BookModel book){
            var serviceresponse = new ServiceResponse<List<BookModel>>();
            Console.WriteLine("heyyyyyyyyyyyyy"+book);
            try{
                _dbcontext.Books.Add(book);
                await _dbcontext.SaveChangesAsync();
                serviceresponse.Data = await _dbcontext.Books.ToListAsync();

            }
            catch(Exception ex){
                serviceresponse.Success = false;
                serviceresponse.Message = ex.Message;
                Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
            }
        return serviceresponse;
        }
        public async Task<ServiceResponse<List<BookModel>>>GetAllBooks(){
        var serviceresponse = new ServiceResponse<List<BookModel>>();
        try{
            var allblogs  =  await _dbcontext.Books.ToListAsync();
            serviceresponse.Data = allblogs.ToList();
        }       
        catch(Exception ex){
            serviceresponse.Message =ex.Message;
        }
        return serviceresponse;
    }
    }
    
}