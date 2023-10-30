using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShreyaGramBackend.Data;
using ShreyaGramBackend.Model;


namespace ShreyaGramBackend.Services.Book
{
    public class BookService:IBookService
    {
        public readonly DataContext _dbcontext;
        public BookService(DataContext dbContext){
            _dbcontext = dbContext;
        }
        public async Task<ServiceResponse<List<BookModel>>> BookAdd(BookModel book){
            var serviceresponse = new ServiceResponse<List<BookModel>>();
            Console.WriteLine("heyyyyyyyyyyyyy"+book);
            try{
                _dbcontext.Books.Add(book);
                await _dbcontext.SaveChangesAsync();
                serviceresponse.Data = await _dbcontext.Books.ToListAsync();

            }
            catch(Exception ex){
                serviceresponse.Success = false;
                serviceresponse.Message = ex.Message;
                Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
            }
        return serviceresponse;
        }
        public async Task<ServiceResponse<List<BookModel>>>GetAllBooks(){
        var serviceresponse = new ServiceResponse<List<BookModel>>();
        try{
            var allblogs  =  await _dbcontext.Books.ToListAsync();
            serviceresponse.Data = allblogs.ToList();
        }       
        catch(Exception ex){
            serviceresponse.Message =ex.Message;
        }
        return serviceresponse;
    }

    public async Task<ServiceResponse<BookModel>>GetBookById(int BookId){
        var serviceresponse = new ServiceResponse<BookModel>();
        try{
            var item  = _dbcontext.Books.FirstOrDefault(c=> c.BookId == BookId);
            await _dbcontext.Books.ToListAsync();
            serviceresponse.Data = item;
            serviceresponse.Success = true;
        }
        catch(Exception ex){
            serviceresponse.Message= ex.Message;
            serviceresponse.Success = false;
        }
        return serviceresponse;
        }
        public async Task<ServiceResponse<string>>CreateCart(string userName){
            var serviceresponse = new ServiceResponse<string>();
            try{
                var entity = _dbcontext.CartTest.FirstOrDefault(i=> i.UserName == userName);
                if(entity == null){
                    entity = new CartModel{
                        UserName = userName,
                        CartId = Guid.NewGuid().ToString(),
                    };
                    _dbcontext.CartTest.Add(entity);
                    await _dbcontext.SaveChangesAsync();
                    serviceresponse.Data = entity.CartId;
                    serviceresponse.Message = "new cart created";
                }
                else{
                    serviceresponse.Data = entity.CartId;
                    serviceresponse.Message = "card id already present";
                }
            }
            catch(Exception ex){
                    serviceresponse.Message  = ex.InnerException.Message;
            }
            return serviceresponse;
        }

         public async Task<ServiceResponse<List<ProductDetailsModel>>>AddProductToCart(CartRequestModel cr){
                var serviceresponse  = new ServiceResponse<List<ProductDetailsModel>>();
                try{
                    if(cr!=null){
                    var e = await _dbcontext.ProductDetailsCart.Where(id =>id.CartId == cr.CartId).ToListAsync();
                    if(e.Count == 0){
                        var pd = new ProductDetailsModel(){
                            ProductId = cr.BookId,
                            CartId = cr.CartId,
                            Quantity = 1,
                        };
                    _dbcontext.ProductDetailsCart.Add(pd);
                    await _dbcontext.SaveChangesAsync();
                    serviceresponse.Data =await _dbcontext.ProductDetailsCart.ToListAsync();
                    
                    }
                    else{
                        var product = _dbcontext.ProductDetailsCart.FirstOrDefault(i => i.ProductId == cr.BookId);
                        if(product!= null){
                            product.Quantity ++;
                        }
                        else{
                            product.CartId = cr.CartId;
                            product.ProductId = cr.BookId;
                            product.Quantity = 1;
                             _dbcontext.ProductDetailsCart.Add(product);

                        }
                        await  _dbcontext.SaveChangesAsync();
                        serviceresponse.Data = await _dbcontext.ProductDetailsCart.ToListAsync();
                    }
                    }  
                }
                catch(Exception ex){
                    serviceresponse.Message = ex.InnerException.Message;
                }
                return serviceresponse;
         }
    //     public async Task<ServiceResponse<List<CartModel>>>AddProductToCart(CartRequestModel cr){
    //         var serviceresponse = new ServiceResponse<List<CartModel>>();
    //         try{
    //             var entity =  _dbcontext.CartTest.FirstOrDefault(id =>  id.CartId == cr.CartId);
    //             if(entity == null){
    //                 var newCart = new CartModel{
    //                 CartId = Guid.NewGuid().ToString(),
    //                 CreatedAt = DateTime.Now,
    //                 ProductDetails= new List<ProductDetailsModel>() ,// You should initialize Items with the actual product
    //                 UserName = cr.UserName
    //             };
    //              var newProductDetail = new ProductDetailsModel
    //             {
    //             ProductId = cr.BookId, // Replace cr.BookId with cr.ProductId
    //             Quantity = 1, // Set the initial quantity to 1 or your desired value
    //             Cart = newCart // Set the Cart property
    //             };
    //              newCart.ProductDetails.Add(newProductDetail);
    //             _dbcontext.CartTest.Add(newCart);

    //             await _dbcontext.SaveChangesAsync();
    //             }
                
    //             else
    //             {
    //                 var productDetail = entity.ProductDetails.FirstOrDefault(pd => pd.ProductId == cr.BookId); 
    //                 if (productDetail != null){
    //                     productDetail.Quantity += 1;
    //                 }
    //                 else{
    //                     entity.ProductDetails.Add(new ProductDetailsModel
    //                     {
    //                         ProductId = cr.BookId,
    //                         Quantity = 1, // Set the initial quantity to 1 or your desired value
    //                     });
    //                 }
                     
    //             }
    //             await _dbcontext.SaveChangesAsync();
    //             var data = await _dbcontext.CartTest.ToListAsync();
    //             serviceresponse.Data = data;
    //         }
    //         catch(Exception ex){
    //             Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
    //             serviceresponse.Message = ex.InnerException?.Message;
    //         }
    //     return serviceresponse;
    //     }
    }
    
    
}