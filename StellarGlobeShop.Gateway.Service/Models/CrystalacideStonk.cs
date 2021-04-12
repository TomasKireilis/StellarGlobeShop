using System;

namespace StellarGlobeShop.Gateway.Service.Models
{
    public class CrystalacideStonk
    {
        public CrystalacideStonk(Guid stonkId, int stonkAmount, string companyName)
        {
            StonkId = stonkId;
            StonkAmount = stonkAmount;
            CompanyName = companyName;
        }

        public Guid StonkId { get; set; }

        public int StonkAmount { get; set; }

        public string CompanyName { get; set; }
    }
}