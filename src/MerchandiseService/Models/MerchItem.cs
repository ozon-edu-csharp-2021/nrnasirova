namespace MerchandiseService.Models
{
    public class MerchItem
    {
        public MerchItem(long merchId, string merchName, int quantity)
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