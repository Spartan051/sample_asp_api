using sample_api.Models;
using sample_asp_api.Dtos.Comment;
using sample_asp_api.Dtos.CommentDto;

namespace sample_api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync(); 
        Task<Comment?> GetByIdAsync(int id); 
        Task<Comment> CreateAsync(Comment commentModel); 
        Task<Comment?> UpdateAsync(int id,Comment updateDtp); 
        Task<Comment?> DeleteAsync(int id); 
    }
}
