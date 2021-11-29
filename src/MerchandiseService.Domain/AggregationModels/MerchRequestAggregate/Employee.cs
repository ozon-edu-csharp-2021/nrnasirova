using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class Employee : ValueObject
    {
        public Employee()
        {
            
        }
        public Employee(Email email)
        {
            Email = email;
        }
        /// <summary>
        /// external id - id from external service (employee service)
        /// </summary>
        public Email Email { get; }
        
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Email;
        }
    }
}