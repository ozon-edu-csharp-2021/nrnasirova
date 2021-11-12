using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class MerchItem: Entity
    {
        public Sku Sku { get; }
        
        public MerchItem(Sku sku)
        {
            Sku = sku;
        }
    }
}