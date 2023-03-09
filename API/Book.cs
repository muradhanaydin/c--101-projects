using System.ComponentModel.DataAnnotations.Schema;
namespace api;

public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Title { get; set; }
    public int Category { get; set; }
    public int PageCount { get; set; }
    public string? Publisher { get; set; }
    public DateTime PublishDate { get; set; }
}
