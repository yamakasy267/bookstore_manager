using BooksStore.Models;

namespace BooksStore.Controllers {

	public partial class Mutation {

		public async Task<User> AddUserAsync ( User input , [Service] AppDbContext context ) {
			var user = new User () {
				Name = input.Name ,
				SecondName = input.SecondName ,
				Birtday = input.Birtday ,
				Email = input.Email ,
				HashPassword = input.HashPassword ,
			};
			context.Users.Add ( user );
			await context.SaveChangesAsync ();
			return user;
		}

		public string Login ( string email , string passwod , [Service] AppDbContext context ) {
			var user = context.Users.Find ( email );
			if ( user == null )
				throw new ArgumentException ( "Wrong data" );
			return null;
		}
	}
}
