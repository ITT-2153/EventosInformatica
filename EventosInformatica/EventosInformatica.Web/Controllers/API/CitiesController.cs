using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventosInformatica.Web.Models;
using EventosInformatica.Web.Models.Entities;
using EventosInformatica.Web.Models.ModelApi;

namespace EventosInformatica.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly DataDbContext _context;

        public CitiesController(DataDbContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public IEnumerable<City> GetCities()
        {
            return _context.Cities;
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = await _context.Cities.Include(a => a.Events)
                .FirstOrDefaultAsync(a => a.Id == id);

            var response = new CityResponse
            {
                Id = city.Id,
                Name = city.Name,
                Description = city.Description,
                Slung = city.Slung,
                Events = city.Events.Select(p => new EventResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Duration = p.Duration,
                    EventDate = p.EventDate,
                    People = p.People,
                    Description = p.Description,
                }).ToList(),
            };

            if (city == null)
            {
                return NotFound();
            }

            return Ok(response);

            /*
            var city = await _context.Cities.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
            */
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity([FromRoute] int id, [FromBody] City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != city.Id)
            {
                return BadRequest();
            }

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        [HttpPost]
        public async Task<IActionResult> PostCity([FromBody] City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCity", new { id = city.Id }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return Ok(city);
        }

        private bool CityExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}