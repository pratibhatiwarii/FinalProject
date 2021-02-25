using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelBug.Data;
using TravelBug.Models;

namespace TravelBug.Pages.TravelCoordinators
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
            return Page();
        }

        [BindProperty]
        public TravelCoordinator TravelCoordinator { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TravelCoordinator.Add(TravelCoordinator);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
