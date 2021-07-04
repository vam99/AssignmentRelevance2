using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AssignmentRelevance2
{
    public class Produse
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Campul Cod trebuie completat.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Campul Cod trebuie sa contina valori intregi mai mari ca 0.")]
        public int? Cod { get; set; }

        [Required(ErrorMessage = "Campul Descriere trebuie completat.")]
        [MaxLength(10, ErrorMessage = "Campul Descriere trebuie sa aiba max 10 caractere.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Campul Descriere nu trebuie sa contina cifre.")]
        public string Descriere { get; set; }

        [Required(ErrorMessage = "Campul Pret trebuie completat.")]
        [Range(0.01, 99999.99, ErrorMessage = "Pretul trebuie sa fie pozitiv si nu mai mare de 100000")]
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Pretul trebuie sa aiba maxim 2 zecimale")]
        public decimal? Pret { get; set; }

        [Required(ErrorMessage = "Campul Cantitate trebuie completat.")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Campul Cantitate trebuie sa contina valori intregi mai mari ca 0.")]
        public int? Cantitate { get; set; }

        public decimal getValoare()
        {
            return (decimal)(this.Pret*this.Cantitate);
        }
    }
}
