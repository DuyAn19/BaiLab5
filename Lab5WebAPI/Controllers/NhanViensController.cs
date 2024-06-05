using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab5API.AppDBContext;
using Lab5API.Model;

namespace Lab5WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanViensController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NhanViensController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/NhanViens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanVien>>> GetnhanViens()
        {
            return await _context.nhanViens.ToListAsync();
        }

        // GET: api/NhanViens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanVien>> GetNhanVien(Guid id)
        {
            var nhanVien = await _context.nhanViens.FindAsync(id);

            if (nhanVien == null)
            {
                return NotFound();
            }

            return nhanVien;
        }

        // PUT: api/NhanViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanVien(Guid id, NhanVien nhanVien)
        {
            if (id != nhanVien.id)
            {
                return BadRequest();
            }

            _context.Entry(nhanVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanVienExists(id))
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

        // POST: api/NhanViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NhanVien>> PostNhanVien(NhanVien nhanVien)
        {
            _context.nhanViens.Add(nhanVien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNhanVien", new { id = nhanVien.id }, nhanVien);
        }

        // DELETE: api/NhanViens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanVien(Guid id)
        {
            var nhanVien = await _context.nhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            _context.nhanViens.Remove(nhanVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NhanVienExists(Guid id)
        {
            return _context.nhanViens.Any(e => e.id == id);
        }
    }
}
