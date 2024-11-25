using BooksStore.Models;

namespace BooksStore.Controllers
{
    public partial class Mutation
    {
        public async Task<Order> AddOrder(Order input, [Service] AppDbContext context, ICollection<int> books)
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
}