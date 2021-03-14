using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using codiling.Contexts;
using codiling.Models;

namespace codiling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodingChallengesController : ControllerBase
    {
        private readonly codilingContext _context;

        public CodingChallengesController(codilingContext context)
        {
            _context = context;
        }

        // GET: api/CodingChallenges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodingChallenge>>> GetCodingChallenges()
        {
            List<CodingChallenge> challenges = await _context.CodingChallenges.ToListAsync();

            return challenges;
        }

        // GET: api/CodingChallenges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CodingChallenge>> GetCodingChallenge(int id)
        {
            var codingChallenge = await _context.CodingChallenges.FindAsync(id);

            if (codingChallenge == null)
            {
                return NotFound();
            }

            return codingChallenge;
        }

        // PUT: api/CodingChallenges/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCodingChallenge(int id, CodingChallenge codingChallenge)
        {
            if (id != codingChallenge.Id)
            {
                return BadRequest();
            }

            _context.Entry(codingChallenge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodingChallengeExists(id))
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

        // POST: api/CodingChallenges
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CodingChallenge>> PostCodingChallenge(CodingChallenge codingChallenge)
        {
            _context.CodingChallenges.Add(codingChallenge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCodingChallenge", new { id = codingChallenge.Id }, codingChallenge);
        }

        // DELETE: api/CodingChallenges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CodingChallenge>> DeleteCodingChallenge(int id)
        {
            var codingChallenge = await _context.CodingChallenges.FindAsync(id);
            if (codingChallenge == null)
            {
                return NotFound();
            }

            _context.CodingChallenges.Remove(codingChallenge);
            await _context.SaveChangesAsync();

            return codingChallenge;
        }

        private bool CodingChallengeExists(int id)
        {
            return _context.CodingChallenges.Any(e => e.Id == id);
        }
    }
}
