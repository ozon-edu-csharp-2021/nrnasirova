using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate.Repository
{
    public class MerchRequestRepository : IMerchRequestRepository
    {
        public IUnitOfWork UnitOfWork { get; }
        public async Task<MerchRequest> CreateAsync(MerchRequest itemToCreate, CancellationToken cancellationToken = default)
        {
            return itemToCreate;
        }

        public async Task<MerchRequest> UpdateAsync(MerchRequest itemToUpdate, CancellationToken cancellationToken = default)
        {
            return itemToUpdate;
        }

        public async Task<List<MerchItem>> FindByEmployeeExternalIdAsync(Identifier externalId, CancellationToken cancellationToken = default)
        {
            return new List<MerchItem>
            {
                new (new Sku(1))
            };
        }
    }
}