using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculateNetWorth9Microservice.Models
{
    public class MutualFundDetails
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MutualFunBuyId { get; set; }

       
        public int PortfolioId { get; set; }

        [ForeignKey("PortfolioId")]
        public PortfolioDetails PortfolioDetails { get; set; }

       
        public int MutualFundId{ get; set; }
        
        [ForeignKey("MutualFundId")]
        public MutualFundPriceDetails MutualFundPriceDetails { get; set; }
        
        
        public int Count{ get; set; }
    }
}
