using System.Collections.Generic;

namespace MerchandiseService.HttpModels.V1.Request
{
    public class V1MerchIssue
    {
        public List<V1MerchItem> MerchItems { get; set; }
        public long EmployeeId { get; set; }
    }
}