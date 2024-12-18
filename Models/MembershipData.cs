using static System.Reflection.Metadata.BlobBuilder;

namespace ProiectMediiBun.Models
{
    public class MembershipData
    {
        public IEnumerable<Membership> Memberships { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<MembershipCategory> MembershipCategories { get; set; }
    }
}
