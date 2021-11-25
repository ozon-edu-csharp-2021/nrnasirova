using System.Collections.Generic;

namespace MerchandiseService.Models.V1.Request
{
    public class V1MerchItemIssueModel
    {
        public string EmployeeEmail { get; set; }
        public int MerchPackType { get; set; }
    }
}