using sample_api.Models;
using sample_asp_api.Dtos.Comment;
using sample_asp_api.Dtos.CommentDto;

namespace sample_api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                StockId = commentModel.StockId,
                CreatedOn = commentModel.CreatedOn,
            };
        }

        public static Comment ToCommentCreateDto(this CreateCommentDto commentModel,int stockId)
        {
            return new Comment
            {
                Title = commentModel.Title,
                Content = commentModel.Content,
                StockId=stockId,
            };
        }

        public static Comment ToCommentUpdateDto(this UpdateCommentDto commentModel)
        {
            return new Comment
            {
                Title = commentModel.Title,
                Content = commentModel.Content,
            };
        }

    }
}
