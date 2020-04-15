﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FLS.MyAirport.EF;

namespace MyAirport.Razor.Pages.Bagages
{
    public class IndexModel : PageModel
    {
        private readonly FLS.MyAirport.EF.MyAirportContext _context;

        public IndexModel(FLS.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public IList<Bagage> Bagage { get;set; }

        public async Task OnGetAsync()
        {
            Bagage = await _context.Bagages.ToListAsync();
        }
    }
}
