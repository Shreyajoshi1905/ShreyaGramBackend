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
        public DbSet<SignUpModel> Users{get;set;}
        
        //public DbSet<BlogsModel>Blogs{get;set;}
        public DbSet<ClientBlogModel>BlogsTable{get;set;}
        public DbSet<BookModel> Books{get;set;}
        public DbSet<CartModel> CartTest{get;set;}
        public DbSet<ProductDetailsModel> ProductDetailsCart{get;set;}
        
        // public DbSet<ProductDetailsModel>ProductDetailCartTable{get;set;}

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<BlogsModel>()
        //         .HasOne(b => b.Author)
        //         .WithMany(u => u.Blogs)
        //         .HasForeignKey(b => b.UserId);
        // }
    }
}