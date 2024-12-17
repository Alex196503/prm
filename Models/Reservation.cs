using System.ComponentModel.DataAnnotations;

namespace ProiectMediiBun.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Data rezervarii este obligatorie.")]
        [DataType(DataType.Date, ErrorMessage = "Data rezervarii trebuie să fie o dată validă.")]
        public DateTime Data_Rezervarii { get; set; }
        [Required(ErrorMessage = "Durata rezervarii este obligatorie.")]
        [Range(1, 24, ErrorMessage = "Durata rezervarii trebuie sa fie intre 1 si 24 de ore")]
        public int Durata { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? TerenID { get; set; }
        public Teren? Teren { get; set; }

    }
}
