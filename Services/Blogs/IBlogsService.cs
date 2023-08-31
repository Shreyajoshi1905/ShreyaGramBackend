using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShreyaGramBackend.Model;

namespace ShreyaGramBackend.Services.Blogs
{
    public interface IBlogsService
    {
        Task <ServiceResponse<List<BlogsModel>>> PostBlogs(BlogsModel blog ,string httpHeaderToken );
        //Task <ServiceResponse<List<BlogsModel>>> GetBlogs();
    }
}