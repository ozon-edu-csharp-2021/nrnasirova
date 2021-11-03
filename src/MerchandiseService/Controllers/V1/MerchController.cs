using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models.V1.Request;
using MerchandiseService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merch")]
    public class MerchController: ControllerBase
    {
        private readonly IMerchService _merchService;

        public MerchController(IMerchService merchService)
        {
            _merchService = merchService;
        }

        [HttpPost]
        public async Task<IActionResult> IssueMerch(V1MerchItemIssueModel merchItemIssueModel, CancellationToken token)
        {
            await _merchService.IssueMerch(merchItemIssueModel, token);
            return Ok();
        }

        [HttpPost("getByEmployeeId")]
        public async Task<IActionResult> GetByEmployeeId(V1MerchByEmployeeId merchByEmployeeId, CancellationToken token)
        {
            var merchItems = await _merchService.GetMerchByEmployeeId(merchByEmployeeId, token);
            return Ok(merchItems);
        }
    }
}