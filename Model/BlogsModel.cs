using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShreyaGramBackend.Model
{
    public class BlogsModel
    {
        [Key]
        public int BlogId { get; set; }
        public string Title { get; set; } = null!;
        public string Content{get;set;} = null!;
        public string UserAuthor{get;set;} = null!;
        public string DateTime{get;set;} = null!;
        public int UserId{get;set;} 
        public SignUpModel Author { get; set;} = null!;
        
    }
}