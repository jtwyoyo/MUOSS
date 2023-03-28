using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequestManagement.Server;
using RequestManagement.Shared.Models;

namespace RequestManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrRequestsController : ControllerBase
    {
        private readonly MuossContext _context;

        public TrRequestsController(MuossContext context)
        {
            _context = context;
        }

        //// GET: api/TrRequests/pageSize=X&pageNum=Y
        [HttpGet]
        [ProducesResponseType(typeof(TrRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTrRequests(int pageSize, int pageNum)
        {
            var result = await _context.TrRequests.Skip((pageNum) * pageSize)
                .OrderBy(r => r.RequestID)
                .Take(pageSize)
                .Include(r => r.TrRequestItems)
                .ToListAsync();
            return result == null ? NotFound() : Ok(result);
        }

        // GET: api/TrRequests
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TrRequest>>> GetTrRequests()
        //{
        //    if (_context.TrRequests == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _context.TrRequests.ToListAsync();
        //}

        // GET: api/TrRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrRequest>> GetTrRequest(int id)
        {
          if (_context.TrRequests == null)
          {
              return NotFound();
          }
            var trRequest = await _context.TrRequests.FindAsync(id);

            if (trRequest == null)
            {
                return NotFound();
            }

            return trRequest;
        }

        // PUT: api/TrRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrRequest(int id, TrRequest trRequest)
        {
            if (id != trRequest.RequestID)
            {
                return BadRequest();
            }

            _context.Entry(trRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrRequestExists(id))
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

        // POST: api/TrRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrRequest>> PostTrRequest(TrRequest trRequest)
        {
          if (_context.TrRequests == null)
          {
              return Problem("Entity set 'MuossContext.TrRequests'  is null.");
          }
            _context.TrRequests.Add(trRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrRequest", new { id = trRequest.RequestID }, trRequest);
        }

        // DELETE: api/TrRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrRequest(int id)
        {
            if (_context.TrRequests == null)
            {
                return NotFound();
            }
            var trRequest = await _context.TrRequests.FindAsync(id);
            if (trRequest == null)
            {
                return NotFound();
            }

            _context.TrRequests.Remove(trRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrRequestExists(int id)
        {
            return (_context.TrRequests?.Any(e => e.RequestID == id)).GetValueOrDefault();
        }
    }
}
