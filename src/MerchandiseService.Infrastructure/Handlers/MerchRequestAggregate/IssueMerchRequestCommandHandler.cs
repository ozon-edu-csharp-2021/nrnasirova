using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Commands.IssueMerchRequest;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate.Repository;
using MerchandiseService.Domain.Models;

namespace Infrastructure.Handlers.MerchRequestAggregate
{
    public class IssueMerchRequestCommandHandler: IRequestHandler<IssueMerchRequestCommand, int>
    {
        private readonly IMerchRequestRepository _merchRequestRepository;

        public IssueMerchRequestCommandHandler(IMerchRequestRepository merchRequestRepository)
        {
            _merchRequestRepository = merchRequestRepository;
        }
        
        public async Task<int> Handle(IssueMerchRequestCommand request, CancellationToken cancellationToken)
        {
            var merchPackType = Enumeration.GetAll<MerchPackType>()
                .FirstOrDefault(m => m.Id.Equals(request.MerchPackType));

            var existingMerchRequests = await _merchRequestRepository.FindByEmployeeEmailAsync(new Email(request.EmployeeEmail), cancellationToken);
            
            var merchRequest = MerchRequest.Create(new Employee(new Email(request.EmployeeEmail)), merchPackType, DateTimeOffset.Now, existingMerchRequests);

            var issueMerchResult = await _merchRequestRepository.CreateAsync(merchRequest, cancellationToken);
            
            // await _merchRequestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            
            //go to stock api and check if merchpack is available
            merchRequest.GiveOut(DateTimeOffset.Now);
            
            await _merchRequestRepository.UpdateAsync(merchRequest, cancellationToken);
            
            return 1;
        }
    }
}