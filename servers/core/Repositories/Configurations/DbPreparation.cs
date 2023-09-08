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
            if (!context.Books.Any())
            {
                AddRange<Book>(context);
            }
            if (!context.Authors.Any())
            {
                AddRange<Author>(context);
            }
            if (!context.Users.Any())
            {
                AddRange<User>(context);
            }
            context.SaveChanges();
        }

        private static void AddRange<T>(AppDbContext context)
        {
            Console.WriteLine($"--> Seeding data for {typeof(T).Name}...");

            var list = TestDataLoader.GetList<T>(true);

            if (typeof(T) == typeof(Author))
            {
                foreach (var author in list as List<Author>)
                {
                    if (context.Authors.Find(author.Id) == null)
                        context.Authors.Add(author);
                }
            }
            else if (typeof(T) == typeof(Book))
            {
                foreach (var book in list as List<Book>)
                {
                    if (context.Books.Find(book.Id) == null)
                    {
                        var existingAuthor = context.Authors.Local.FirstOrDefault(author => author.Id == book.Author.Id);
                        if (existingAuthor != null)
                            book.Author = null;

                        context.Books.Add(book);
                    }
                }
            }
            else if (typeof(T) == typeof(User))
            {
                context.Users.AddRange(list as List<User>);
            }
        }
    }
}