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

namespace ProiectMediiBun.Pages.Members
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
            ViewData["MembershipID"] = new SelectList(_context.Set<Membership>(), "ID",
            "MembershipName");
            ViewData["TrainerID"] = new SelectList(_context.Set<Trainer>(), "ID",
            "Name");
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Member.Add(Member);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
