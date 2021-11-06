namespace MerchandiseService.HttpModels.V1.Request
{
    public class V1MerchItem
    {
        public long MerchId { get; }
        
        public string MerchName { get; }
        
        public int Quantity { get; }
    }
}