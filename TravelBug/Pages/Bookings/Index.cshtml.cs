using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelBug.Data;
using TravelBug.Models;

namespace TravelBug.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly TravelBug.Data.TravelBugContext _context;

        public IndexModel(TravelBug.Data.TravelBugContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; }

        public async Task OnGetAsync()
        {
            Booking = await _context.Booking
                .Include(b => b.Package)
                .Include(b => b.Traveler)
                .Include(b => b.TravelerCoordinator).ToListAsync();
        }
    }
}
