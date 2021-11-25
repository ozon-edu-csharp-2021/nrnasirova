using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.Events;

namespace Infrastructure.Handlers.DomainEvents
{
    public class MerchSupplyArrivedHandler: INotificationHandler<MerchToGiveOut>
    {
        public Task Handle(MerchToGiveOut notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}