using Microsoft.EntityFrameworkCore;
using HotChocolate.AspNetCore.Voyager;
using BooksStore.Controllers.Books;
using BooksStore.Controllers.Author;
using BooksStore.Controllers;

namespace BooksStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextFactory<AppDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddGraphQLServer()
                .RegisterDbContextFactory<AppDbContext>()
                .AddQueryType<Query>()
                .AddMutationType<MutationBooks>()
                .AddMutationType<MutationAuthor>()
                .AddProjections()
                .AddSorting()
                .AddFiltering();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/api");
            });
        }
    }
}