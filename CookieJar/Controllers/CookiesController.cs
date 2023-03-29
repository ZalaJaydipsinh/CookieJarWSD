using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookieJar.Models;
using Azure.Core;

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
            return await _context.Cookies.Include(c => c.Tags).ToListAsync();
        }

        // GET: api/Cookies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cookie>> GetCookie(int id)
        {
          if (_context.Cookies == null)
          {
              return NotFound();
          }
            //var cookie = await _context.Cookies.FindAsync(id);
            var cookie = await _context.Cookies.Include(c => c.Id == id).Include(c => c.Tags).FirstAsync();

            if (cookie == null)
            {
                return NotFound();
            }

            return cookie;
        }

        // PUT: api/Cookies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCookie(int id, CreateCookieDto cookie)
        {
            var updatedCookie = await _context.Cookies.FindAsync(id);
            if (updatedCookie == null)
            {
                return NotFound();
            }     

            updatedCookie.Title = cookie.Title;
            updatedCookie.Message = cookie.Message;
            updatedCookie.UserId = cookie.UserId;   

            _context.Entry(updatedCookie).State = EntityState.Modified;

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

        // GET: api/User/Cookies/5
        [HttpGet("User/{id}")]
        public async Task<ActionResult<IEnumerable<Cookie>>> GetUserCookies(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var cookies = await _context.Cookies.Include(c=> c.Tags).Where(c => c.UserId == user.Id).ToListAsync();

            if(cookies == null)
            {
                return NotFound();
            }

            return cookies;
        }

        // POST: api/Cookies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cookie>> PostCookie(CreateCookieDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return NotFound();

            var cookie = new Cookie
            {
                Title = request.Title,
                Message = request.Message,
                UserId = request.UserId
            };

          if (_context.Cookies == null)
          {
              return Problem("Entity set 'AppDbContext.Cookies'  is null.");
          }
            _context.Cookies.Add(cookie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCookie", new { id = cookie.Id }, cookie);
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
            return (_context.Cookies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
