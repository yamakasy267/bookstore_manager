using BooksStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStore {

	public class AppDbContext : DbContext {

		public AppDbContext ( DbContextOptions<AppDbContext> options )
			: base ( options ) {
		}

		public DbSet<UsersModel> Users { get; set; }
		public DbSet<BooksModel> Books { get; set; }
		public DbSet<GenreBooksModel> GenreBooks { get; set; }
		public DbSet<AuthorModel> Author { get; set; }
		public DbSet<GenreModel> Genre { get; set; }
		public DbSet<OrdersBooksModel> OrdersBooks { get; set; }
		public DbSet<OrdersModel> Orders { get; set; }
	}
}
