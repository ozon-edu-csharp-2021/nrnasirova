using System.Collections.Generic;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace MerchandiseService.Domain.Events
{
    public class MerchToGiveOut : INotification
    {
        public MerchPackType MerchPackType { get; set; }
        public Employee Employee { get; set; }

        public MerchToGiveOut(MerchPackType merchPackType, Employee employee)
        {
            MerchPackType = merchPackType;
            Employee = employee;
        }
    }
}