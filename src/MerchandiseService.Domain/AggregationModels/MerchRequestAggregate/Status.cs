using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class Status: Enumeration
    {
        public static Status New = new(1, nameof(New));
        public static Status WaitingSupply = new(3, nameof(WaitingSupply));
        public static Status Denied = new(5, nameof(Denied));
        public static Status GivenOut = new(6, nameof(GivenOut));

        public Status(int id, string name) : base(id, name)
        {
            
        }
    }
}