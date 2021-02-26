using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelBug.Data;
using TravelBug.Models;

namespace TravelBug.Pages.Packages
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
        ViewData["DestinationId"] = new SelectList(_context.Destination, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Package Package { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Package.Add(Package);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
