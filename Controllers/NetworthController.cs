using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CalculateNetWorth9Microservice.Provider;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using CalculateNetWorth9Microservice.DTO;
using CalculateNetWorth9Microservice.Models;

namespace CalculateNetWorth9Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NetworthController : ControllerBase
    {


        public INetworthProvider networthProvider;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(NetworthController));




        


        public NetworthController(INetworthProvider networthProvider)
        {

            this.networthProvider = networthProvider;
            
        }
















        /// <summary>
        /// GetPortfolioDetails
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet("GetPortfolioDetails/{UserId}")]
        public Task<ActionResult<PortfolioDto>> GetPortfolioDetails(int UserId)
        {
            Task<ActionResult<PortfolioDto>> portfolioDto = null;
            try
            {
                _log4net.Info("NetworthController's GetPortfolioDetails Action called");

                portfolioDto = networthProvider.GetPortfolioDetails(UserId);
            }
            catch(Exception e)
            {
                _log4net.Error(e.StackTrace);
                
            }

            return portfolioDto;
        }

















        /// <summary>
        /// CalculateNetWorth
        /// </summary>
        /// <param name="portfolioDto"></param>
        /// <returns></returns>
        [HttpPost("CalculateNetWorth")]
        public ActionResult CalculateNetWorth(PortfolioDto portfolioDto)
        {

            
            try
            {
                _log4net.Info("NetworthController's CalculateNetWorth Action called");

                return Ok(networthProvider.GetNetWorthWithRespectPorfolioDetails(portfolioDto));
            }
            catch(Exception e)
            {
                _log4net.Error(e.StackTrace);
                return new StatusCodeResult(500);
            }

        }





















        /// <summary>
        /// SellAsset
        /// </summary>
        /// <param name="sellDto"></param>
        /// <returns></returns>
        [HttpPost("SellAsset")]
        public ActionResult SellAsset(SellDto sellDto)
        {
            

            try
            {
                _log4net.Info("NetworthController's  SellAsset Action called");

                return Ok(networthProvider.SellAsset(sellDto));
            }
            catch(Exception e)
            {
                _log4net.Error(e.StackTrace);
                 return new StatusCodeResult(500);
            }
        }





       



     
        
    }
}
