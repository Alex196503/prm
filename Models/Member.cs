using System.ComponentModel.DataAnnotations;

namespace ProiectMediiBun.Models
{
    public class Member
    {
        public int ID
        {
            get; set;
        }
        [Display(Name="Last Name")]
        [RegularExpression(@"^[A-Z]+[a-z\s]*$",ErrorMessage="Numele trebuie sa inceapa cu majuscula")]
        [StringLength(50, MinimumLength = 3)]

        public string LastName { get; set; }
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-z\s]*$",ErrorMessage="Prenumele trebuie sa inceapa cu majuscula")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }
        [EmailAddress(ErrorMessage="Formatul email-ului nu este valid.")]
        [StringLength(50, MinimumLength = 10)]
        public string Email { get; set; }
        [StringLength(80, ErrorMessage = "Adresa trebuie sa contina maximum 80 de caractere!")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate
        {
            get; set;
        }
        public int? MembershipID { get; set; }
        public Membership? Membership { get; set; }
        public int? TrainerID { get; set; }
        public Trainer? Trainer { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
