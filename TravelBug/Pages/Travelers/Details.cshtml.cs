using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelBug.Data;
using TravelBug.Models;

namespace TravelBug.Pages.Travelers
{
    public class DetailsModel : PageModel
    {
        private readonly TravelBug.Data.TravelBugContext _context;

        public DetailsModel(TravelBug.Data.TravelBugContext context)
        {
            _context = context;
        }

        public Traveler Traveler { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Traveler = await _context.Traveler.Include(x => x.Bookings).FirstOrDefaultAsync(m => m.Id == id);

            if (Traveler == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
