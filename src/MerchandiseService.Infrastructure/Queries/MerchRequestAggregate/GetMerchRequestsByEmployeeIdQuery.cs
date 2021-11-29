using System.Collections.Generic;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;

namespace Infrastructure.Queries.MerchRequestAggregate
{
    /// <summary>
    /// Get all merch request by employee external id
    /// </summary>
    public class GetMerchRequestByEmployeeEmailQuery : IRequest<MerchByEmployeeIdResponse>
    {
        /// <summary>
        /// Employee external id
        /// </summary>
        public string EmployeeEmail { get; set; }
    }
}