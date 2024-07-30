using sample_api.Models;

namespace sample_asp_api.Dtos.Comment
{
    public class CreateCommentDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}