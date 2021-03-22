﻿using System;

namespace StellarGlobeShopUI.Service.Services.MessageBus.Models
{
    public class BusMessage
    {
        public BusMessage()
        {
            MessageDate = DateTime.Now.ToUniversalTime();
            MessageId = Guid.NewGuid();
        }

        public DateTime MessageDate { get; set; }
        public Guid MessageId { get; set; }
    }
}