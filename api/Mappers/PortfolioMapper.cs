using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account.Portfolio;
using api.Models;

namespace api.Mappers
{
    public static class PortfolioMapper
    {
        public static PortfolioDto ToPortfolioDto (this Portfolio portfolioModel)
        {
            return new PortfolioDto 
            {
                AppUserId = portfolioModel.AppUserId,
                StockId = portfolioModel.StockId
            };
        }

        public static Portfolio ToPortfolioModel (this PortfolioDto portfolioDto)
        {
            return new Portfolio
            {
                AppUserId = portfolioDto.AppUserId,
                StockId = portfolioDto.StockId
            };
        }
    }
}