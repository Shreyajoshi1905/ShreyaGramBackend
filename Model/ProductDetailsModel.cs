using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShreyaGramBackend.Model
{
    public class ProductDetailsModel
    { 
        [Key]
        public int Id{get;set;}
        public int ProductId{ get; set; }
        public int Quantity{get;set;}
        public string CartId { get; set; } = null!;
        public int Paymentdetails { get; set; }
    }
}