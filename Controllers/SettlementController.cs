using Microsoft.AspNetCore.Mvc;
using WebApplicationTask.Models;
using WebApplicationTask.SettlementRepository;

namespace WebApplicationTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettlementController:ControllerBase
    {
        ISettlementRepository _settlementRepository;
        public SettlementController(ISettlementRepository settlementRepository)
        {
            _settlementRepository = settlementRepository;
        }
        // GET: api/<categoriesController>
        [HttpGet]
        public async Task<ActionResult<List<Settelment>>> Get()
        {
            var settelments = await _settlementRepository.GetSettelments();
            return settelments == null ? NoContent() : Ok(settelments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Settelment>> GetSettelmentById(int id)
        {
            var settlement= await _settlementRepository.GetSettelmentById(id);
            return settlement == null ? NotFound() : Ok(settlement);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Settelment newSettelment)
        {
            var createdNewSettelment = await _settlementRepository.AddSettelment(newSettelment);
            if (createdNewSettelment == null)
                return BadRequest("all fileds are required");
            return Ok(createdNewSettelment);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Settelment>> Put(int id, [FromBody] Settelment settelment)
        {
            if (id != settelment.Id)
            {
                return BadRequest("The provided ID does not match the settlement object.");
            }

            var updatedSettelment = await _settlementRepository.UpdateSettelment(settelment);
            return updatedSettelment == null ? NotFound() : Ok(updatedSettelment);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _settlementRepository.DeleteSettelment(id);

            return result ? NoContent() : NotFound();
        }
    }
}
