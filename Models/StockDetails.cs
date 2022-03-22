using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculateNetWorth9Microservice.Models
{
    public class StockDetails
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StockBuyId { get; set; }

       
        public int PortfolioId{ get; set; }

        [ForeignKey("PortfolioId")]
        public PortfolioDetails PortfolioDetails { get; set; }

       
        public int StockId { get; set; }

        [ForeignKey("StockId")]
        public StockPriceDetails StockPriceDetails { get; set;}
        
      
        public int Count { get; set; }
    }
}
