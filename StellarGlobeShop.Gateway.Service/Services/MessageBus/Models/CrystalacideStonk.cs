using System;

namespace StellarGlobeShop.Gateway.Service.Services.MessageBus.Models
{
    public class CrystalacideStonkMessage : BusMessage
    {
        public CrystalacideStonkMessage(Guid stonkId, int stonkAmount, string companyName)
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