using Microsoft.Extensions.Logging;

namespace StellarGlobeShop.MyShop.Service
{
    public static class LoggerEvents
    {
        public static EventId GenerateEventId(LoggerEventType eventType)
        {
            return new EventId((int)eventType, eventType.ToString());
        }
    }
}