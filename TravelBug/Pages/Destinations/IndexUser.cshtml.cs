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
    public class IndexUserModel : PageModel
    {
        private readonly TravelBug.Data.TravelBugContext _context;

        public IndexUserModel(TravelBug.Data.TravelBugContext context)
        {
            _context = context;
        }

        public IList<Destination> Destination { get; set; }

        public async Task OnGetAsync()
        {
            Destination = await _context.Destination.ToListAsync();
        }
    }
}
