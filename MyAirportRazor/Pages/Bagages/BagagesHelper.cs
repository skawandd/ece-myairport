using FLS.MyAirport.EF;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirport.Razor.Pages.Bagages
{
    public class BagagesHelper
    {
        public static SelectList ListVolInfo(MyAirportContext _context)
        {
            var vols = _context.Vols.Select(v => new
            {
                v.VolId,
                Description = $"{v.CIE} {v.LIG} : {v.DHC.ToShortDateString()}"
            }).ToList();
            return new SelectList(vols, "VolId", "Description");

        }
    }
}
