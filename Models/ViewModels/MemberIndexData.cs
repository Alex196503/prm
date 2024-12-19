using ProiectMediiBun.Models;
namespace ProiectMediiBun.Models.ViewModels
{
    public class MemberIndexData
    {
        public IEnumerable<Member> Members { get; set; }
        public IEnumerable <Membership> Memberships { get; set; }
    }
}
