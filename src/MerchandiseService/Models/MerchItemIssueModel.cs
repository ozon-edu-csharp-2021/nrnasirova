using System.Collections.Generic;

namespace MerchandiseService.Models
{
    public class MerchItemIssueModel
    {
        public List<MerchItem>? MerchItems { get; set; }
        public long EmployeeId { get; set; }
    }
}