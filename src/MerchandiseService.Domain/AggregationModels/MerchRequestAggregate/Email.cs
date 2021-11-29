using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class Email: ValueObject
    {
        public string Value { get; }

        public Email()
        {
            
        }
        
        public Email(string emailValue)
        {
            Value = emailValue;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}   