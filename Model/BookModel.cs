using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShreyaGramBackend.Model
{
    public class BookModel
    {
        [Key]
        public int  BookId { get; set; }
        public string Author{get;set;} = null!;
        public string ImageUrl{get;set;} = null!;
        public string Title{get;set;} = null!;
        public int Amount{get;set;} 
    }
}