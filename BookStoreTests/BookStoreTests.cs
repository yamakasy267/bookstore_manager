using BooksStore;
using BooksStore.Controllers;
using BooksStore.Models;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Execution.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace BookStoreTests {

	public class BookStoreTests {
		private IServiceCollection services;

		/// <summary>
		/// Регистрируем сервис БД и создаем начальные данные в ней
		/// </summary>
		/// <param name="output"></param>
		public BookStoreTests ( ITestOutputHelper output ) {
			services = new ServiceCollection ();
			services.AddDbContextFactory<AppDbContext> ( option => option.UseInMemoryDatabase ( "TestDataBase" ) );

			var provider = services.BuildServiceProvider ();
			var context = provider.GetRequiredService<AppDbContext> ();
			context.Database.EnsureDeleted ();
			context.Database.EnsureCreated ();

			context.AddRange (
				new AuthorModel { Id = 1 , Name = "Ilya" , Birthday = new DateOnly ( 2000 , 01 , 23 ) } ,
				new BooksModel { Id = 1 , Name = "Bulya" , AuthorId = 1 , DatePublication = new DateOnly ( 2023 , 09 , 14 ) , Price = 123 } ,
				new GenreModel { Id = 1 , Name = "Scrim" } );

			context.SaveChanges ();
		}

		/// <summary>
		/// Имитируем работу Graphql server и посылаем query запрос
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task QueryTest () {
			var result = await services.AddGraphQLServer ()
				 .RegisterDbContextFactory<AppDbContext> ()
				 .AddQueryType<Query> ()
				 .AddProjections ()
				 .AddSorting ()
				 .AddFiltering ()
				 .ExecuteRequestAsync ( "{books{name, datePublication, }}" );
			Assert.True ( result.ToJson ().Contains ( "Bulya" ) );
		}

		/// <summary>
		/// Создаем экземпляры books и записываем в БД
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task MutationTest () {
			var mutation = new Mutation ();
			var provider = services.BuildServiceProvider ();
			var context = provider.GetRequiredService<AppDbContext> ();
			var book = new BooksModel () {
				AuthorId = 1 ,
				Id = 2 ,
				DatePublication = new DateOnly ( 2000 , 05 , 01 ) ,
				Price = 432 ,
				Name = "TestMutation"
			};
			var genre = new List<string> () { "Scrim" };
			var result = await mutation.AddBookAsync ( book , context , genre );
			Assert.Equal ( "TestMutation" , context.Books.Find ( 2 ).Name );
		}
	}
}
