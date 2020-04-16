using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FLS.MyAirport.EF;

namespace MyAirport.Razor.Pages.Bagages
{
    public class CreateModel : PageModel
    {
        private readonly FLS.MyAirport.EF.MyAirportContext _context;

        public CreateModel(FLS.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //ViewData["VolID"] = new SelectList(_context.Vols, "VolID", "CIE" + "LIG" + "DHC");// Ne fonctionne pas, je dois construire ma liste avec ma requête 

            ViewData["VolID"] = BagagesHelper.ListVolInfo(_context);

            return Page();
        }

        [BindProperty]
        public FLS.MyAirport.EF.Bagage Bagage { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bagages.Add(Bagage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
