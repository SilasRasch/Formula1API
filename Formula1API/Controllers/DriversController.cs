using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Formula1API.Models;
using Microsoft.AspNetCore.Cors;

namespace Formula1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly ProjectDbContext _context;

        public DriversController(ProjectDbContext context)
        {
            _context = context;
        }

        // GET: api/Drivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
            return await _context.Drivers.Include(d => d.Team).ToListAsync();
        }

        // GET: api/Drivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriver(int id)
        {
            var driver = await _context.Drivers.Include(d => d.Team).FirstOrDefaultAsync(d => d.DriverNumber == id);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }
        
        // GET: api/Drivers/
        [HttpGet("ByTeam/{teamId}")]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDriversByTeamId(int teamId)
        {
            return await _context.Drivers.Include(d => d.Team).Where(d => d.TeamId == teamId).ToListAsync();
        }

        // PUT: api/Drivers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriver(int id, [FromBody] Driver driver)
        {
            if (id != driver.DriverNumber) { return BadRequest(); }

            if (GetDriver(id) == null) { return BadRequest(); }

            _context.Drivers.Update(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Drivers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Driver>> PostDriver([FromBody] Driver driver)
        {
            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriver", new { id = driver.DriverNumber }, driver);
        }

        // DELETE: api/Drivers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.DriverNumber == id);
        }
    }
}
