using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShreyaGramBackend.Model
{
    public class SignUpModel
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }  = null!;
        public string PasswordHash {get; set;} = null!;
        //public ICollection<BlogsModel> Blogs { get; set; }  = null!;
    }
}