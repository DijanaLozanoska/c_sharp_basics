using System;
using bookstore_api_10_07_2021.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore_api_10_07_2021.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options)
        : base (options)
        {

        }

        public DbSet<Book> books { get; set; }

        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().HasOne(x => x.Category).WithMany(x => x.Books).HasForeignKey(x => x.CategoryID).OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Category>().HasMany(x => x.Books).WithOne(x => x.Category).HasForeignKey(x => x.BookID).OnDelete(DeleteBehavior.Cascade); //alternativa na prvoto

            //modelBuilder.Entity<Book>().HasOne(x => x.Category).WithMany(x => x.Books).HasForeignKey(x => x.CategoryID);

            //modelBuilder.Entity<Category>().HasMany(x => x.Books).WithOne(x => x.Category).HasForeignKey(x => x.BookID); //alternativa na prvoto

            modelBuilder.Entity<Book>().HasOne(x => x.Category).WithMany(x => x.Books).HasForeignKey(x => x.CategoryID).OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Category>().HasMany(x => x.Books).WithOne(x => x.Category).HasForeignKey(x => x.BookID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
