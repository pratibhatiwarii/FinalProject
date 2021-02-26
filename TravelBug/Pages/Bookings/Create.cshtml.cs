using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelBug.Data;
using TravelBug.Models;

namespace TravelBug.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly TravelBug.Data.TravelBugContext _context;

        public CreateModel(TravelBug.Data.TravelBugContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PackageId"] = new SelectList(_context.Set<Package>(), "Id", "Name");
        ViewData["TravelerId"] = new SelectList(_context.Set<Traveler>(), "Id", "Name");
        ViewData["TravelerCoordinatorId"] = new SelectList(_context.Set<TravelCoordinator>(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
