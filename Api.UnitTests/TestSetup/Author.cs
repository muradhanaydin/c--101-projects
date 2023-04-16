using api.DBOperations;
using api.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
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
            context.SaveChanges();
        }
    }
}