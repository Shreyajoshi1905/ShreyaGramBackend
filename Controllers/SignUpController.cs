using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShreyaGramBackend.Model;
using ShreyaGramBackend.Services.Authentication;
namespace ShreyaGramBackend.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SignUpController: ControllerBase
    {   
       // public ISignUpService _signupservice = null!;
        public IAuthenticationService _authservice = null!;
        public  SignUpController(IAuthenticationService authservice){
            _authservice = authservice;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<List<SignUpModel>>>SignUp( LoginModel values){
            return Ok(await _authservice.SaveSignUpInfo(values.UserName , values.Password) );
        }
//[Authorize]
//[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Login")]
        
        public async Task<ActionResult<List<LoginModel>>>VerifyLogin (LoginModel loginValues){
            return Ok(await _authservice.VerifyLogin(loginValues.UserName ,loginValues.Password));
        }
      
        // [HttpGet("GetAll")]
        // public async Task<ActionResult <List<SignUp>>> GetAllSignUp(){
        //     return Ok(await _signupservice.GetAllSignUp());
        // }
        // [HttpGet("{id}")]
        // public async Task<ActionResult <SignUp>>GetSignUpById(int id){
        //     return Ok( await _signupservice.GetSignUpById(id));
        // }
        // [HttpPost()]
        // public async Task<ActionResult<List<SignUp>>> AddSignUp(SignUp newSignUp){
        //     return Ok( await _signupservice.AddSignUp(newSignUp));
        // }
        
    //     [HttpPost("LogIn")]
    //     public async Task<ActionResult<List<LoginModel>>>Login(\LoginModel values){
    //         return Ok( _authservice.Register(values.UserName , values.Password) );
    //     }
    }
}