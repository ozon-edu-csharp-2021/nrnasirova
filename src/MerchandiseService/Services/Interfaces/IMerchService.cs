using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models.V1.Request;
using V1MerchItem = MerchandiseService.Models.V1.Response.V1MerchItem;

namespace MerchandiseService.Services.Interfaces
{
    public interface IMerchService
    {
        Task IssueMerch(V1MerchItemIssueModel merchItemIssueModel, CancellationToken token);
        Task<List<V1MerchItem>> GetMerchByEmployeeId(V1MerchByEmployeeId merchByEmployeeId, CancellationToken token);
    }
}