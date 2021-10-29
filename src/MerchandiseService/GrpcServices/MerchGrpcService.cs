using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        public override async Task<IssueMerchResponse> IssueMerch(IssueMerchRequest request, ServerCallContext context)
        {
            var response = await _merchService.IssueMerch(new MerchItemIssueModel()
            {
                EmployeeId = request.EmployeeId,
                MerchId = request.MerchId,
                Quantity = request.Quantity
            }, new CancellationToken());

            return new IssueMerchResponse();

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