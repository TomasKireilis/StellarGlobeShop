using Microsoft.Extensions.Logging;

namespace BotCustomer.Services
{
    public enum LoggerEventType
    {
        GraphQLClient = 0,
        GraphQLClientQuery = 1
    }

    public static class ExceptionEvents
    {
        public static EventId GenerateEventId(LoggerEventType eventType)
        {
            return new EventId((int)eventType, eventType.ToString());
        }
    }
}