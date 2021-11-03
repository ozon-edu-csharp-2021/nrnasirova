using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models.V1.Request;
using MerchandiseService.Services.Interfaces;
using V1MerchItem = MerchandiseService.Models.V1.Response.V1MerchItem;

namespace MerchandiseService.Services
{
    public class MerchService: IMerchService
    {

        public Task IssueMerch(Models.V1.Request.V1MerchItemIssueModel merchItemIssueModel, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<List<V1MerchItem>> GetMerchByEmployeeId(V1MerchByEmployeeId merchByEmployeeId, CancellationToken token)
        {
            var merchItems = new List<V1MerchItem>()
            {
                new (12345, "test", 1)
            };
            
            return Task.FromResult(merchItems);
        }
    }
}