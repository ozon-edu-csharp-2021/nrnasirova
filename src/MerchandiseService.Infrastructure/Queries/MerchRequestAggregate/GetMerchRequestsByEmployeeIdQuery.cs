using System.Collections.Generic;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;

namespace Infrastructure.Queries.MerchRequestAggregate
{
    /// <summary>
    /// Get all merch request by employee external id
    /// </summary>
    public class GetMerchRequestByEmployeeIdQuery : IRequest<MerchByEmployeeIdResponse>
    {
        /// <summary>
        /// Employee external id
        /// </summary>
        public long EmployeeExternalId { get; set; }
    }
}