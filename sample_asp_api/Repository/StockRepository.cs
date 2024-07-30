using Microsoft.EntityFrameworkCore;
using sample_api.Data;
using sample_api.Interfaces;
using sample_api.Mappers;
using sample_api.Models;
using sample_asp_api.Dtos.StockDto;
using sample_asp_api.Helpers;

namespace sample_api.Repository
{
    public class StockRepository(ApplicationDBContext applicationDBContext) : IStockRepository
    {
        private readonly ApplicationDBContext _dbContext = applicationDBContext;

        public async Task<Stock> CreateAsync(CreateStockDto stockDto)
        {
            Stock stockModel = stockDto.ToStockCreateDto();
            await _dbContext.Stock.AddAsync(stockModel);
            await _dbContext.SaveChangesAsync();

            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _dbContext.Stock.FirstOrDefaultAsync((x) => x.Id == id);

            if (stockModel == null) return null;

            _dbContext.Stock.Remove(stockModel);

            await _dbContext.SaveChangesAsync();

            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stocks = _dbContext.Stock.Include((c) => c.Comments).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where((c) => c.CompanyName.Contains(query.CompanyName));
            }

            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where((c) => c.Symbol.Contains(query.Symbol));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDescending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                }
            }

            int skipNumber = (query.PageNumber -1) * query.PageSize;


            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();

        }

        public async Task<Stock?> GetByIdAsync(int id) => await _dbContext.Stock.FindAsync(id);

        public async Task<bool> StockExists(int id) => await _dbContext.Stock.AnyAsync((x) => x.Id == id);


        public async Task<Stock?> UpdateAsync(int id, UpdateStockDto updateDto)
        {
            var stockModel = await _dbContext.Stock.FirstOrDefaultAsync((x) => x.Id == id);

            if (stockModel == null) return null;

            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Industry = updateDto.Industry;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.MarketCap = updateDto.MarketCap;
            stockModel.Purchase = updateDto.Purchase;

            await _dbContext.SaveChangesAsync();

            return stockModel;
        }
    }
}
