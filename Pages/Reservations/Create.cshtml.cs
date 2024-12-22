using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectMediiBun.Data;
using ProiectMediiBun.Models;

namespace ProiectMediiBun.Pages.Reservations
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : PageModel
    {
        private readonly ProiectMediiBun.Data.ProiectMediiBunContext _context;

        public CreateModel(ProiectMediiBun.Data.ProiectMediiBunContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FirstName");
        ViewData["TerenID"] = new SelectList(_context.Set<Teren>(), "ID", "Tip");
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
