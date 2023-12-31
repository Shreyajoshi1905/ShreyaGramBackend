using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShreyaGramBackend.Model
{
    public class ClientBlogModel
    {
        [Key]
        public int BlogId {get;set;} 
        public string Title { get; set; } = null!;
        public string Content{get;set;} = null!;
        public string UserAuthor{get; set;} = null!;
        public DateTime DateOf{get;set;}
    }
}