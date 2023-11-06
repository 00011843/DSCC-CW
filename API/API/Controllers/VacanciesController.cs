using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DAL;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacanciesController : ControllerBase
    {
        private readonly myDbContext _context;

        public VacanciesController(myDbContext context)
        {
            _context = context;
        }

        // GET: api/Vacancies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacancy>>> GetVacancies()
        {
          if (_context.Vacancies == null)
          {
              return NotFound();
          }
            return await _context.Vacancies.ToListAsync();
        }

        // GET: api/Vacancies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacancy>> GetVacancy(int id)
        {
          if (_context.Vacancies == null)
          {
              return NotFound();
          }
            var vacancy = await _context.Vacancies.FindAsync(id);

            if (vacancy == null)
            {
                return NotFound();
            }

            return vacancy;
        }

        // PUT: api/Vacancies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacancy(int id, Vacancy vacancy)
        {
            if (id != vacancy.Id)
            {
                return BadRequest();
            }

            _context.Entry(vacancy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacancyExists(id))
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

        // POST: api/Vacancies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vacancy>> PostVacancy(Vacancy vacancy)
        {
          if (_context.Vacancies == null)
          {
              return Problem("Entity set 'myDbContext.Vacancies'  is null.");
          }
            _context.Vacancies.Add(vacancy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacancy", new { id = vacancy.Id }, vacancy);
        }

        // DELETE: api/Vacancies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacancy(int id)
        {
            if (_context.Vacancies == null)
            {
                return NotFound();
            }
            var vacancy = await _context.Vacancies.FindAsync(id);
            if (vacancy == null)
            {
                return NotFound();
            }

            _context.Vacancies.Remove(vacancy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VacancyExists(int id)
        {
            return (_context.Vacancies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
