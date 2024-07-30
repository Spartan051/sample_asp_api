using sample_api.Models;

namespace sample_asp_api.Dtos.CommentDto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int? StockId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn
        {
            get; set;
        }
    }
}
