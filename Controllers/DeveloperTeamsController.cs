using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LicenseProject.Models;

namespace LicenseProject.Controllers
{
    [Route("api/developerteam")]
    [ApiController]
    public class DeveloperTeamsController : ControllerBase
    {
        private readonly Context _context;

        public DeveloperTeamsController(Context context)
        {
            _context = context;
        }

        // GET: api/DeveloperTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeveloperTeam>>> GetDeveloperTeam()
        {
            return await _context.DeveloperTeam.ToListAsync();
        }

        // GET: api/DeveloperTeams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeveloperTeam>> GetDeveloperTeam(int id)
        {
            var developerTeam = await _context.DeveloperTeam.FindAsync(id);

            if (developerTeam == null)
            {
                return NotFound();
            }

            return developerTeam;
        }

        // PUT: api/DeveloperTeams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeveloperTeam(int id, DeveloperTeam developerTeam)
        {
            if (id != developerTeam.ID)
            {
                return BadRequest();
            }

            _context.Entry(developerTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeveloperTeamExists(id))
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

        // POST: api/DeveloperTeams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DeveloperTeam>> PostDeveloperTeam(DeveloperTeam developerTeam)
        {
            _context.DeveloperTeam.Add(developerTeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeveloperTeam", new { id = developerTeam.ID }, developerTeam);
        }

        // DELETE: api/DeveloperTeams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeveloperTeam>> DeleteDeveloperTeam(int id)
        {
            var developerTeam = await _context.DeveloperTeam.FindAsync(id);
            if (developerTeam == null)
            {
                return NotFound();
            }

            _context.DeveloperTeam.Remove(developerTeam);
            await _context.SaveChangesAsync();

            return developerTeam;
        }

        private bool DeveloperTeamExists(int id)
        {
            return _context.DeveloperTeam.Any(e => e.ID == id);
        }
    }
}
