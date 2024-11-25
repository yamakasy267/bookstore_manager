using BooksStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Controllers
{
    public partial class Mutation
    {
        public async Task<Book> AddBookAsync(Book input, [Service] AppDbContext context, ICollection<int> genres)
        {
            var book = new Book
            {
                Name = input.Name,
                DatePublication = input.DatePublication,
                Price = input.Price,
                Author = context.Author.Find(input.AuthorId),
                Genre = context.Genre.Where(g => genres.Contains(g.Id)).ToList(),
            };
            if (book.Author is null)
                throw new ArgumentException("Wrong argument AuthorId");
            if (book.Genre.Count == 0)
                throw new ArgumentException("Wrong argument Genre");

            context.Books.Add(book);
            await context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBookAsync([Service] AppDbContext context, UpdateBooks input)
        {
            var book = context.Books.Find(input.id);
            if (book == null)
                throw new ArgumentException("Wrong argument id book");

            book.Price = input.price == default ? book.Price : input.price;
            book.Name = input.name == default ? book.Name : input.name;
            book.DatePublication = input.datePublication == default ? book.DatePublication : DateOnly.Parse(input.datePublication);
            if (book.Author != default)
            {
                var author = context.Author.Find(input.author);
                if (author == null)
                    throw new ArgumentException("Wrong argument id author");
                book.Author = author;
            }

            context.Books.Update(book);
            await context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBookAsync([Service] AppDbContext context, int id)
        {
            var book = context.Books.Find(id);
            if (book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public record class UpdateBooks(
            int id,
            string? name = null,
            string? datePublication = default,
            float price = default,
            int author = default);
    }
}