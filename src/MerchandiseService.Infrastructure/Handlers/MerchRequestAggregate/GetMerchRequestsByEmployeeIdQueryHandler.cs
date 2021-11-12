using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Queries.MerchRequestAggregate;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate.Repository;

namespace Infrastructure.Handlers.MerchRequestAggregate
{
    public class GetMerchRequestsByEmployeeIdQueryHandler : IRequestHandler<GetMerchRequestByEmployeeIdQuery, MerchByEmployeeIdResponse>
    {
        private readonly IMerchRequestRepository _merchRequestRepository;

        public GetMerchRequestsByEmployeeIdQueryHandler(IMerchRequestRepository merchRequestRepository)
        {
            _merchRequestRepository = merchRequestRepository;
        }


        public async Task<MerchByEmployeeIdResponse> Handle(GetMerchRequestByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            var merchItems = await _merchRequestRepository.FindByEmployeeExternalIdAsync(new Identifier(request.EmployeeExternalId), cancellationToken);

            var merchByEmployeeIdResp = new MerchByEmployeeIdResponse
                {SkuList = merchItems.Select(m => m.Sku.Value).ToList()};

            return merchByEmployeeIdResp;
        }
    }
}