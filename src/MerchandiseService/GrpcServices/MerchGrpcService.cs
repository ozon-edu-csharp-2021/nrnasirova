using System;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MerchandiseService.Grpc.V1;

namespace MerchandiseService.GrpcServices
{
    public class MerchGrpcService : MerchandiseService.Grpc.V1.MerchandiseService.MerchandiseServiceBase
    {

        public override async Task<Empty> IssueMerch(IssueMerchRequest issueMerchRequest, ServerCallContext context)
        {
            throw new NotImplementedException();
        }

        public override async Task<GetMerchByEmployeeIdResponse> GetByEmployeeId(GetMerchByEmployeeIdRequest getMerchByEmployeeIdRequest, ServerCallContext context)
        {
            throw new NotImplementedException();
        }
    }
}