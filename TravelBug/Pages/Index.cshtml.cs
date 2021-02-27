using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBug.Models;
using TravelBug.Data;

namespace TravelBug.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private TravelBugContext tb_context;

        //public IndexModel(TravelBugContext context)
        //{
        //    tb_context = context;
        //}

        public IndexModel(ILogger<IndexModel> logger, TravelBugContext context)
        {
            _logger = logger;
            tb_context = context;
        }

        public int TotalPackages {get;set;}
        public int TotalDestinations { get; set; }

        public void OnGet()
        {
            TotalPackages = tb_context.Package.Count();
            TotalDestinations = tb_context.Destination.Count();

        }
    }
}
