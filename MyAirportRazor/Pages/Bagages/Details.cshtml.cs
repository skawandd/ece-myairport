using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FLS.MyAirport.EF;

namespace MyAirport.Razor.Pages.Bagages
{
    public class DetailsModel : PageModel
    {
        private readonly FLS.MyAirport.EF.MyAirportContext _context;

        public DetailsModel(FLS.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public Bagage Bagage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bagage = await _context.Bagages.FirstOrDefaultAsync(m => m.BagageID == id);

            if (Bagage == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
