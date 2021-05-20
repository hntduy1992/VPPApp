﻿using System;
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
    public class HinhAnhsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HinhAnhsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HinhAnhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HinhAnh>>> GetHinhAnhs()
        {
            return await _context.HinhAnhs.ToListAsync();
        }

        // GET: api/HinhAnhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HinhAnh>> GetHinhAnh(int id)
        {
            var hinhAnh = await _context.HinhAnhs.FindAsync(id);

            if (hinhAnh == null)
            {
                return NotFound();
            }

            return hinhAnh;
        }

        // PUT: api/HinhAnhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHinhAnh(int id, HinhAnh hinhAnh)
        {
            if (id != hinhAnh.Id)
            {
                return BadRequest();
            }

            _context.Entry(hinhAnh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HinhAnhExists(id))
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

        // POST: api/HinhAnhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HinhAnh>> PostHinhAnh(HinhAnh hinhAnh)
        {
            _context.HinhAnhs.Add(hinhAnh);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHinhAnh", new { id = hinhAnh.Id }, hinhAnh);
        }

        // DELETE: api/HinhAnhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHinhAnh(int id)
        {
            var hinhAnh = await _context.HinhAnhs.FindAsync(id);
            if (hinhAnh == null)
            {
                return NotFound();
            }

            _context.HinhAnhs.Remove(hinhAnh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HinhAnhExists(int id)
        {
            return _context.HinhAnhs.Any(e => e.Id == id);
        }
    }
}
