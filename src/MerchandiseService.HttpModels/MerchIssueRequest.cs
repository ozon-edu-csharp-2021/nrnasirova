using System;

namespace MerchandiseService.HttpModels
{
    public class MerchIssueRequest
    {
        public long MerchId { get; }
        public int Quantity { get; }
        public long EmployeeId { get; set; }
    }
}