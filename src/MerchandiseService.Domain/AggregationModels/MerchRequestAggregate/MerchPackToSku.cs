using System.Collections.Generic;
using MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public static class MerchPackToSku
    {
        public static Dictionary<MerchPackType, List<MerchItem>> MerchPackToSkuDictionary = new()
        {
            {MerchPackType.StarterPack, new List<MerchItem>()
            {
                new MerchItem(new Sku(1)), new MerchItem(new Sku(1))
            }},
            
            {MerchPackType.WelcomePack, new List<MerchItem>()
            {
                new MerchItem(new Sku(2)), new MerchItem(new Sku(2))
            }},
            
            {MerchPackType.ConferenceListenerPack, new List<MerchItem>()
            {
                new MerchItem(new Sku(3)), new MerchItem(new Sku(3))
            }},
            
            {MerchPackType.ConferenceSpeakerPack, new List<MerchItem>()
            {
                new MerchItem(new Sku(4)), new MerchItem(new Sku(4))
            }},
            
            {MerchPackType.VeteranPack, new List<MerchItem>()
            {
                new MerchItem(new Sku(5)), new MerchItem(new Sku(5))
            }},
        };
    }
}