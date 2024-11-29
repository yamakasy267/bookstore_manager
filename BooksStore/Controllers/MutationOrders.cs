using BooksStore.Models;

namespace BooksStore.Controllers
{
    public partial class Mutation
    {
        public async Task<Order> AddOrder(OrderIn input, [Service] AppDbContext context, ICollection<int> books)
        {
            var order = new Order
            {
                UserId = input.UserId,
                Sum = input.Sum,
                BooksCount = books.Count,
                Books = context.Books.Where(g => books.Contains(g.Id)).ToList(),
            };

            if (order.Books.Count == 0)
                throw new ArgumentException("Wrong argument Books");

            context.Orders.Add(order);
            await context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrder(int id, [Service] AppDbContext context)
        {
            var order = context.Orders.Find(id);
            if (order != null)
            {
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// класс для получение данных в MutationOrder с игнорированием ненужных полей
    /// </summary>
    public class OrderIn : Order
    {
        [GraphQLIgnore]
        public new User User { get; set; }

        [GraphQLIgnore]
        public new int BooksCount { get; set; }

        [GraphQLIgnore]
        public new ICollection<Book> Books { get; set; }
    }
}