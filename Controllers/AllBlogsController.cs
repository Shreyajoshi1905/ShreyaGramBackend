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
    public class AllBlogsController: ControllerBase
    {
    private readonly IBlogsService _blogservice;
    public AllBlogsController(IBlogsService blogservice){
        _blogservice = blogservice;
    }       
    
    [HttpPost("postblogs")]
    public async Task<ActionResult<List<ClientBlogModel>>>PostBlogs(ClientBlogModel blog){
        return Ok(await _blogservice.PostBlogs(blog) );
    }
    [HttpGet("getallblogs")]
    public async Task<ActionResult<List<ClientBlogModel>>>GetAllBlogs(){
        return Ok(await _blogservice.GetAllBlogs());
    }

    [HttpGet("getblogbyusername")]
    public async Task<ActionResult<List<ClientBlogModel>>>GetBlogByUsername([FromQuery] string UserAuthor){
        return Ok(await _blogservice.GetBlogByUserName(UserAuthor));
    }

    [HttpDelete("deleteblogbyid")]
    public async Task<ActionResult<string>>DeleteBlogById([FromQuery] int BlogId ){
        return Ok(await _blogservice.DeleteBlogById(BlogId));
    }
    [HttpGet("getblogbyid")]
    public async Task<ActionResult<BlogsModel>>GetBlogById([FromQuery] int BlogId ){
        return Ok(await _blogservice.GetBlogById(BlogId));
    }
    [HttpPut("editblogbyid")]
    public async Task<ActionResult<BlogsModel>>EditBlogById([FromQuery] int BlogId ,ClientBlogModel updatedData){
        return Ok(await _blogservice.EditBlogById(BlogId , updatedData));
    }

  // [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    //[HttpPost("postBlogs")]
    // public async Task<ActionResult<List<BlogsModel>>>SubmitBlog(ClientBlogModel blog , string HttpHeaderToken){
    //     return Ok(await _blogservice.PostBlogs(blog , HttpHeaderToken));
    // }
    }
}