using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookieJar.Models;

namespace CookieJar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cookie_TagController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Cookie_TagController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cookie_Tag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cookie_Tag>>> GetCookies_Tag()
        {
          if (_context.Cookies_Tag == null)
          {
              return NotFound();
          }
            return await _context.Cookies_Tag.ToListAsync();
        }

        // GET: api/Cookie_Tag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cookie_Tag>> GetCookie_Tag(int? id)
        {
          if (_context.Cookies_Tag == null)
          {
              return NotFound();
          }
            var cookie_Tag = await _context.Cookies_Tag.FindAsync(id);

            if (cookie_Tag == null)
            {
                return NotFound();
            }

            return cookie_Tag;
        }

        // PUT: api/Cookie_Tag/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCookie_Tag(int? id, Cookie_Tag cookie_Tag)
        {
            if (id != cookie_Tag.CookieId)
            {
                return BadRequest();
            }

            _context.Entry(cookie_Tag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cookie_TagExists(id))
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

        // POST: api/Cookie_Tag
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cookie_Tag>> PostCookie_Tag(Cookie_Tag cookie_Tag)
        {
          if (_context.Cookies_Tag == null)
          {
              return Problem("Entity set 'AppDbContext.Cookies_Tag'  is null.");
          }
            _context.Cookies_Tag.Add(cookie_Tag);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Cookie_TagExists(cookie_Tag.CookieId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCookie_Tag", new { id = cookie_Tag.CookieId }, cookie_Tag);
        }

        // DELETE: api/Cookie_Tag/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCookie_Tag(int? id)
        {
            if (_context.Cookies_Tag == null)
            {
                return NotFound();
            }
            var cookie_Tag = await _context.Cookies_Tag.FindAsync(id);
            if (cookie_Tag == null)
            {
                return NotFound();
            }

            _context.Cookies_Tag.Remove(cookie_Tag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Cookie_TagExists(int? id)
        {
            return (_context.Cookies_Tag?.Any(e => e.CookieId == id)).GetValueOrDefault();
        }
    }
}
