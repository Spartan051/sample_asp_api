using Microsoft.AspNetCore.Mvc;
using sample_api.Interfaces;
using sample_api.Mappers;
using sample_api.Models;
using sample_asp_api.Dtos.StockDto;
using sample_asp_api.Helpers;

namespace sample_api.Controllers
{

    [Route("api/[controller]")]
    public class StockController(
        IStockRepository stockRepository
        ) : Controller
    {
        private readonly IStockRepository _stockRepo = stockRepository;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Stock? stock = await _stockRepo.GetByIdAsync(id);

            if (stock == null) return NotFound();

            return Ok(stock.ToStockDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query )
        {
            List<Stock> stocks = await _stockRepo.GetAllAsync(query);

            IEnumerable<StockDto> stockList = stocks.Select((s) => s.ToStockDto());

            return Ok(stockList);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockDto stockDto)
        {
            Stock? stockModel = await _stockRepo.CreateAsync(stockDto);

            return  CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDto updateStockDto)
        {
            var stockModel = await _stockRepo.UpdateAsync(id, updateStockDto);

            if (stockModel == null) return NotFound();

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Stock? stockModel = await _stockRepo.DeleteAsync(id);

            if (stockModel == null) return NotFound();

            return NoContent();
        }
    }
}
