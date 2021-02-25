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
    public class IndexModel : PageModel
    {
        private readonly TravelBug.Data.TravelBugContext _context;

        public IndexModel(TravelBug.Data.TravelBugContext context)
        {
            _context = context;
        }

        public IList<TravelCoordinator> TravelCoordinator { get;set; }

        public async Task OnGetAsync()
        {
            TravelCoordinator = await _context.TravelCoordinator.ToListAsync();
        }
    }
}
