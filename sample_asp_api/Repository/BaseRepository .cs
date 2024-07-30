//using Microsoft.EntityFrameworkCore;
//using sample_api.Data;
//using sample_api.Dtos;
//using sample_api.Interfaces;
//using sample_api.Mappers;
//using sample_api.Models;

//namespace sample_api.Repository
//{
//    public class BaseRepository<TEntity, TCreateDto, TUpdateDto>(
//        ApplicationDBContext applicationDBContext
//        ) : IBaseRepository<TEntity, TCreateDto, TUpdateDto>
//    {
//        private readonly ApplicationDBContext _dbContext = applicationDBContext;

//        public async Task<TEntity> CreateAsync(TEntity stockModel)
//        {
//            await _dbContext.Stock.AddAsync(stockModel);
//            await _dbContext.SaveChangesAsync();

//            return stockModel;
//        }

//        public async Task<Stock?> DeleteAsync(int id)
//        {
//           var stockModel = await _dbContext.Stock.FirstOrDefaultAsync((x)=> x.Id == id);

//            if (stockModel == null) return null;

//            _dbContext.Stock.Remove(stockModel);

//            await _dbContext.SaveChangesAsync();

//            return stockModel;
//        }

//        public Task<List<TEntity>> GetAllAsync()
//        {
//            return _dbContext.Stock.ToListAsync();
//        }

//        public async Task<Stock?> GetByIdAsync(int id) => await _dbContext.Stock.FindAsync(id);

//        public async Task<Stock?> UpdateAsync(int id ,UpdateStockDto updateDto) 
//        {
//            var stockModel = await _dbContext.Stock.FirstOrDefaultAsync((x) => x.Id == id);

//            if (stockModel == null) return null;

//            stockModel.Symbol = updateDto.Symbol;
//            stockModel.CompanyName = updateDto.CompanyName;
//            stockModel.Industry = updateDto.Industry;
//            stockModel.LastDiv = updateDto.LastDiv;
//            stockModel.MarketCap = updateDto.MarketCap;
//            stockModel.Purchase = updateDto.Purchase;

//            await _dbContext.SaveChangesAsync();

//            return stockModel;
//        }


//    }
//}
