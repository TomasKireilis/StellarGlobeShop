using Microsoft.Extensions.Logging;

namespace StellarGlobe.MyShop
{
    public static class LoggerEvents
    {
        public static EventId GenerateEventId(LoggerEventType eventType)
        {
            return new EventId((int)eventType, eventType.ToString());
        }
    }
}