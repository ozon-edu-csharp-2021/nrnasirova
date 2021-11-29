using System.Collections.Generic;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;

namespace Infrastructure.Commands.IssueMerchRequest
{
    public class IssueMerchRequestCommand: IRequest<int>
    {
        public string EmployeeEmail { get; set; }
        public int MerchPackType { get; set; }
    }
}