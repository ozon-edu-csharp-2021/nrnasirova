using System;

namespace MerchandiseService.Domain.Exceptions
{
    public class InvalidIdentifierException : Exception
    {
        public InvalidIdentifierException(string message) : base(message)
        {
            
        }
        
        public InvalidIdentifierException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}