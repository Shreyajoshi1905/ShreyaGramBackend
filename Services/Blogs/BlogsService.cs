using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShreyaGramBackend.Controllers;
using ShreyaGramBackend.Data;
using ShreyaGramBackend.Model;

namespace ShreyaGramBackend.Services.Blogs
{
    public class BlogsService:IBlogsService
    {   
        public readonly DataContext _dbcontext;
        public BlogsService(DataContext dbcontext){
            _dbcontext = dbcontext;
        }   
        public async Task <ServiceResponse<List<ClientBlogModel>>> PostBlogs(ClientBlogModel blog ){
            var serviceresponse = new ServiceResponse<List<ClientBlogModel>>();
            try{
                var addblogs  =  _dbcontext.BlogsTable.Add(blog);
                await _dbcontext.SaveChangesAsync();
                serviceresponse.Data = await _dbcontext.BlogsTable.ToListAsync();
            }
            catch(Exception ex){
                serviceresponse.Message= ex.Message;
                   Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);

            }

            return serviceresponse;
        }
        public async Task <ServiceResponse<List<ClientBlogModel>>>GetAllBlogs(){
            var serviceresponse = new ServiceResponse<List<ClientBlogModel>>();
            try{
                var allblogs =await _dbcontext.BlogsTable.ToListAsync();
                serviceresponse.Data = allblogs.ToList();
            }
            catch( Exception ex){
                serviceresponse.Message = ex.Message;
            }
            return serviceresponse;
        }
    public async Task<ServiceResponse<List<ClientBlogModel>>>GetBlogByUserName(string UserAuthor){
    var serviceresponse = new ServiceResponse<List<ClientBlogModel>>();
    try{
        Console.WriteLine(UserAuthor);
        var blogbyusername = await _dbcontext.BlogsTable.Where(blog=> blog.UserAuthor ==UserAuthor ).ToListAsync();
        serviceresponse.Data = blogbyusername;
        serviceresponse.Success = true;
        
    }
    catch(Exception ex){
        serviceresponse.Message = ex.Message;

    }
    Console.WriteLine(serviceresponse.Data);
    return serviceresponse;
   }
   public async Task<string>DeleteBlogById(int blogid){
        string res = "";
        try{
            var blog = await _dbcontext.BlogsTable.FindAsync(blogid);
            if(blog!= null){
            _dbcontext.BlogsTable.Remove(blog);
            await _dbcontext.SaveChangesAsync();
            res = "blog deleted successfully";
            }
        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
            res = "exception";
        }   
        return res;

    }

    public async Task<ServiceResponse<ClientBlogModel>>GetBlogById(int BlogId){
        var serviceresponse = new ServiceResponse<ClientBlogModel>();
        try{    
            var data = _dbcontext.BlogsTable.FirstOrDefault(c=> c.BlogId == BlogId);
            serviceresponse.Data = data;
            await _dbcontext.BlogsTable.ToListAsync();
        }
        catch(Exception ex){
            serviceresponse.Success = false;
            serviceresponse.Message = ex.Message;
        }
        return serviceresponse;
    }

    public async Task<ServiceResponse<ClientBlogModel>>EditBlogById(int BlogId ,ClientBlogModel updatedData){
        var serviceresponse  = new ServiceResponse<ClientBlogModel>();
        try{
            var data = _dbcontext.BlogsTable.FirstOrDefault(e=> e.BlogId == BlogId);
            data.Title  = updatedData.Title;
            data.Content = updatedData.Content;
            await _dbcontext.SaveChangesAsync();
            serviceresponse.Success = true;
        }
        catch(Exception ex){
            serviceresponse.Message = ex.Message;
            serviceresponse.Success = false;
        }
        return serviceresponse;
    }


}
}