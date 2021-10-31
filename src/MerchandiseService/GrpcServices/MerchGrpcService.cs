using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MerchandiseService.Grpc;
using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.GrpcServices
{
    public class MerchGrpcService : MerchandiseService.Grpc.MerchandiseService.MerchandiseServiceBase
    {
        private readonly IMerchService _merchService;

        public MerchGrpcService(IMerchService merchService)
        {
            _merchService = merchService;
        }

        public override async Task<Empty> IssueMerch(IssueMerchRequest request, ServerCallContext context)
        {
            await _merchService.IssueMerch(
                new MerchItemIssueModel
                {
                    EmployeeId = request.EmployeeId,
                    MerchItems = request.MerchItems.Select(x => new MerchItem(x.MerchId, x.MerchName, x.Quantity)).ToList()
                }, new CancellationToken());
            return new Empty(); 
        }

        public override async Task<GetMerchByEmployeeIdResponse> GetByEmployeeId(GetMerchByEmployeeIdRequest request, ServerCallContext context)
        {
            var response = await _merchService.GetMerchByEmployeeId(request.EmployeeId, new CancellationToken());
            return new GetMerchByEmployeeIdResponse()
            {
                MerchItems = {response.Payload.Select(merch => new Merch()
                {
                    MerchId = merch.MerchId,
                    MerchName = merch.MerchName,
                    Quantity = merch.Quantity
                })}
            };
        }
    }
}