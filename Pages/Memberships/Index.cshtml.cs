using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMediiBun.Data;
using ProiectMediiBun.Models;

namespace ProiectMediiBun.Pages.Memberships
{
    public class IndexModel : PageModel
    {
        private readonly ProiectMediiBun.Data.ProiectMediiBunContext _context;

        public IndexModel(ProiectMediiBun.Data.ProiectMediiBunContext context)
        {
            _context = context;
        }

        public IList<Membership> Membership { get;set; } = default!;
        public MembershipData MembershipD {  get; set; }
        public int MembershipID { get; set; }

        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id,int? categoryID)
        {
            Membership = await _context.Membership.ToListAsync();
            MembershipD=new MembershipData();
            MembershipD.Memberships=await _context.Membership
                .Include(m => m.Members)
                .Include(m=>m.MembershipCategories)
                .ThenInclude(m=>m.Category)
                .AsNoTracking()
                .OrderBy(m=>m.MembershipName)
                .ToListAsync();
            if(id!=null)
            {
                MembershipID = id.Value;
                Membership membership = MembershipD.Memberships
                    .Where(i => i.ID == id.Value).SingleOrDefault();
                MembershipD.Categories = membership.MembershipCategories.Select(s => s.Category);

            }

                
        }
    }
}
