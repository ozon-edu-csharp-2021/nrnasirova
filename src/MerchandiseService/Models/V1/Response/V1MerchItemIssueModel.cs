using System.Collections.Generic;

namespace MerchandiseService.Models.V1.Response
{
    public class V1MerchItemIssueModel
    {
        public List<V1MerchItem>? MerchItems { get; set; }
        public long EmployeeId { get; set; }
    }
}