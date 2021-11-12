using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Commands.IssueMerchRequest;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate.Repository;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
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
            var merchItems = request.SkuList.Select(sku => new MerchItem(new Sku(sku))).ToList();
            var merchPackType = Enumeration.GetAll<MerchPackType>().FirstOrDefault(m => m.Id.Equals(request.MerchPackType)) ?? MerchPackType.NoMerchPack;

            if (!Equals(merchPackType, MerchPackType.NoMerchPack))
            {
                merchItems.AddRange(MerchPackToSku.MerchPackToSkuDictionary[merchPackType]);
            }

            var merchRequest =
                new MerchRequest(
                    new Employee(new Identifier(request.EmployeeExternalId), new Email(request.EmployeeEmail)), merchItems, merchPackType);
            var issueMerchResult = await _merchRequestRepository.CreateAsync(merchRequest, cancellationToken);

            // await _merchRequestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            
            return issueMerchResult.Id;
        }
    }
}