using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FLS.MyAirport.EF;

namespace MyAirportWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolsController : ControllerBase
    {
        private readonly MyAirportContext _context;

        public VolsController(MyAirportContext context)
        {
            _context = context;
        }

        // GET: api/Vols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVols()
        {
            return await _context.Vols.ToListAsync();
        }


        /// <summary>
        /// GET: api/Vols/5?bool bagages
        /// L'option bagages permet d'indiquer si l'on veut voir la liste des bagages du vol ou non
        /// si false bagages = null
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bagages">Indique si l'on veut que la liste des bagages du vol soit incluse dans le résultat</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Vol>> GetVol(int id, [FromQuery] bool bagages = false)
        {
            Vol volRes;
            if (bagages)
                volRes = await _context.Vols.Include(v => v.Bagages).FirstAsync(v=> v.VolId==id);//.Where(v => v.VolId == id).FirstAsync(); // On veut afficher les vols et les bagages 
            else
                volRes = await _context.Vols.FindAsync(id);
            //volRes = await _context.Vols.FindAsync(id);

            if (volRes == null)
            {
                return NotFound();
            }
            // Obligé de mettre les find async dans le if sinon problème de bagage dans le vol dans le bagage . Et les méthodes écrasent toute deux le datacontext 

            return volRes;

        }

        // PUT: api/Vols/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVol(int id, Vol vol)
        {
            if (id != vol.VolId)
            {
                return BadRequest();
            }

            _context.Entry(vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(id))
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

        // POST: api/Vols
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Vol>> PostVol(Vol vol)
        {
            _context.Vols.Add(vol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVol", new { id = vol.VolId }, vol);
        }

        // DELETE: api/Vols/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vol>> DeleteVol(int id)
        {
            var vol = await _context.Vols.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }

            _context.Vols.Remove(vol);
            await _context.SaveChangesAsync();

            return vol;
        }

        private bool VolExists(int id)
        {
            return _context.Vols.Any(e => e.VolId == id);
        }
    }
}
