using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models;

namespace MerchandiseService.Services.Interfaces
{
    public interface IMerchService
    {
        Task<BaseResponse<object>> IssueMerch(MerchItemIssueModel merchItemIssueModel, CancellationToken token);
        Task<BaseResponse<List<MerchItem>>> GetMerchByEmployeeId(long employeeId, CancellationToken token);
    }
}