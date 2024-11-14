using BooksStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Controllers
{
    public class Mutation
    {
        public async Task<BooksModel> AddBook(InsertBooks input, [Service] AppDbContext context)
        {
            var book = new BooksModel
            {
                Name = input.name,
                DatePublication = DateTime.Parse(input.datePublication),
                Price = input.price,
                Author = context.Author.Find(input.author)
            };
            context.Books.Add(book);
            await context.SaveChangesAsync();
            return book;
        }

        public async Task<BooksModel> UpdateBook([Service] AppDbContext context, UpdateBooks input)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == input.id);
            if (book == null)
                throw new ArgumentException("Wrong argument id book");

            book.Price = input.price == default ? book.Price : input.price;
            book.Name = input.name == default ? book.Name : input.name;
            book.DatePublication = input.datePublication == default ? book.DatePublication : DateTime.Parse(input.datePublication);
            if (book.Author != default)
            {
                var author = context.Author.FirstOrDefault(x => x.Id == input.author);
                if (author == null)
                    throw new ArgumentException("Wrong argument id author");
                book.Author = author;
            }

            context.Books.Update(book);
            await context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBook([Service] AppDbContext context, int id)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<AuthorModel> AddAuthor(InsertAuthor input, [Service] AppDbContext context)
        {
            var author = new AuthorModel
            {
                Name = input.name,
                Birtday = DateTime.Parse(input.birthday),
                Biografy = input.biografy,
            };
            context.Author.Add(author);
            await context.SaveChangesAsync();
            return author;
        }

        public async Task<AuthorModel> UpdateBook([Service] AppDbContext context, UpdateAuthor input)
        {
            var author = context.Author.FirstOrDefault(x => x.Id == input.id);
            if (author == null)
                throw new ArgumentException("Wrong argument id book");

            author.Name = input.name == default ? author.Name : input.name;
            author.Biografy = input.biografy == default ? author.Biografy : input.biografy;
            author.Birtday = input.birthday == default ? author.Birtday : DateTime.Parse(input.birthday);

            context.Author.Update(author);
            await context.SaveChangesAsync();
            return author;
        }

        public async Task<bool> DeleteAuthor([Service] AppDbContext context, int id)
        {
            var author = context.Author.FirstOrDefault(x => x.Id == id);
            if (author != null)
            {
                context.Author.Remove(author);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }

    public record class InsertBooks(string name, string datePublication, float price, int author);
    public record class UpdateBooks(
        int id,
        string? name = null,
        string? datePublication = default,
        float price = default,
        int author = default);
    public record class InsertAuthor(string name, string birthday, string? biografy);
    public record class UpdateAuthor(
        int id,
        string? name = null,
        string? birthday = null,
        string? biografy = null);
}