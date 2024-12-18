using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectMediiBun.Data;
using ProiectMediiBun.Models;

namespace ProiectMediiBun.Pages.Memberships
{
    public class CreateModel : MembershipCategoriesPageModel
    {
        private readonly ProiectMediiBun.Data.ProiectMediiBunContext _context;

        public CreateModel(ProiectMediiBun.Data.ProiectMediiBunContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var memberList = _context.Member.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });
            var membership = new Membership();
            membership.MembershipCategories = new List<MembershipCategory>();
            PopulateAssignedCategoryData(_context, membership);
            return Page();
          

        }

        [BindProperty]
        public Membership Membership { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[]categoriiselectate)
        {
            var newmembership = new Membership();
            if(categoriiselectate!=null)
            {
                newmembership.MembershipCategories= new List<MembershipCategory>();
                foreach(var cat in categoriiselectate)
                {
                    var catdeadaugat = new MembershipCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newmembership.MembershipCategories.Add(catdeadaugat);
                }
            }
            Membership.MembershipCategories = newmembership.MembershipCategories;
            _context.Membership.Add(Membership);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            
        }
    }
}
