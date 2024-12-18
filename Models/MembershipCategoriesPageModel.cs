using Microsoft.AspNetCore.Mvc.RazorPages;
using ProiectMediiBun.Data;
namespace ProiectMediiBun.Models
{
    public class MembershipCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(ProiectMediiBunContext context,
        Membership membership)
        {
            var allCategories = context.Category;
            var membershipCategories = new HashSet<int>(
            membership.MembershipCategories.Select(c => c.CategoryID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = membershipCategories.Contains(cat.ID)
                });
            }

        }
        public void ActualizeazaCategoriileAbonamentelor(ProiectMediiBunContext context, string[] categoriiSelectate, Membership membershipupdatat)
        {
            if(categoriiSelectate==null)
            {
                membershipupdatat.MembershipCategories = new List<MembershipCategory>();
                return;
            }
            var categoriiselectate = new HashSet<string>(categoriiSelectate);
            var membershipCategories = new HashSet<int>(membershipupdatat.MembershipCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (categoriiselectate.Contains(cat.ID.ToString()))
                {
                    if (!membershipCategories.Contains(cat.ID))
                    {
                        membershipupdatat.MembershipCategories.Add(new MembershipCategory
                        {
                            MembershipID = membershipupdatat.ID,
                            CategoryID = cat.ID,

                        });
                    }
                }
                else
                {
                    if(membershipCategories.Contains(cat.ID))
                    {
                        MembershipCategory membershipdesters = membershipupdatat.MembershipCategories.SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(membershipdesters);
                    }
                }
            }
        }
    }
}
