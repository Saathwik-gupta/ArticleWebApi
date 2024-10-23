using Microsoft.AspNetCore.Mvc;
using ArticleWebApi.Models;
using ArticleWebApi.Services;

namespace ArticleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        // Use the interface IStateServiceBL instead of the concrete class
        private readonly IStateServiceBL _stateService;

        // Inject the service using the interface
        public StatesController(IStateServiceBL stateService)
        {
            _stateService = stateService;
        }

        // GET: api/states
        [HttpGet]
        public IActionResult GetStates()
        {
            var states = _stateService.GetAllStates();
            return Ok(states);
        }

        // GET: api/states/5
        [HttpGet("{id}")]
        public IActionResult GetState(int id)
        {
            var state = _stateService.GetStateById(id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state);
        }

        // POST: api/states
        [HttpPost]
        public IActionResult PostState([FromBody] State state)
        {
            if (state == null)
            {
                return BadRequest();
            }

            _stateService.AddState(state);
            return CreatedAtAction(nameof(GetState), new { id = state.StateId }, state);
        }

        // PUT: api/states/5
        [HttpPut("{id}")]
        public IActionResult PutState(int id, [FromBody] State state)
        {
            if (id != state.StateId || state == null)
            {
                return BadRequest();
            }

            _stateService.UpdateState(state);
            return NoContent();
        }

        // DELETE: api/states/5
        [HttpDelete("{id}")]
        public IActionResult DeleteState(int id)
        {
            var existingState = _stateService.GetStateById(id);
            if (existingState == null)
            {
                return NotFound();
            }

            _stateService.DeleteState(id);
            return NoContent();
        }
    }
}
