using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Commands.IssueMerchRequest;
using Infrastructure.Queries.MerchRequestAggregate;
using MediatR;
using MerchandiseService.Models.V1.Request;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merch")]
    public class MerchController: ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> IssueMerch(V1MerchItemIssueModel merchItemIssueModel, CancellationToken token)
        {
            var issueMerchRequestCommand = new IssueMerchRequestCommand()
            {
                EmployeeEmail = merchItemIssueModel.EmployeeEmail,
                MerchPackType = merchItemIssueModel.MerchPackType
            };
            
            var merchRequestCreatedId = await _mediator.Send(issueMerchRequestCommand, token);
            return Ok(merchRequestCreatedId);
        }

        [HttpPost("getByEmployeeEmail")]
        public async Task<IActionResult> GetByEmployeeEmail(V1MerchByEmployeeEmail merchByEmployeeEmail, CancellationToken token)
        {
            var merchRequestByEmployeeIdQuery = new GetMerchRequestByEmployeeEmailQuery()
            {
                EmployeeEmail = merchByEmployeeEmail.EmployeeEmail
            };

            var merchRequests = await _mediator.Send(merchRequestByEmployeeIdQuery, token);
            return Ok(merchRequests);
        }
    }
}