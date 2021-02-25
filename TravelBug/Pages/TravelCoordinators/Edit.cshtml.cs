using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBug.Data;
using TravelBug.Models;

namespace TravelBug.Pages.TravelCoordinators
{
    public class EditModel : PageModel
    {
        private readonly TravelBug.Data.TravelBugContext _context;

        public EditModel(TravelBug.Data.TravelBugContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TravelCoordinator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelCoordinatorExists(TravelCoordinator.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TravelCoordinatorExists(int id)
        {
            return _context.TravelCoordinator.Any(e => e.Id == id);
        }
    }
}
