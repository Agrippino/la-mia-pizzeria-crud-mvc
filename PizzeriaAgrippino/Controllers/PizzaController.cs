using Microsoft.AspNetCore.Mvc;
using PizzeriaAgrippino.Data;
using PizzeriaAgrippino.Models;


namespace PizzeriaAgrippino.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //adesso aggiungiamo il nuovo sistema che abbiamo imparato con i DB
            List<Pizze> pizzes = new List<Pizze>();

            using (PizzaContext DatabasePizza = new PizzaContext())
            {
                pizzes = DatabasePizza.Pizzas.ToList<Pizze>();
            }
            //il controller dice le liste e il modello 
            //quando chiamo il controller idez il controller si chiama la lista dei post con il metodo getspost()
            // 

            //poi dobbiamo passare una razor, quindi inseriamo il nome della lista, cioè pizzes 
            // potremmo anche non inserire homepage nel caso in cui avessimo lasciato il file nominato index 
            return View("HomePage", pizzes);
        }
        //creiamo una nuova pagina, quindi per prima cosa creiamo un metodo nuovo
        [HttpGet]
        //il metodo servirà per vedere i dettagli di un determinato post quindi inseriamo l'id, quindi il parametro 
        public IActionResult Dettagli(int id)
        {
            //dichiariamo un oggeto temporaneo che sarà null per ora 
            //Per trovare la pizza scansiona la lista Pizze, lo facciamo con richiamando il metodo getposts che scansiona tutta la lista delle nostre pizze
            //Ovviamente creo questa vista nel controller pizze(cartella)
            using (PizzaContext DatabasePizza = new PizzaContext())
            {
                try { 
                // adesso creiamo un nuovo sistema per trovare le pizze 
                Pizze TrovaPizza = DatabasePizza.Pizzas.Where(Pizze => Pizze.Id == id)
                        .Include(Pizze => Pizze.Categoria)
                        .FirstOrDefault();
                //aggiungo il .include perché così entity framework le categorie, non lo fa lui di sua spontanea volontà perché crede che siano troppo pesanti
                //Se trovo una pizza con lo stesso id, dico che TDP è uguale a pizze e poi eseguo un break per uscire.
                                
                    return View("Dettagli", TrovaPizza);
                } catch(InvalidOperationException ex)
                {
                    return NotFound("Il post con id" + id + " non è stato trovato");
                }catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            //Se la pizza è stata trovata e quindi è diverso da null, faccio un return vista "dettagli" con il modello agganciato che sarebbe la pizza trovata         
            //altrimenti se non è stato trovato invio un messaggio di errrore che segna anche l'id, è simile al concetto di CW e Console.error
            //Dopo aver fatto tutto questo devo creare in pizze una vista 
        }
        //creiamo un metodo per il aggiugere pizze ala mia pizzeria da parte dell'utente
        //Inseriamo il httpPost e inseriamo il validation pr evitare gli hacker 
        //creiamo anche un http get per scambiare le infomazioni 
        [HttpGet]
        public IActionResult CreaPizza()
        {   
            using (PizzaContext DatabasePizza = new PizzaContext())
            {
                List<Categoria> categorias = DatabasePizza.Categorias.ToList();
                PizzaCategoria model = new PizzaCategoria();
                model.Pizze = new Pizze ();
                model.ListaCategoria = categorias;
                return View("FormPizza", model);
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //creiamo poi un metodo chiamato creaPizza per acciugnere le pizze, aggiugnere il modello 
        public IActionResult CreaPizza(PizzaCategoria Data)
        {
            //se il modello non  è valido ritorniamo una view
            if (!ModelState.IsValid)
            {
                using (PizzaContext DatabasePizza = new PizzaContext())
                {  
                    List<Categoria> categorias = DatabasePizza.Categorias.ToList();
                    Data.ListaCategoria = categorias;
                }
                return View("FormPizza", Data);
            }

            using (PizzaContext DatabasePizza = new PizzaContext())
            {
                Pizze PizzaDaCreare = new Pizze();
                PizzaDaCreare.ImagePizza = Data.Pizze.ImagePizza;
                PizzaDaCreare.NamePizza = Data.Pizze.NamePizza;
                PizzaDaCreare.DescriptionPizza = Data.Pizze.DescriptionPizza;
                PizzaDaCreare.PricePizza = Data.Pizze.PricePizza;
                PizzaDaCreare.CategoriaId = Data.Pizze.CategoriaId;
                DatabasePizza.Add(PizzaDaCreare);
                DatabasePizza.SaveChanges();

            }
           
            return RedirectToAction("Index");

        }



        [HttpGet]
        public IActionResult Modifica(int id)
        {
            Pizze ModificaPizza = null;
            List<Categoria> categorias = new List<Categoria>();

            using (PizzaContext DatabasePizza = new PizzaContext())
            {

                ModificaPizza = DatabasePizza.Pizzas
                 .Where(Pizze => Pizze.Id == id)
                 .FirstOrDefault();
                categorias = DatabasePizza.Categorias.ToList<Categoria>();
            }
            if (ModificaPizza == null)
            {
                return NotFound();
            }
            else
            {   //la pizza da modificare esiste 
                PizzaCategoria model = new PizzaCategoria();
                model.Pizze = ModificaPizza;
                model.ListaCategoria = categorias;
                return View("AggiornaPizze", model);
            }
        }

        [HttpPost]
        public IActionResult Modifica(int id,PizzaCategoria model)
        {
            if (!ModelState.IsValid)
            {
                using (PizzaContext DatabasePizza = new PizzaContext())
                {
                    List<Categoria> categorias = DatabasePizza.Categorias.ToList();
                    model.ListaCategoria = categorias;

                }
                return View("AggiornaPizze", model);
            }
                Pizze PizzaDaAggiornare = null;
            using (PizzaContext DatabasePizza = new PizzaContext())
            {
                PizzaDaAggiornare = DatabasePizza.Pizzas
                    .Where(Pizza => Pizza.Id == id)
                    .FirstOrDefault();

                if (PizzaDaAggiornare != null)
                {
                    PizzaDaAggiornare.ImagePizza = model.Pizze.ImagePizza;
                    PizzaDaAggiornare.NamePizza = model.Pizze.NamePizza;
                    PizzaDaAggiornare.DescriptionPizza = model.Pizze.DescriptionPizza;
                    PizzaDaAggiornare.PricePizza = model.Pizze.PricePizza;
                    PizzaDaAggiornare.CategoriaId = model.Pizze.CategoriaId;
                    DatabasePizza.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
                   
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            using (PizzaContext DatabasePizza = new PizzaContext())
            {
                Pizze PizzaDaCancellare = DatabasePizza.Pizzas
                   .Where(Pizze => Pizze.Id == id)
                   .First();

                if (PizzaDaCancellare != null)
                {
                    DatabasePizza.Pizzas.Remove(PizzaDaCancellare);
                    DatabasePizza.SaveChanges();

                    return RedirectToAction("Index");
                } else
                {
                    return NotFound();
                }
            }
        }
            [HttpGet]
            public IActionResult PaginaInformazioni()
            {
                return View("PaginaInformazioni");
            }
        
    }
}


 