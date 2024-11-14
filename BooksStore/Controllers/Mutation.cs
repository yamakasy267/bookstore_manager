using BooksStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Controllers {

	public class Mutation {

		public async Task<BooksModel> AddBook ( InsertBooks input , [Service] AppDbContext context ) {
			var book = new BooksModel {
				Name = input.name ,
				DatePublication = DateTime.Parse ( input.datePublication ) ,
				Price = input.price ,
				Author = context.Author.Find ( input.author )
			};
			context.Books.Add ( book );
			await context.SaveChangesAsync ();
			return book;
		}

		public async Task<BooksModel> UpdateBook ( [Service] AppDbContext context , InsertBooks input ) {
			var book = new BooksModel {
				Name = input.name ,
				DatePublication = DateTime.Parse ( input.datePublication ) ,
				Price = input.price ,
				Author = context.Author.Find ( input.author )
			};
			context.Books.Update ( book );
			await context.SaveChangesAsync ();
			return book;
		}

		public async Task<bool> DeleteBook ( [Service] AppDbContext context , int id ) {
			var book = context.Books.FirstOrDefault ( x => x.Id == id );
			if ( book != null ) {
				context.Books.Remove ( book );
				await context.SaveChangesAsync ();
				return true;
			}
			return false;
		}
	}
}
