using System;

namespace MerchandiseService.Domain.Exceptions
{
    public class InvalidEmployeeInfromationException : Exception
    {
        public InvalidEmployeeInfromationException(string message) : base(message)
        {
            
        }
        
        public InvalidEmployeeInfromationException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}