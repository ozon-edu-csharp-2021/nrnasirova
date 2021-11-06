namespace MerchandiseService.Models.V1.Response
{
    public class V1MerchItem
    {
        public V1MerchItem(long merchId, string merchName, int quantity)
        {
            MerchName = merchName;
            Quantity = quantity;
            MerchId = merchId;
        }
        
        public long MerchId { get; }
        
        public string MerchName { get; }
        
        public int Quantity { get; }
    }
}