using System.ComponentModel.DataAnnotations;

namespace PizzeriaAgrippino.Models

{
    public class Pizze
    {
        //inseriamo required che obbliga all'utente di inserire quel campo o una determinata informazione
        public int Id { get; set; }
        [Required(ErrorMessage="Il campo immagine è obbligatorio")]
        [Url(ErrorMessage = "Non hai inserito un Url valido")]
        public string ImagePizza { get; set; }
        [Required(ErrorMessage = "Il campo nome è obbligatorio")]
        [StringLength(10, ErrorMessage = "Hai superato il limire di caratteri massimo di 10")]
        public string NamePizza { get; set; }
        [Required(ErrorMessage = "Il campo Descrizione è obbligatorio")]
        [StringLength(250, ErrorMessage = "Hai superato il limire di caratteri massimo di 250")]
        public string DescriptionPizza { get; set; }
        [Required(ErrorMessage = "Il campo Prezzo è obbligatorio")]
        [Range(0.01,30, ErrorMessage = "Mi dispaice hai inserito un prezzo non valido, i minimo è 0.01€ mentre il massimo è 30€ ")]
        public double PricePizza { get; set; }
        
        public Pizze()
        {

        }

        public Pizze(int id, string imagePizza, string namePizza, string descriptionPizza, double pricePizza)
        {
            this.Id = id;
            this.ImagePizza = imagePizza;
            this.NamePizza = namePizza;
            this.DescriptionPizza = descriptionPizza;
            this.PricePizza = pricePizza;
            
        }
    }
}
