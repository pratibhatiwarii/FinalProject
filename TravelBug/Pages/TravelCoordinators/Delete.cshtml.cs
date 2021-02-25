using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelBug.Data;
using TravelBug.Models;

namespace TravelBug.Pages.TravelCoordinators
{
    public class DeleteModel : PageModel
    {
        private readonly TravelBug.Data.TravelBugContext _context;

        public DeleteModel(TravelBug.Data.TravelBugContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TravelCoordinator TravelCoordinator { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TravelCoordinator = await _context.TravelCoordinator.FirstOrDefaultAsync(m => m.Id == id);

            if (TravelCoordinator == null)
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

            TravelCoordinator = await _context.TravelCoordinator.FindAsync(id);

            if (TravelCoordinator != null)
            {
                _context.TravelCoordinator.Remove(TravelCoordinator);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
