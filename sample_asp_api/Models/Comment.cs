using System.ComponentModel.DataAnnotations;

namespace sample_api.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int? StockId { get; set; }
        public Stock? Stock { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
