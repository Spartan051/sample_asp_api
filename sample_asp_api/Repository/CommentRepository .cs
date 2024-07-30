using Microsoft.EntityFrameworkCore;
using sample_api.Data;
using sample_api.Interfaces;
using sample_api.Mappers;
using sample_api.Models;
using sample_asp_api.Dtos.Comment;

namespace sample_api.Repository
{
    public class CommentRepository(ApplicationDBContext applicationDBContext) : ICommentRepository
    {
        private readonly ApplicationDBContext _dbContext = applicationDBContext;

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _dbContext.Comment.AddAsync(commentModel);
            await _dbContext.SaveChangesAsync();

            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
           var commentModel = await _dbContext.Comment.FirstOrDefaultAsync((x)=> x.Id == id);

            if (commentModel == null) return null;

            _dbContext.Comment.Remove(commentModel);

            await _dbContext.SaveChangesAsync();

            return commentModel;
        }

        public Task<List<Comment>> GetAllAsync()
        {
            return _dbContext.Comment.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id) => await _dbContext.Comment.FindAsync(id);

        public async Task<Comment?> UpdateAsync(int id , Comment updateDto) 
        {
            var commentModel = await _dbContext.Comment.FirstOrDefaultAsync((x) => x.Id == id);

            if (commentModel == null) return null;

            commentModel.Title = updateDto.Title;
            commentModel.Content = updateDto.Content;


            await _dbContext.SaveChangesAsync();

            return commentModel;
        }
    }
}
