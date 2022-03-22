using CalculateNetWorth9Microservice.DTO;
using CalculateNetWorth9Microservice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalculateNetWorth9Microservice.Repository
{
    public interface INetworthRepository
    {

        public decimal GetNetWorthWithRespectPorfolioDetails(PortfolioDto portfolioDto);


        public bool SellAsset(SellDto sellDto);


       
        public  Task<ActionResult<PortfolioDto>> GetPortfolioDetails(int UserId);


    }
}
