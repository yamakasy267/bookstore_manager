using BooksStore;
using BooksStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreTests
{
    public class DbContextTest : AppDbContext
    {
        private DbContextTest(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorModel>().HasData(
                new AuthorModel { Id = 1, Name = "Ilya", Birthday = new DateOnly(2000, 09, 27) }
                );
            modelBuilder.Entity<BooksModel>().HasData(
                new BooksModel { Id = 1, Name = "c#", AuthorId = 1, DatePublication = new DateOnly(2023, 11, 24), Price = 123 });
        }
    }
}