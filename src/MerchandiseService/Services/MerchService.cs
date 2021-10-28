using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.Services
{
    public class MerchService: IMerchService
    {

        public Task IssueMerch(MerchItemIssueModel merchItemIssueModel, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<MerchItem>> GetMerchByEmployeeId(long employeeId, CancellationToken token)
        {
            var merchItems = new List<MerchItem>()
            {
                new (12345, "test", 1)
            };
            return Task.FromResult(merchItems);
        }
    }
}