using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if(stockModel == null) 
            {
                return null;
            }

            _context.Stock.Remove(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            // return await _context.Stock.Include(c => c.Comments).ToListAsync();
            var stock = _context.Stock.Include(c => c.Comments).AsQueryable();
            
            if(!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stock = stock.Where(s => s.CompanyName.Contains(query.CompanyName));
            }

            if(!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stock = stock.Where(s => s.Symbol.Contains(query.Symbol));
            }

            if(!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stock = query.isDescending ? stock.OrderByDescending(s => s.Symbol) : stock.OrderBy(s => s.Symbol);
                }
            }

            var skipNumber = (query.pageNumber -1) * query.pageSize;

            return await stock.Skip(skipNumber).Take(query.pageSize).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stock.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Stock?> GetBySymbolAsync(string symbol)
        {
            return await _context.Stock.FirstOrDefaultAsync(s => s.Symbol == symbol);
        }

        public async Task<bool> StockExists(int id)
        {
            return await _context.Stock.AnyAsync(x => x.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var existingStock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if(existingStock == null)
            {
                return null;
            }
            existingStock.Symbol = stockDto.Symbol;
            existingStock.CompanyName = stockDto.CompanyName;
            existingStock.Purchase = stockDto.Purchase;
            existingStock.LastDiv = stockDto.LastDiv;
            existingStock.Industry = stockDto.Industry;
            existingStock.MarketCap = stockDto.MarketCap;
            
            await _context.SaveChangesAsync();

            return existingStock;
        }
    }
}