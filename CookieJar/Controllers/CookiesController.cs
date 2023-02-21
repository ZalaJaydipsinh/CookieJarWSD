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
    public class CookiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CookiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cookies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cookie>>> GetCookies()
        {
          if (_context.Cookies == null)
          {
              return NotFound();
          }
            return await _context.Cookies.ToListAsync();
        }

        // GET: api/Cookies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cookie>> GetCookie(int id)
        {
          if (_context.Cookies == null)
          {
              return NotFound();
          }
            var cookie = await _context.Cookies.FindAsync(id);

            if (cookie == null)
            {
                return NotFound();
            }

            return cookie;
        }

        // PUT: api/Cookies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCookie(int id, Cookie cookie)
        {
            if (id != cookie.CookieId)
            {
                return BadRequest();
            }

            _context.Entry(cookie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CookieExists(id))
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

        // POST: api/Cookies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cookie>> PostCookie(Cookie cookie)
        {
          if (_context.Cookies == null)
          {
              return Problem("Entity set 'AppDbContext.Cookies'  is null.");
          }
            _context.Cookies.Add(cookie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCookie", new { id = cookie.CookieId }, cookie);
        }

        // DELETE: api/Cookies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCookie(int id)
        {
            if (_context.Cookies == null)
            {
                return NotFound();
            }
            var cookie = await _context.Cookies.FindAsync(id);
            if (cookie == null)
            {
                return NotFound();
            }

            _context.Cookies.Remove(cookie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CookieExists(int id)
        {
            return (_context.Cookies?.Any(e => e.CookieId == id)).GetValueOrDefault();
        }
    }
}
