using ReadersCorner.Core.Models;
using ReadersCorner.Core.Tests.Services.Utils;

namespace ReadersCorner.Core.Repositories.Configurations
{
    public static class DbPreparation
    {
        public static void Populate(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Authors.Any())
            {
                AddRange<Author>(context);
            }
            if (!context.Books.Any())
            {
                AddRange<Book>(context);
            }
            context.SaveChanges();
        }

        private static void AddRange<T>(AppDbContext context)
        {
            Console.WriteLine($"--> Seeding data for {typeof(T).Name}...");

            var list = TestDataLoader.GetList<T>(true);

            if (typeof(T) == typeof(Author))
            {
                context.Authors.AddRange(list as List<Author>);
            }
            else if (typeof(T) == typeof(Book))
            {
                context.Books.AddRange(list as List<Book>);
            }
        }
    }
}