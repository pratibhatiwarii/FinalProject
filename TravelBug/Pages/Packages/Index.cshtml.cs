using System;
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
    public class IndexModel : PageModel
    {
        private readonly TravelBug.Data.TravelBugContext _context;

        public IndexModel(TravelBug.Data.TravelBugContext context)
        {
            _context = context;
        }

        public IList<Package> Package { get;set; }

        public async Task OnGetAsync()
        {
            Package = await _context.Package
                .Include(p => p.Destination).ToListAsync();
        }
    }
}
