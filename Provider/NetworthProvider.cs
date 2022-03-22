using CalculateNetWorth9Microservice.DTO;
using CalculateNetWorth9Microservice.Models;
using CalculateNetWorth9Microservice.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalculateNetWorth9Microservice.Provider
{
    public class NetworthProvider : INetworthProvider
    {

        public readonly INetworthRepository networthRepository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(NetworthProvider));

        public NetworthProvider(INetworthRepository networthRepository)
        {
            this.networthRepository = networthRepository;
        }






        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Task<ActionResult<PortfolioDto>> GetPortfolioDetails(int UserId)
        {


            try
            {
                _log4net.Info("NetworthProvider's GetPortfolioDetails Method is called");

                return networthRepository.GetPortfolioDetails(UserId);
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
                _log4net.Info("NetworthProvider's portfolioDto Method is called");

                return networthRepository.GetNetWorthWithRespectPorfolioDetails(portfolioDto);
            }
            catch
            {
                throw;
            }
        }





        /// <summary>
        /// SellAsset with Respect to SellingDetails
        /// </summary>
        /// <param name="sellDto"></param>
        /// <returns></returns>
        public bool SellAsset(SellDto sellDto)
        {
            try
            {
                _log4net.Info("NetworthProvider's SellAsset Method is called");

                return networthRepository.SellAsset(sellDto);
            }
            catch
            {
                throw;
            }
        }







      
    }
}
