using System.Collections.Generic;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;

namespace Infrastructure.Commands.IssueMerchRequest
{
    public class IssueMerchRequestCommand: IRequest<int>
    {
        public long EmployeeExternalId { get; set; }
        public string EmployeeEmail { get; set; }
        public int MerchPackType { get; set; }
        public List<long> SkuList { get; set; }
    }
}