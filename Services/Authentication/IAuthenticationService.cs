using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShreyaGramBackend.Model;

namespace ShreyaGramBackend.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task <ServiceResponse<List<SignUpModel>>> SaveSignUpInfo(string UserName , string Password);
         Task <ServiceResponse<List<LoginModel>>> VerifyLogin(string UserName , string Password);
        // Task<ServiceResponse<List<LoginModel>>> SavePasswordHash(string UserName , string Password);
       // string Register(string UserName , string Password);
        
    
    }
}