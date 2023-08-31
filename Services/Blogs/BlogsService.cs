using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task <ServiceResponse<List<BlogsModel>>> PostBlogs(BlogsModel blog , string httpHeaderToken ){
            var serviceresponse = new ServiceResponse<List<BlogsModel>>();
            if(httpHeaderToken != null){
                
               var tokenHandler = new JwtSecurityTokenHandler();
               // var claims = tokenHandler.GetClaimsAsync(httpHeaderToken).Result;
            }

            return serviceresponse;
         }
    }
}