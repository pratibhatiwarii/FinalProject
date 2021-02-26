﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelBug.Data;
using TravelBug.Models;

namespace TravelBug.Pages.Packages
{
    public class DetailsModel : PageModel
    {
        private readonly TravelBug.Data.TravelBugContext _context;

        public DetailsModel(TravelBug.Data.TravelBugContext context)
        {
            _context = context;
        }

        public Package Package { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Package = await _context.Package
                .Include(x => x.Bookings).FirstOrDefaultAsync(m => m.Id == id);

            if (Package == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
