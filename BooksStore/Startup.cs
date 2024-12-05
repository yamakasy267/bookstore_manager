using Microsoft.EntityFrameworkCore;
using BooksStore.Controllers;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BooksStore {

	public class Startup {

		public Startup ( IConfiguration configuration ) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices ( IServiceCollection services ) {
			var signingKey = new SymmetricSecurityKey (
			Encoding.UTF8.GetBytes ( "MySuperSecretKey" ) );

			services.AddDbContextFactory<AppDbContext> ( options =>
				options.UseNpgsql ( Configuration.GetConnectionString ( "DefaultConnection" ) ) );
			services.AddControllers ();
			services.AddAuthentication ( "Bearer" )
				.AddJwtBearer ( option => {
					option.TokenValidationParameters = new TokenValidationParameters {
						ValidIssuer = "https://auth.chillicream.com" ,
						ValidAudience = "https://graphql.chillicream.com" ,
						ValidateIssuerSigningKey = true ,
						IssuerSigningKey = signingKey
					};
				} );
			services.AddAuthorization ();
			services.AddEndpointsApiExplorer ();
			services.AddSwaggerGen ();
			services.AddGraphQLServer ()
				.AddAuthorizationCore ()
				.RegisterDbContextFactory<AppDbContext> ()
				.AddQueryType<Query> ()
				.AddMutationType<Mutation> ()
				.AddProjections ()
				.AddSorting ()
				.AddFiltering ();
		}

		public void Configure ( IApplicationBuilder app , IWebHostEnvironment env ) {
			if ( env.IsDevelopment () ) {
				app.UseSwagger ();
				app.UseSwaggerUI ();
			}
			app.UseHttpsRedirection ();
			app.UseStaticFiles ();
			app.UseRouting ();
			app.UseAuthorization ();
			app.UseAuthentication ();
			app.UseEndpoints ( endpoints => {
				endpoints.MapGraphQL ( "/api" );
			} );
		}
	}
}
