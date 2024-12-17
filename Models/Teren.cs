using System.ComponentModel.DataAnnotations;

namespace ProiectMediiBun.Models
{
    public class Teren
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Tipul terenului este obligatoriu.")]
        [StringLength(50, ErrorMessage = "Tipul terenului nu poate depăși 50 de caractere.")]
        public string Tip { get; set; }
        [Required(ErrorMessage = "Dimensiunea terenului este obligatorie.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Dimensiunea terenului trebuie să fie mai mare de 0.")]
        public double Dimensiune { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
