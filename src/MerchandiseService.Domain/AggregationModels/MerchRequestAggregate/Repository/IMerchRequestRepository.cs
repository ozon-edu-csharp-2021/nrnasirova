using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate.Repository
{
    public interface IMerchRequestRepository : IRepository<MerchRequest>
    {
        /// <summary>
        /// Finds merch request by employee email
        /// </summary>
        /// <param name="email">Employee email</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<MerchRequest>> FindByEmployeeEmailAsync(Email email, CancellationToken cancellationToken = default);
    }
}