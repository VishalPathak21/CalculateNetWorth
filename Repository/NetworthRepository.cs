using CalculateNetWorth9Microservice.DTO;
using CalculateNetWorth9Microservice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CalculateNetWorth9Microservice.Repository
{
    public class NetworthRepository : INetworthRepository
    {

        public readonly NetWorthContext netWorthContext;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(NetworthRepository));




      

        public NetworthRepository(NetWorthContext netWorthContext)
        {
            this.netWorthContext = netWorthContext;
        }





        /// <summary>
        /// GetPortfolioDetails
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<ActionResult<PortfolioDto>> GetPortfolioDetails(int UserId)
        {
            try
            {


                _log4net.Info("NetworthRepository's GetPortfolioDetails Action is called" + UserId);


                var portDetails = await netWorthContext.PortfolioDetails.FirstOrDefaultAsync(p => p.UserId == UserId);

                var stockDetails = await netWorthContext.StockDetails.Where(s => s.PortfolioId == portDetails.PortfolioId).
                                                           Select(s => new UserStockDto { StockId = s.StockId, StockCount = s.Count, StockName = s.StockPriceDetails.StockName, StockPrice = s.StockPriceDetails.StockPrice }).
                                                           ToListAsync();


                var fundDetails = await netWorthContext.MutualFundDetails.Where(m => m.PortfolioId == portDetails.PortfolioId).
                                                              Select(m => new UserFundDto { FundId = m.MutualFundId, FundCount = m.Count, FundName = m.MutualFundPriceDetails.MutualFundName, FundPrice = m.MutualFundPriceDetails.MutualFundPrice }).
                                                              ToListAsync();

                PortfolioDto portfolioDto = new PortfolioDto
                {
                    PortfolioId = portDetails.PortfolioId,
                    StockDetails = stockDetails,
                    MutualFundDetails = fundDetails
                };

                return portfolioDto;
            }
            catch
            {
                throw;
            }
        }









       







        /// <summary>
        /// GetNetWorthWithRespectPorfolioDetails
        /// </summary>
        /// <param name="portfolioDto"></param>
        /// <returns></returns>
        public decimal GetNetWorthWithRespectPorfolioDetails(PortfolioDto portfolioDto)
        {

            try
            {


                _log4net.Info("NetworthRepository's GetNetWorthWithRespectPorfolioDetails Method is called");


                decimal stockWorth = 0;

                foreach (var stock in portfolioDto.StockDetails)
                {
                    var stockDetails = netWorthContext.StockPriceDetails.FirstOrDefault(s => s.StockId == stock.StockId);
                    stockWorth = stockWorth + (stock.StockCount * stockDetails.StockPrice);

                }


                decimal fundWorth = 0;
                foreach (var fund in portfolioDto.MutualFundDetails)
                {

                    var fundDetails = netWorthContext.MutualFundPriceDetails.FirstOrDefault(s => s.MutualFundId == fund.FundId);
                    fundWorth = fundWorth + (fund.FundCount * fundDetails.MutualFundPrice);

                }

                return (stockWorth + fundWorth);

            }
            catch 
            {
                throw;
            }

        }


















        /// <summary>
        /// GetStockDetails with respect to sellingdetails
        /// </summary>
        /// <param name="sellDto"></param>
        /// <returns></returns>
        public StockDetails GetStockDetails(SellDto sellDto)
        {
            try
            {

                _log4net.Info("NetworthRepository's GetStockDetails Method is called");


                var stockDetails = netWorthContext.StockDetails.FirstOrDefault(s => s.PortfolioId == sellDto.PortfolioId && s.StockId == sellDto.AssetId);
                return stockDetails;
            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// GetFundDetails 
        /// </summary>
        /// <param name="sellDto"></param>
        /// <returns></returns>
        public MutualFundDetails GetFundDetails(SellDto sellDto)
        {
            try
            {

                _log4net.Info("NetworthRepository's GetFundDetails Method is called");


                var fundDetails = netWorthContext.MutualFundDetails.FirstOrDefault(m => m.PortfolioId == sellDto.PortfolioId && m.MutualFundId == sellDto.AssetId);
                return fundDetails;
            }
            catch 
            {
                throw;
            }
        }















        /// <summary>
        /// SellAsset With Respect to Selling Details
        /// </summary>
        /// <param name="sellDto"></param>
        /// <returns></returns>
        public bool SellAsset(SellDto sellDto)
        {
            try
            {

                _log4net.Info("NetworthRepository's SellAsset Method is called");

                dynamic assetDetails;

                if (sellDto == null)
                {
                    return false;
                }


                if (sellDto.AssetType == "Stock")
                {
                    assetDetails = GetStockDetails(sellDto);
                }
                else
                {
                    assetDetails = GetFundDetails(sellDto);
                }



                if (assetDetails.Count == sellDto.AssetCount)
                {


                    if (sellDto.AssetType == "Stock")
                    {
                        netWorthContext.StockDetails.Remove(assetDetails);
                    }
                    else
                    {
                        netWorthContext.MutualFundDetails.Remove(assetDetails);
                    }




                    netWorthContext.SaveChanges();

                    return true;
                }
                else if (assetDetails.Count > sellDto.AssetCount && sellDto.AssetCount > 0)
                {
                    if (sellDto.AssetType == "Stock")
                    {
                        StockDetails stockDetails = (from s in netWorthContext.StockDetails
                                                     where s.PortfolioId == sellDto.PortfolioId && s.StockId == sellDto.AssetId
                                                     select s).SingleOrDefault();

                        stockDetails.Count = stockDetails.Count - sellDto.AssetCount;

                        netWorthContext.SaveChanges();

                        return true;
                    }
                    else
                    {
                        MutualFundDetails mutualFundDetails = (from m in netWorthContext.MutualFundDetails
                                                               where m.MutualFundId == sellDto.AssetId && m.PortfolioId == sellDto.PortfolioId
                                                               select m).SingleOrDefault();


                        mutualFundDetails.Count = mutualFundDetails.Count - sellDto.AssetCount;


                        netWorthContext.SaveChanges();

                        return true;
                    }


                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }









































    }
}
    


     