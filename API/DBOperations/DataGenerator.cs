using Microsoft.EntityFrameworkCore;

namespace api.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any()){
                    return;
                }
                context.Books.AddRange(new Book{
                    Title = "Lean Startup",
                    Publisher = "Kim Van Yueka",
                    Category = 3,
                    PageCount = 243,
                    PublishDate = new DateTime(2001,06,12)
                },
                new Book{
                    Title = "C# Programlama Dili ve Yazilim Tasarimi",
                    Publisher = "Papatya Yayincilik",
                    Category = 1,
                    PageCount = 421,
                    PublishDate = new DateTime(2012,10,22)
                },
                new Book{
                    Title = "Harry Potter Buyu Kitabi",
                    Publisher = "Martı Yayınları",
                    Category = 5,
                    PageCount = 160,
                    PublishDate = new DateTime(2022,5,4)
                },
                new Book{
                    Title = "SQL Server 2022",
                    Publisher = "Kodlab",
                    Category = 1,
                    PageCount = 232,
                    PublishDate = new DateTime(2023,1,15)
                });
                context.SaveChanges();
            }
            
        }
    }
}