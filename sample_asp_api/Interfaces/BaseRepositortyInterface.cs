namespace sample_api.Interfaces
{
    public interface IBaseRepository<TEntity,TCreateDto,TUpdateDto>
    {
        Task<List<TEntity>> GetAllAsync(); 
        Task<TEntity?> GetByIdAsync(int id); 
        Task<TEntity> CreateAsync(TCreateDto stockDto); 
        Task<TEntity?> UpdateAsync(int id, TUpdateDto updateDto); 
        Task<TEntity?> DeleteAsync(int id); 
    }
}
