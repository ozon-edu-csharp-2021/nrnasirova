using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MerchandiseService.Grpc.V1;
using MerchandiseService.Models.V1.Request;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.GrpcServices
{
    public class MerchGrpcService : MerchandiseService.Grpc.V1.MerchandiseService.MerchandiseServiceBase
    {
        private readonly IMerchService _merchService;

        public MerchGrpcService(IMerchService merchService)
        {
            _merchService = merchService;
        }

        public override async Task<Empty> IssueMerch(IssueMerchRequest issueMerchRequest, ServerCallContext context)
        {
            await _merchService.IssueMerch(
                new V1MerchItemIssueModel
                {
                    EmployeeId = issueMerchRequest.EmployeeId,
                    MerchItems = issueMerchRequest.MerchItems.Select(x => new V1MerchItem{MerchId = x.MerchId, Quantity = x.Quantity, MerchName = x.MerchName}).ToList()
                }, new CancellationToken());
            return new Empty(); 
        }

        public override async Task<GetMerchByEmployeeIdResponse> GetByEmployeeId(GetMerchByEmployeeIdRequest getMerchByEmployeeIdRequest, ServerCallContext context)
        {
            var merchByEmployeeId = new V1MerchByEmployeeId {EmployeeId = getMerchByEmployeeIdRequest.EmployeeId};
            
            var response = await _merchService.GetMerchByEmployeeId(merchByEmployeeId, new CancellationToken());
            return new GetMerchByEmployeeIdResponse()
            {
                MerchItems = {response.Select(merch => new Merch()
                {
                    MerchId = merch.MerchId,
                    MerchName = merch.MerchName,
                    Quantity = merch.Quantity
                })}
            };
        }
    }
}