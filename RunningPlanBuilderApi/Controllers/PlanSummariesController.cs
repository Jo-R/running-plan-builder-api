#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunnningPlanBuilderApi.Models;

namespace RunnningPlanBuilderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanSummariesController : ControllerBase
    {
        private readonly RunPlanContext _context;

        public PlanSummariesController(RunPlanContext context)
        {
            _context = context;
        }

        // GET: api/PlanSummaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanSummary>>> GetPlanSummary()
        {
            return await _context.PlanSummary.ToListAsync();
        }

        // GET: api/PlanSummaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanSummary>> GetPlanSummary(int id)
        {
            var planSummary = await _context.PlanSummary.FindAsync(id);

            if (planSummary == null)
            {
                return NotFound();
            }

            return planSummary;
        }

        // PUT: api/PlanSummaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanSummary(int id, PlanSummary planSummary)
        {
            if (id != planSummary.Id)
            {
                return BadRequest();
            }

            _context.Entry(planSummary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanSummaryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlanSummaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlanSummary>> PostPlanSummary(PlanSummary planSummary)
        {
            _context.PlanSummary.Add(planSummary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanSummary", new { id = planSummary.Id }, planSummary);
        }

        // DELETE: api/PlanSummaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanSummary(int id)
        {
            var planSummary = await _context.PlanSummary.FindAsync(id);
            if (planSummary == null)
            {
                return NotFound();
            }

            _context.PlanSummary.Remove(planSummary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanSummaryExists(int id)
        {
            return _context.PlanSummary.Any(e => e.Id == id);
        }
    }
}
