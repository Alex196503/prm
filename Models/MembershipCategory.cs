namespace ProiectMediiBun.Models
{
    public class MembershipCategory
    {
        public int ID { get; set; }
        public int MembershipID { get; set; }
        public Membership Membership { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
