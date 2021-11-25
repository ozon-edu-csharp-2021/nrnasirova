using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class MerchPackType: Enumeration
    {
        public static MerchPackType WelcomePack = new(1, nameof(WelcomePack));
        public static MerchPackType StarterPack = new(2, nameof(StarterPack));
        public static MerchPackType ConferenceListenerPack = new(3, nameof(ConferenceListenerPack));
        public static MerchPackType ConferenceSpeakerPack = new(4, nameof(ConferenceSpeakerPack));
        public static MerchPackType VeteranPack = new(5, nameof(VeteranPack));

        public MerchPackType(int id, string name) : base(id, name)
        {
        }
    }
}