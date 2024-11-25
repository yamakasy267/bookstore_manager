using BooksStore.Models;
using HotChocolate.Data;

namespace BooksStore.Controllers
{
    public class Query
    {
        /// <summary>
        /// Get Books
        /// </summary>
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([Service] AppDbContext context) => context.Books;

        /// <summary>
        /// Get Authors
        /// </summary>
        [UseFiltering]
        [UseSorting]
        public IQueryable<Author> GetAuthor([Service] AppDbContext context) => context.Author;

        public IQueryable<Order> GetOrders([Service] AppDbContext context) => context.Orders;
    }
}