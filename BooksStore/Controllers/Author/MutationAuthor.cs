using BooksStore.Models;

namespace BooksStore.Controllers.Author
{
    public class MutationAuthor
    {
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

    public record class InsertAuthor(string name, string birthday, string biografy);
    public record class UpdateAuthor(int id, string name = null, string birthday = null, string biografy = null);
}