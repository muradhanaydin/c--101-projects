using System.ComponentModel.DataAnnotations.Schema;

namespace api
{
    public class CreateBookViewModal
    {
        public string? Title { get; set; }
        public int Category { get; set; }
        public int PageCount { get; set; }
        public string? Publisher { get; set; }
        public DateTime PublishDate { get; set; }
    }

}