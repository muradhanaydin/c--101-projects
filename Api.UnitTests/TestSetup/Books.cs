using api.DBOperations;
using api.Entities;

namespace TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                new Book{
                    Title = "Ornek Kitap 1",
                    Publisher = "ABC Yayincilik",
                    CategoryId = 3,
                    PageCount = 243,
                    AuthorId = 1,
                    PublishDate = new DateTime(2001,06,12)
                },
                new Book{
                    Title = "Rastgele Kitap 2",
                    Publisher = "YeniDunya",
                    CategoryId = 1,
                    PageCount = 421,
                    AuthorId = 3,
                    PublishDate = new DateTime(2012,10,22)
                },
                new Book{
                    Title = ".Sallama Kitap 3",
                    Publisher = "Martı",
                    CategoryId = 5,
                    PageCount = 160,
                    AuthorId = 2,
                    PublishDate = new DateTime(2022,5,4)
                },
                new Book{
                    Title = "Hicbir Kitap 4",
                    Publisher = "Derecik",
                    CategoryId = 1,
                    PageCount = 232,
                    AuthorId = 1,
                    PublishDate = new DateTime(2023,1,15)
                }
            );
            context.SaveChanges();
        }
    }
}