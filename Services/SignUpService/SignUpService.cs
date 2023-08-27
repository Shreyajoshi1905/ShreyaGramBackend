// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// //using ShreyaGramBackend.Data;
// using ShreyaGramBackend.Model;

// namespace ShreyaGramBackend.Services.SignUpService
// {
//     public class SignUpService: ISignUpService
//     {   
//         private readonly DataContext _context;
//         public SignUpService(DataContext context){
//             _context  = context;
//         }
        
//         public async Task<ServiceResponse<List<SignUp>>> GetAllSignUp(){
//             var serviceresponse = new ServiceResponse<List<SignUp>>();
//             var DbUsers = await _context.Users.ToListAsync();
//             serviceresponse.Data = DbUsers.ToList();
//             return serviceresponse;
//         }

//         public async Task<ServiceResponse<SignUp>> GetSignUpById(int id){
//             var serviceresponse = new ServiceResponse<SignUp>();
//             serviceresponse.Data =  _context.Users.FirstOrDefault(c => c.Id == id);
//             await _context.Users.ToListAsync();
//             return serviceresponse;
//         }

//         public async Task<ServiceResponse<List<SignUp>>> AddSignUp(SignUp newsignup){

//             var serviceresponse = new ServiceResponse<List<SignUp>>();
//             try{
//                 var AddDbUsers =  _context.Users.Add(newsignup);
//                 await _context.SaveChangesAsync();
//                 serviceresponse.Data = await _context.Users.ToListAsync();
//                 serviceresponse.Message = "User added successfully.";
//             }
//             catch(Exception ex){
//                 serviceresponse.Success = false;
//                 serviceresponse.Message = "Error adding user: " + ex.Message;
//             }
//             return serviceresponse;
//         }

        
//     }
// }