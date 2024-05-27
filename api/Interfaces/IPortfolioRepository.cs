using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfolio(AppUser appUser);
        Task<Portfolio> CreateAsync(Portfolio portfolio);
        Task<Portfolio?> GetPortfolioByIdAsync(int id);
        Task<Portfolio> DeletePortfolio(AppUser appUser, string synbol);
    }
}