using System;
using System.Threading.Tasks;

namespace BotShopNetwork.Services
{
    public static class RetryUtils
    {
        public static async Task<TRet> RetryIfThrown<TException, TRet>(Func<Task<TRet>> action, int numberOfTries, int delayBetweenTries, int incrementDelay = 0) where TException : Exception
        {
            TException lastException = null;

            for (var currentTry = 0; currentTry < numberOfTries; currentTry++)
            {
                try
                {
                    return await action();
                }
                catch (TException e)
                {
                    lastException = e;
                }
                await Task.Delay(delayBetweenTries + incrementDelay * currentTry);
            }

            if (lastException != null)
                throw lastException;

            throw new Exception("No exception to rethrow");
        }
    }
}