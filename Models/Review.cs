using System.ComponentModel.DataAnnotations;

namespace ProiectMediiBun.Models
{
    public class Review
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Rating-ul este obligatoriu")]
        [Range(1, 10, ErrorMessage = "Rating-ul trebuie să fie între 1 și 10.")]
        public int Rating { get; set; }
        [StringLength(500, ErrorMessage = "Comentariul nu poate depăși 500 de caractere.")]
        public string? Comment { get; set; }
        [Required(ErrorMessage = "Data review-ului este obligatorie.")]
        [DataType(DataType.Date, ErrorMessage = "Data recenziei trebuie să fie o dată validă.")]
        public DateTime Data_Review { get; set; }
        public int TrainerID
        {
            get; set;
        }
        public Trainer? Trainer { get; set; }

    }
}

