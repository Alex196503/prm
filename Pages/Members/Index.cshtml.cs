using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMediiBun.Data;
using ProiectMediiBun.Models;
using ProiectMediiBun.Models;
using ProiectMediiBun.Models.ViewModels;

namespace Proiect_Medii.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly ProiectMediiBun.Data.ProiectMediiBunContext _context;

        public IndexModel(ProiectMediiBun.Data.ProiectMediiBunContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get; set; } = default!;
        public MemberIndexData MemberData { get; set; }
        public int MemberID { get; set; }

        public int MembershipID { get; set; }
        public string FirstNameSort { get; set; }
        public string TrainerNameSort { get; set; }
        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(int? id,int?membershipID,string SortOrder,string searchString)
        {
            MemberData = new MemberIndexData();
            FirstNameSort = String.IsNullOrEmpty(SortOrder) ? "firstname_desc" : "";
            TrainerNameSort = SortOrder == "trainer" ? "trainer_desc" : "trainer";
            CurrentFilter = searchString;
            MemberData.Members = await _context.Member
                .Include(m => m.Membership)
                .Include(m => m.Trainer)
                .OrderBy(m=>m.LastName)
                .ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                MemberData.Members = MemberData.Members.Where(s => s.Trainer.Name.Contains(searchString)
                || s.FirstName.Contains(searchString));
            }
            if(id!=null)
            {
                MemberID = id.Value;
                var membruselectat = MemberData.Members
                    .Where(m => m.ID == id.Value).Single();
                MemberData.Memberships=membruselectat.Membership!=null
                    ?new List<Membership> { membruselectat.Membership}
                    : new List<Membership>();
            }
        switch(SortOrder)
            {
                case "title_desc":
                    MemberData.Members = MemberData.Members.OrderByDescending(s => s.FirstName);
                    break;
                case "trainer_desc":
                    MemberData.Members = MemberData.Members.OrderByDescending(s => s.Trainer.Name);
                    break;
                case "trainer":
                    MemberData.Members = MemberData.Members.OrderBy(s => s.Trainer.Name);
                    break;
                default:
                    MemberData.Members = MemberData.Members.OrderBy(s => s.FirstName);
                    break;
            }
        }
    }
}