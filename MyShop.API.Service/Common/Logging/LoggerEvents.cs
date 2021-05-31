using Microsoft.Extensions.Logging;

namespace MyShop.API.Service.Common.Logging
{
    public static class LoggerEvents
    {
        public static EventId GenerateEventId(LoggerEventType eventType)
        {
            return new EventId((int)eventType, eventType.ToString());
        }
    }
}