using System.ComponentModel.DataAnnotations.Schema;
namespace api.Entities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PageCount { get; set; }
        public string? Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreatedAt { get; } = DateTime.Now;
    }

}