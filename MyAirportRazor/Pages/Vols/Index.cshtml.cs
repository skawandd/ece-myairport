using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FLS.MyAirport.EF;

namespace MyAirport.Razor.Pages.Vols
{
    public class IndexModel : PageModel
    {
        private readonly FLS.MyAirport.EF.MyAirportContext _context;

        public IndexModel(FLS.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public IList</*FLS.MyAirport.EF.*/Vol> Vol { get;set; }
        // Plus besoin car on a mis des 's'
        public async Task OnGetAsync()
        {
            Vol = await _context.Vols.ToListAsync();
        }
    }
}
