using BooksStore.Models;

namespace BooksStore.Controllers
{
    public partial class Mutation
    {
        public async Task<Author> AddAuthor(Author input, [Service] AppDbContext context)
        {
            var author = new Author
            {
                Name = input.Name,
                Birthday = input.Birthday,
                Biografy = input.Biografy,
            };
            context.Author.Add(author);
            await context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAuthor([Service] AppDbContext context, UpdateAuthor input)
        {
            var author = context.Author.FirstOrDefault(x => x.Id == input.id);
            if (author == null)
                throw new ArgumentException("Wrong argument id book");

            author.Name = input.name == default ? author.Name : input.name;
            author.Biografy = input.biografy == default ? author.Biografy : input.biografy;
            author.Birthday = input.birthday == default ? author.Birthday : DateOnly.Parse(input.birthday);

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

    public record class UpdateAuthor(
            int id,
            string? name = null,
            string? birthday = default,
            string? biografy = null);
}