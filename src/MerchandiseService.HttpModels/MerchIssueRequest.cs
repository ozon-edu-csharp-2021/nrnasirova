using System;

namespace MerchandiseService.HttpModels
{
    public class MerchIssueRequest
    {
        public MerchIssueRequest(string merchName, int quantity, long employeeId)
        {
            MerchName = merchName;
            Quantity = quantity;
            EmployeeId = employeeId;
        }
        
        public string MerchName { get; }
        public int Quantity { get; }
        public long EmployeeId { get; set; }
    }
}