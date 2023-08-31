using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShreyaGramBackend.Model;
using ShreyaGramBackend.Services.Blogs;

namespace ShreyaGramBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllBlogsController
    {
    private readonly IBlogsService _blogservice;
    public AllBlogsController(IBlogsService blogservice){
        _blogservice = blogservice;
    }       
        
  // [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    //[HttpPost("postBlogs")]
    // public async Task<ActionResult<List<BlogsModel>>>SubmitBlog(ClientBlogModel blog , string HttpHeaderToken){
    //     return Ok(await _blogservice.PostBlogs(blog , HttpHeaderToken));
    // }
    }
}