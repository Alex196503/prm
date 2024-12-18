using System.ComponentModel.DataAnnotations;

namespace ProiectMediiBun.Models
{
    public class Membership:IValidatableObject
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Numele membership-ului este obligatoriu.")]
        [StringLength(100, ErrorMessage = "Numele membership-ului nu poate depăși 100 de caractere.")]

        public string MembershipName { get; set; }
        [Required(ErrorMessage = "Data de start este obligatorie.")]
        [DataType(DataType.Date, ErrorMessage = "Data de start trebuie să fie o dată validă.")]
        public DateTime? Data_Start { get; set; }
        [Required(ErrorMessage = "Data de expirare este obligatorie.")]
        [DataType(DataType.Date, ErrorMessage = "Data de expirare trebuie să fie o dată validă.")]
        public DateTime? Data_Expirare { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Data_Start != null && Data_Expirare != null && Data_Expirare <= Data_Start)
            {
                yield return new ValidationResult(
                    "Data de expirare trebuie să fie mai mare decât data de start.",
                    new[] { nameof(Data_Expirare) }
                );
            }
        }
        public ICollection<Member>? Members { get; set; }
        public ICollection<MembershipCategory>? MembershipCategories { get; set; }

    }
}

