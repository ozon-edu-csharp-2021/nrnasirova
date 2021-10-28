namespace MerchandiseService.Models
{
    public class MerchItem
    {
        public MerchItem(long merchId, string merchName, int quantity)
        {
            MerchId = merchId;
            MerchName = merchName;
            Quantity = quantity;
        }
        
        public long MerchId { get; }
        
        public string MerchName { get; }
        
        public int Quantity { get; }
    }
}