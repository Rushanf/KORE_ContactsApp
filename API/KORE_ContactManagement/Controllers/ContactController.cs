using KORE_ContactManagement.Application.Commands;
using KORE_ContactManagement.Application.Queries;
using KORE_ContactManagement.Application.Commands;
using KORE_ContactManagement.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KORE_ContactManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactController(IMediator mediator) =>
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        // GET: api/<ContactController>
        [HttpGet()]
        public async Task<IActionResult> GetList([FromQuery] GetAllContactsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetContactQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<IActionResult> AddAsset([FromBody] CreateContactCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);

        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateContactCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteContactCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
