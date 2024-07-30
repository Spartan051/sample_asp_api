using sample_api.Models;
using sample_asp_api.Dtos.StockDto;
using sample_asp_api.Helpers;

namespace sample_api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query); 
        Task<Stock?> GetByIdAsync(int id); 
        Task<Stock> CreateAsync(CreateStockDto stockDto); 
        Task<Stock?> UpdateAsync(int id,UpdateStockDto updateDtp); 
        Task<Stock?> DeleteAsync(int id); 
        Task<bool> StockExists(int id);
    }
}
