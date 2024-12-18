using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMediiBun.Data;
using ProiectMediiBun.Models;

namespace ProiectMediiBun.Pages.Memberships
{
    public class EditModel : MembershipCategoriesPageModel
    {
        private readonly ProiectMediiBun.Data.ProiectMediiBunContext _context;

        public EditModel(ProiectMediiBun.Data.ProiectMediiBunContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Membership Membership { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Membership = await _context.Membership
                .Include(m => m.MembershipCategories)  
                .ThenInclude(m => m.Category)          
                .Include(m => m.Members)               
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Membership == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Membership);
            var MemberList = _context.Member.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });
            ViewData["MemberID"] = new SelectList(MemberList, "ID", "FullName");
                        return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int ?id, string[] categoriiselectate)

        {
            if(id==null)
            {
                return NotFound();
            }
            var membershipdeupdatat = await _context.Membership
                 .Include(i=>i.Members)
                .Include(i => i.MembershipCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);
               if(membershipdeupdatat == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Membership>(membershipdeupdatat,
                "Membership",
                i => i.MembershipName, i => i.Data_Start, i => i.Data_Expirare, i => i.Members))
            {
                ActualizeazaCategoriileAbonamentelor(_context, categoriiselectate, membershipdeupdatat);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            ActualizeazaCategoriileAbonamentelor(_context, categoriiselectate, membershipdeupdatat);
            PopulateAssignedCategoryData(_context, membershipdeupdatat);
            return Page();

           

            _context.Attach(Membership).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembershipExists(Membership.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MembershipExists(int id)
        {
            return _context.Membership.Any(e => e.ID == id);
        }
    }
}
