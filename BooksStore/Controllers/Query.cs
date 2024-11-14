using BooksStore.Models;
using HotChocolate.Data;

namespace BooksStore.Controllers {

	public class Query {

		/// <summary>
		/// Get Books
		/// </summary>
		[UseProjection]
		[UseFiltering]
		[UseSorting]
		public IQueryable<BooksModel> GetBooks ( [Service] AppDbContext context ) => context.Books;

		/// <summary>
		/// Get Authors
		/// </summary>
		[UseFiltering]
		[UseSorting]
		public IQueryable<AuthorModel> GetAuthor ( [Service] AppDbContext context ) => context.Author;
	}
}
