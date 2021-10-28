namespace MerchandiseService.Models
{
    public class MerchItemIssueModel
    {
        public long MerchId { get; set; }
        public int Quantity { get; set; }
        public long EmployeeId { get; set; }
    }
}