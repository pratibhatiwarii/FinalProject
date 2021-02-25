using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelBug.Data;
using TravelBug.Models;

namespace TravelBug.Pages.Destinations
{
    public class DeleteModel : PageModel
    {
        private readonly TravelBug.Data.TravelBugContext _context;

        public DeleteModel(TravelBug.Data.TravelBugContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Destination Destination { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Destination = await _context.Destination.FirstOrDefaultAsync(m => m.Id == id);

            if (Destination == null)
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

            Destination = await _context.Destination.FindAsync(id);

            if (Destination != null)
            {
                _context.Destination.Remove(Destination);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
