using BooksStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Controllers
{
    public partial class Mutation
    {
        public async Task<Book> AddBookAsync(BookIn input, [Service] AppDbContext context, ICollection<int> genres)
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

        public async Task<Book> UpdateBookAsync([Service] AppDbContext context, UpdateBook input)
        {
            var book = context.Books.Find(input.Id);
            if (book == null)
                throw new ArgumentException("Wrong argument id book");

            book.Price = input.Price == default ? book.Price : input.Price;
            book.Name = input.Name == default ? book.Name : input.Name;
            book.DatePublication = input.DatePublication == default ? book.DatePublication : input.DatePublication;
            if (book.Author != default)
            {
                var author = context.Author.Find(input.AuthorId);
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

    public class BookIn : Book
    {
        [GraphQLIgnore]
        public new Author Author { get; set; }

        [GraphQLIgnore]
        public new ICollection<Genre> Genre { get; set; }
    }
}