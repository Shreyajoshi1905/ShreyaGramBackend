using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShreyaGramBackend.Model;

namespace ShreyaGramBackend.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}
        public DbSet<SignUpModel> User{get;set;}
        public DbSet<BlogsModel>Blogs{get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogsModel>()
                .HasOne(b => b.Author)
                .WithMany(u => u.Blogs)
                .HasForeignKey(b => b.UserId);
        }
    }
}