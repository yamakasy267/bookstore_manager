using BooksStore;
using BooksStore.Controllers;
using BooksStore.Models;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata;
using Xunit.Abstractions;
using Xunit;
using System.Runtime.CompilerServices;

using Microsoft.Extensions.DependencyInjection;

using HotChocolate.Stitching.Requests;
using HotChocolate.Execution.Configuration;
using CookieCrumble;

namespace BookStoreTests
{
    public class BookStoreTests
    {
        private readonly ITestOutputHelper output;
        private DbContextOptions<AppDbContext> _contextOptions;

        public BookStoreTests(ITestOutputHelper output)
        {
            this.output = output;
            _contextOptions = new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase("TestDataBase")
        .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
        .Options;

            using var context = new AppDbContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.AddRange(
                new AuthorModel { Id = 1, Name = "Ilya", Birthday = new DateOnly(2000, 01, 23) },
                new BooksModel { Id = 1, Name = "Bulya", AuthorId = 1, DatePublication = new DateOnly(2023, 09, 14), Price = 123 });

            context.SaveChanges();
        }

        [Fact]
        public async Task QueryTest()
        {
            var servise = new ServiceCollection();
            servise.AddDbContextFactory<AppDbContext>(option => option.UseInMemoryDatabase("TestDataBase"));

            var result = await servise.AddGraphQLServer()
                 .RegisterDbContextFactory<AppDbContext>()
                 .AddQueryType<Query>()
                 .AddProjections()
                 .AddSorting()
                 .AddFiltering()
                 .ExecuteRequestAsync("{books{name}}");
            output.WriteLine(result.ToJson());
        }
    }
}