using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShreyaGramBackend.Data;
using ShreyaGramBackend.Model;

namespace ShreyaGramBackend.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {   
        
        public SignUpModel signupmodel  = new SignUpModel();
        private readonly DataContext _dbcontext;
        private readonly IConfiguration _config;
        public AuthenticationService(DataContext dbcontext , IConfiguration config){
            _dbcontext = dbcontext;
            _config = config;
        }
        public async Task <ServiceResponse<List<SignUpModel>>> SaveSignUpInfo(string UserName , string Password){
            var serviceresponse = new ServiceResponse<List<SignUpModel>>();
            try{
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(Password);
                signupmodel.UserName = UserName;
                signupmodel.PasswordHash = passwordHash;
                _dbcontext.Users.Add(signupmodel);
                await _dbcontext.SaveChangesAsync();
                //serviceresponse.Data = await _dbcontext.User.ToListAsync();
                serviceresponse.Message = "signup done succesfully";
                serviceresponse.Success = true;

            }
            
            catch(Exception ex){
                serviceresponse.Message = ex.Message;
                serviceresponse.Success = false;
            }
            return serviceresponse;
        }
        public async Task <ServiceResponse<List<LoginModel>>>VerifyLogin(string UserName , string Password){
            var serviceresponse = new ServiceResponse<List<LoginModel>>();
            try{
                SignUpModel creds = _dbcontext.Users.FirstOrDefault(u => u.UserName == UserName);
                if(creds == null){
                    serviceresponse.Success = false;
                    serviceresponse.Message= "creds are wrong";
                }
                if(!BCrypt.Net.BCrypt.Verify(Password, creds.PasswordHash)){
                    serviceresponse.Success = false;
                    serviceresponse.Message = "creds are wrong";

                }
                else{
                    string token = createToken(UserName);
                    serviceresponse.Message = token;
                    serviceresponse.Success = true;
                }
            }
            catch(Exception ex){
                serviceresponse.Message = ex.Message;
            }
            return serviceresponse;
        }

       private string createToken(string UserName)
        {
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Email , UserName),
                new Claim(ClaimTypes.Role , "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _config.GetSection("Jwt:Key").Value!));
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Email, UserName),
                new Claim(ClaimTypes.Role, "Admin"),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256Signature)
            };
              var token = tokenHandler.CreateToken(tokenDescriptor);
              Console.WriteLine("hii"+tokenHandler.WriteToken(token));
              return tokenHandler.WriteToken(token);
        }
    
}}
           
//         }
//         //old code
//         // public LoginModel loginmodel = new LoginModel();
//         // public SignUp signup = new SignUp();
//         // private readonly DataContext _context;
//         // private readonly IConfiguration _config;
//         // public AuthenticationService(DataContext context , IConfiguration config ){
//         //         _context = context;
//         //         _config = config;

//         // }

//         // public async Task<ServiceResponse<List<LoginModel>>> SavePasswordHash(string UserName , string Password)
//         // {       
//         //         var serviceresponse = new ServiceResponse<List<LoginModel>>();
//         //         try{

//         //         CreatePasswordHash(Password , out byte[]passwordSalt , out byte[] passwordHash);
//         //         loginmodel.UserName = UserName;
//         //         loginmodel.PasswordSalt = passwordSalt;
//         //         loginmodel.PasswordHash = passwordHash;
//         //         _context.LoginAuth.Add(loginmodel);
//         //         await _context.SaveChangesAsync();
//         //         serviceresponse.Data = await _context.LoginAuth.ToListAsync();
//         //         serviceresponse.Message = "login added ";
//         //         }
                
//         //         catch(Exception ex){
//         //             serviceresponse.Success = false;
//         //             serviceresponse.Message = ex.Message;
//         //         }
//         //         return serviceresponse;
//         //     }
//         // private void CreatePasswordHash(string Password , out byte [] passwordSalt , out byte[] passwordHash){
//         //     using(var hmac = new HMACSHA512(loginmodel.PasswordSalt)){
//         //         passwordSalt = hmac.Key;
//         //         passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
//         //         //passwordHash = BCrypt.Net.BCrypt.HashPassword(Password);
//         //         }
//         // }

//         //public string Register(string UserName , string Password){
//         //     var serviceresponse = new ServiceResponse<List<SignUp>>();
//         //     try{
//         //     using(var hmac = new HMACSHA512()){
//         //     var pashash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
//         //     var verifiedUser = _context.LoginAuth.FirstOrDefault(n => n.UserName == UserName );
//         //     var verifiedPassword  =  _context.LoginAuth.FirstOrDefault(n=>n.PasswordHash.SequenceEqual(pashash) );
//         //     if(verifiedUser!= null  ){
//         //         serviceresponse.Message = "username successfully added";
//         //     }
//         //     if(verifiedPassword!= null){
//         //         serviceresponse.Message = "password successfully added";
//         //     }
            
//         //     else{
//         //         //yConsole.WriteLine("hiiii"+ verifiedUser);
//         //         serviceresponse.Message = "login failed!";
//         //         serviceresponse.Success = false;
//         //         return serviceresponse.Message;
//         //     }
//         //     }
//         //     }
//         //     catch(Exception ex){
//         //     serviceresponse.Success = false;
//         //     serviceresponse.Message = ex.Message;
//         //     return serviceresponse.Message;
//         //     }
//         //     string token = createToken(loginmodel);
//         //     return token;
//         //     }
        

//     }
// }