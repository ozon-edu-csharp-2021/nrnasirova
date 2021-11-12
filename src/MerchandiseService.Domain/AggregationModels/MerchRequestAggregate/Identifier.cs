using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class Identifier : ValueObject
    {
        public long Value { get; }

        public Identifier(long externalIdValue)
        {
            Value = externalIdValue;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}