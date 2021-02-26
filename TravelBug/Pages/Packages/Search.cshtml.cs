using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelBug.Data;
using TravelBug.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelBug.Pages.Packages
{
    public class SearchModel : PageModel
    {
        private TravelBugContext tb_context;

        public SearchModel(TravelBugContext context)
        {
            tb_context = context;
        }

        [BindProperty]
        public string search { get; set; }

        public bool IsSearchDone { get; set; }

        public ICollection<Package> SearchResults { get; set; }

        public ICollection<Package> Packages { get; set; }


        public void OnGet()
        {
            Packages = tb_context.Package
                                    .Include(x => x.Destination)
                                    .OrderBy(x => x.Name)
                                    .ToList();
            IsSearchDone = false;
        }

        public void OnPost()
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                Packages = tb_context.Package
                                .Include(x => x.Destination)
                                .OrderBy(x => x.Name)
                                .ToList();
                return;
            }
            Packages = tb_context.Package
                                    .Include(x => x.Destination)
                                    .OrderBy(x => x.Name)
                                    .ToList();

            SearchResults = tb_context.Package
                                    .Include(x => x.Destination)
                                    .Where(x => x.Destination.Name.ToLower().Contains(search.ToLower()))
                                    .ToList();
            IsSearchDone = true;
        }

    }
}
