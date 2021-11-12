using System.Collections.Generic;
using MediatR;
using MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace MerchandiseService.Domain.Events
{
    public class MerchSupplyArrivedDomainEvent : INotification
    {
        public List<Sku> MerchItems { get; set; }

        public MerchSupplyArrivedDomainEvent(List<Sku> merchItems)
        {
            MerchItems = merchItems;
        }
    }
}