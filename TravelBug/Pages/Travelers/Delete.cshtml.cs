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
    public class DeleteModel : PageModel
    {
        private readonly TravelBug.Data.TravelBugContext _context;

        public DeleteModel(TravelBug.Data.TravelBugContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Traveler Traveler { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Traveler = await _context.Traveler.FirstOrDefaultAsync(m => m.Id == id);

            if (Traveler == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Traveler = await _context.Traveler.FindAsync(id);

            if (Traveler != null)
            {
                _context.Traveler.Remove(Traveler);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
