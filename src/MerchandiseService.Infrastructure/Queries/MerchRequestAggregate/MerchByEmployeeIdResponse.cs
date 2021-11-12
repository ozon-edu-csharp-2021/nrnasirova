using System.Collections.Generic;

namespace Infrastructure.Queries.MerchRequestAggregate
{
    public class MerchByEmployeeIdResponse
    {
        public List<long> SkuList { get; set; }
    }
}