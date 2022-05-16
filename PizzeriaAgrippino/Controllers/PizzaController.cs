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
                // adesso creiamo un nuovo sistema per trovare le pizze 
                Pizze TrovaPizza = DatabasePizza.Pizzas
                .Where(Pizze => Pizze.Id == id)
                .First();

                //Se trovo una pizza con lo stesso id, dico che TDP è uguale a pizze e poi eseguo un break per uscire.
                if (TrovaPizza != null)
                {
                    return View("Dettagli", TrovaPizza);
                } else
                {
                    return NotFound("Il post con id" + id + " non è stato trovato");
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
            return View("FormPizza");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //creiamo poi un metodo chiamato creaPizza per acciugnere le pizze, aggiugnere il modello 
        public IActionResult CreaPizza(Pizze NuovaPizza)
        {
            //se il modello non  è valido ritorniamo una view
            if (!ModelState.IsValid)
            {
                return View("FormPizza", NuovaPizza);

            }
            //utilizzando sempre il metodo con i Db, er creare una pizza richiamiamo un costruttore, poi aggiugniamo e salviamo nel db 
            using (PizzaContext DatabasePizza = new PizzaContext())
            {
                Pizze NuovaPizzaDaInserire = new Pizze(NuovaPizza.ImagePizza, NuovaPizza.NamePizza, NuovaPizza.DescriptionPizza, NuovaPizza.PricePizza);
                DatabasePizza.Pizzas.Add(NuovaPizzaDaInserire);
                DatabasePizza.SaveChanges();
            }
            return RedirectToAction("Index");

            //Dato che non abbiamo un database dobbiamo inserire noi una nuovo oggetto che ha tutti gli aytributi della pizza 
            //andiamo poi a richiamare tutto con il return redtoact e puntiamo alla nostra Homepage
            //Se il modello è corretto prendiamo la lista postdata e il metodo get che aggiugnerà questo post alla lista
        }



        [HttpGet]
        public IActionResult Modifica(int id)
        {
            Pizze ModificaPizza = null;

            using (PizzaContext DatabasePizza = new PizzaContext())
            {

                ModificaPizza = DatabasePizza.Pizzas
                 .Where(Pizze => Pizze.Id == id)
                 .First();
            }
            if (ModificaPizza == null)
            {
                return NotFound();
            }
            else
            {
                return View("AggiornaPizze", ModificaPizza);
            }
        }

        [HttpPost]
        public IActionResult Modifica(int id, Pizze MandaPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("AggiornaPizze", MandaPizza);
            }

            Pizze ? ModificaPizza = null;

            using (PizzaContext DatabasePizza = new PizzaContext())
            {
                ModificaPizza = DatabasePizza.Pizzas
               .Where(Pizze => Pizze.Id == id)
               .FirstOrDefault();

                if (ModificaPizza != null)
                {
                    ModificaPizza.ImagePizza = MandaPizza.ImagePizza;
                    ModificaPizza.NamePizza = MandaPizza.NamePizza;
                    ModificaPizza.DescriptionPizza = MandaPizza.DescriptionPizza;
                    ModificaPizza.PricePizza = MandaPizza.PricePizza;
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


 