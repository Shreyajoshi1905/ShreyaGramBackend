using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShreyaGramBackend.Model;

namespace ShreyaGramBackend.Services.Blogs
{
    public interface IBlogsService
    {
        Task <ServiceResponse<List<ClientBlogModel>>> PostBlogs(ClientBlogModel blog);
        //Task <ServiceResponse<List<BlogsModel>>> GetBlogs();

        Task <ServiceResponse<List<ClientBlogModel>>>GetAllBlogs();

        Task<ServiceResponse<List<ClientBlogModel>>>GetBlogByUserName(string userAuthor);
        Task<string>DeleteBlogById(int blogid);
        Task<ServiceResponse<ClientBlogModel>>GetBlogById(int BlogId);
        Task<ServiceResponse<ClientBlogModel>>EditBlogById(int BlogId ,ClientBlogModel updatedData);
        


    }   
}