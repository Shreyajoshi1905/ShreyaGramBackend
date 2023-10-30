using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShreyaGramBackend.Model
{
    public class CartModel
    {
        [Key]
        public int Id{get;set;}
        public string CartId{get;set;} = null!;
        public string UserName{get;set;} = null!;
        public DateTime CreatedAt { get; set; }
        //public required List<ProductDetailsModel> ProductDetails{ get; set; }
        
    }
}