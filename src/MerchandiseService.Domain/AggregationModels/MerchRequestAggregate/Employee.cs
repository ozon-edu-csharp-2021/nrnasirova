using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class Employee : ValueObject
    {
        public Employee()
        {
            
        }
        public Employee(Identifier externalId, Email email)
        {
            ExternalId = externalId;
            Email = email;
        }
        /// <summary>
        /// external id - id from external service (employee service)
        /// </summary>
        public Identifier ExternalId { get; }
        public Email Email { get; }
        

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ExternalId;
            yield return Email;
        }
    }
}