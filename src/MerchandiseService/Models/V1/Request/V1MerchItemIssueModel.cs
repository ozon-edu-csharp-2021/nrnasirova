using System.Collections.Generic;

namespace MerchandiseService.Models.V1.Request
{
    public class V1MerchItemIssueModel
    {
        public List<V1MerchItem> MerchItems { get; set; } = new();
        public long EmployeeId { get; set; }
    }
}