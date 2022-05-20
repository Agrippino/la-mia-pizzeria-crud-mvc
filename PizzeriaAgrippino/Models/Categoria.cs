using System.ComponentModel.DataAnnotations;

namespace PizzeriaAgrippino.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Il campo è obbligatorio, inserisci qualcosa per favore")]
        [StringLength(100, ErrorMessage ="Il titolo della categoria non può superare i 100 caratteri")]
        public string TitoloCategoria { get; set; }

        public List<Pizze> Pizzes { get; set; }

        public Categoria()
        {

        }
    }
}
