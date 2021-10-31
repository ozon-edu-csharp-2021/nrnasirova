using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;
using StatusCode = Grpc.Core.StatusCode;

namespace MerchandiseService.Services
{
    public class MerchService: IMerchService
    {

        public Task<BaseResponse<object>> IssueMerch(MerchItemIssueModel merchItemIssueModel, CancellationToken token)
        {
            return Task.FromResult(new BaseResponse<object>());
        }

        public Task<BaseResponse<List<MerchItem>>> GetMerchByEmployeeId(long employeeId, CancellationToken token)
        {
            var response = new BaseResponse<List<MerchItem>>();
            var merchItems = new List<MerchItem>()
            {
                new (12345, "test", 1)
            };

            response.Code = Status.Approved;
            response.Message = Status.Approved.ToString();
            response.Payload = merchItems;
            return Task.FromResult(response);
        }
    }
}