﻿namespace ProiectMediiBun.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<MembershipCategory>?MembershipCategories { get; set; }

    }
}
