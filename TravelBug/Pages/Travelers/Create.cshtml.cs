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

namespace TravelBug.Pages.Travelers
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
        public Traveler Traveler { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // DATE OF BIRTH VALIDATION
            var birthYear = Traveler.DateOfBirth.Year;
            var latestAllowedYear = DateTime.Now.Year - 18;
            if (birthYear > latestAllowedYear)
            {
                ModelState.AddModelError("Traveler.DateOfBirth", "Booking Person must be 18 years or older");
            }



            // EMAIL VALIDATION
            var emailID = Traveler.EmailID;
            bool emailAlreadyExists = await _context.Traveler.AnyAsync(x => x.EmailID == emailID);



            if (emailAlreadyExists)
            {
                ModelState.AddModelError("Traveler.emailID", "Traveler with this emailID already exists");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // Phone VALIDATION
            var phoneNumber = Traveler.PhoneNumber;
            bool phoneAlreadyExists = await _context.Traveler.AnyAsync(x => x.PhoneNumber == phoneNumber);



            if (phoneAlreadyExists)
            {
                ModelState.AddModelError("Traveler.PhoneNumber", "Traveler with this Phone Number already exists");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }




            _context.Traveler.Add(Traveler);
            await _context.SaveChangesAsync();



            return RedirectToPage("./Index");
        }
    }
}
