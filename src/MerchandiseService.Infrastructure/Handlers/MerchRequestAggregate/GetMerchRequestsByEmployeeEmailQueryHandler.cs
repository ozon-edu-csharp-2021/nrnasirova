using System;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Queries.MerchRequestAggregate;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate.Repository;

namespace Infrastructure.Handlers.MerchRequestAggregate
{
    public class GetMerchRequestsByEmployeeIdQueryHandler : IRequestHandler<GetMerchRequestByEmployeeEmailQuery, MerchByEmployeeIdResponse>
    {
        private readonly IMerchRequestRepository _merchRequestRepository;

        public GetMerchRequestsByEmployeeIdQueryHandler(IMerchRequestRepository merchRequestRepository)
        {
            _merchRequestRepository = merchRequestRepository;
        }


        public async Task<MerchByEmployeeIdResponse> Handle(GetMerchRequestByEmployeeEmailQuery request, CancellationToken cancellationToken)
        {
            var merchItems = await _merchRequestRepository.FindByEmployeeEmailAsync(new Email(request.EmployeeEmail), cancellationToken);

            var merchByEmployeeIdResp = new MerchByEmployeeIdResponse
                {MerchPackType = 1, Status = 3, CreatedAt = DateTimeOffset.Now, EmployeeEmail = "test@gmail.com"};

            return merchByEmployeeIdResp;
        }
    }
}