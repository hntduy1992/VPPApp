using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VPPAppApi.EF;
using VPPAppShare.Entities;

namespace VPPAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSPsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoaiSPsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LoaiSPs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiSP>>> GetLoaiSPs()
        {
            return await _context.LoaiSPs.ToListAsync();
        }

        // GET: api/LoaiSPs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiSP>> GetLoaiSP(int id)
        {
            var loaiSP = await _context.LoaiSPs.FindAsync(id);

            if (loaiSP == null)
            {
                return NotFound();
            }

            return loaiSP;
        }

        // PUT: api/LoaiSPs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiSP(int id, LoaiSP loaiSP)
        {
            if (id != loaiSP.Id)
            {
                return BadRequest();
            }

            _context.Entry(loaiSP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiSPExists(id))
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

        // POST: api/LoaiSPs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoaiSP>> PostLoaiSP(LoaiSP loaiSP)
        {
            _context.LoaiSPs.Add(loaiSP);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoaiSP", new { id = loaiSP.Id }, loaiSP);
        }

        // DELETE: api/LoaiSPs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaiSP(int id)
        {
            var loaiSP = await _context.LoaiSPs.FindAsync(id);
            if (loaiSP == null)
            {
                return NotFound();
            }

            _context.LoaiSPs.Remove(loaiSP);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoaiSPExists(int id)
        {
            return _context.LoaiSPs.Any(e => e.Id == id);
        }
    }
}
