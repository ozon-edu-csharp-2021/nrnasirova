using System;

namespace MerchandiseService.Domain.Exceptions
{
    public class FailToGiveOutException: Exception
    {
        public FailToGiveOutException(string message): base(message)
        {
            
        }

        public FailToGiveOutException(string message, Exception innerException): base(message, innerException)
        {
            
        }
    }
}