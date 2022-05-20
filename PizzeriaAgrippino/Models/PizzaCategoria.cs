namespace PizzeriaAgrippino.Models
{
    public class PizzaCategoria
    {
        public Pizze Pizze { get; set; }
        //aggiungo il ? perché così posso lavorare anche quando mi arriva un null da parte di get 
        public List<Categoria>? ListaCategoria { get; set; }
    }
}
