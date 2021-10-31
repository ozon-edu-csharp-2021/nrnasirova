using System;
using System.Collections.Generic;

namespace MerchandiseService.HttpModels
{
    public class MerchIssueRequest
    {
        public List<MerchItem> MerchItems { get; set; }
        public long EmployeeId { get; set; }
    }
}