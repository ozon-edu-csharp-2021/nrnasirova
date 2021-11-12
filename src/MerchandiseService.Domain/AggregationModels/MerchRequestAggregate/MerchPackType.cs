using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class MerchPackType: Enumeration
    {
        public static MerchPackType NoMerchPack = new(1, nameof(NoMerchPack));
        public static MerchPackType WelcomePack = new(2, nameof(WelcomePack));
        public static MerchPackType StarterPack = new(3, nameof(StarterPack));
        public static MerchPackType ConferenceListenerPack = new(4, nameof(ConferenceListenerPack));
        public static MerchPackType ConferenceSpeakerPack = new(5, nameof(ConferenceSpeakerPack));
        public static MerchPackType VeteranPack = new(6, nameof(VeteranPack));

        public MerchPackType(int id, string name) : base(id, name)
        {
        }
    }
}