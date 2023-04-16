using api.DBOperations;
using api.Entities;

namespace TestSetup
{
    public static class Categories
    {
        public static void AddCategories(this BookStoreDbContext context)
        {
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
        }
    }
}