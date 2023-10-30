using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShreyaGramBackend.Model
{
    public class CartRequestModel
    {
        public string CartId{ get; set; } = null!;
        public int BookId{get;set;}
        public string UserName{get;set;} = null!;
    }
}