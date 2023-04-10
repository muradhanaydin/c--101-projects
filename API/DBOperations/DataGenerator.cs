using api.Entities;
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

                context.Author.AddRange(
                    new Author{
                        Name = "MUSTAFA",
                        Surname = "KARAHANLI",
                        DateOfBirthDay = DateTime.Parse("12/12/2000")
                    },
                    new Author{
                        Name = "FATMA",
                        Surname = "OZGUR",
                        DateOfBirthDay = DateTime.Parse("24/04/1974")
                    },
                    new Author{
                    Name = "SERDAR",
                    Surname = "KABA",
                    DateOfBirthDay = DateTime.Parse("02/10/1985")
                    },
                    new Author{
                        Name = "SELVI",
                        Surname = "OZGUNES",
                        DateOfBirthDay = DateTime.Parse("17/01/1991")
                    }
                );
                context.Category.AddRange(
                    new Category{
                        Name = "Education"
                    },
                    new Category{
                        Name = "Science Fiction"
                    },
                    new Category{
                        Name = "Politics"
                    },
                    new Category{
                        Name = "Philosophy"
                    },
                    new Category{
                        Name = "Other"
                    }
                );
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
}