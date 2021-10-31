using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models;
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
        public async Task<IActionResult> IssueMerch(MerchItemIssueModel merchItemIssueModel, CancellationToken token)
        {
            await _merchService.IssueMerch(merchItemIssueModel, token);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetByEmployeeId(long employeeId, CancellationToken token)
        {
            var merchItems = await _merchService.GetMerchByEmployeeId(employeeId, token);
            return Ok(merchItems);
        }
    }
}