namespace MerchandiseService.Models.V1.Request
{
    public class V1MerchItem
    {
        public long MerchId { get; set; }
        
        public string MerchName { get; set; }
        
        public int Quantity { get; set; }
    }
}