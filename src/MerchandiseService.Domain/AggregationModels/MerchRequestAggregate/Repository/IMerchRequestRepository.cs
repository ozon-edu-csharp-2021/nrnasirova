using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate.Repository
{
    public interface IMerchRequestRepository : IRepository<MerchRequest>
    {
        /// <summary>
        /// Finds merch request by employee external id
        /// </summary>
        /// <param name="externalId"></param>
        /// <returns>Merch request</returns>
        Task<List<MerchItem>> FindByEmployeeExternalIdAsync(Identifier identifier, CancellationToken cancellationToken = default);
    }
}