using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaAgrippino.Data;
using PizzeriaAgrippino.Models;

namespace PizzeriaAgrippino.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        [HttpPost]

        public IActionResult AddToFavourite(int id)
        {  
            List<Pizze> MyFavouritePizza = new List<Pizze>();

            using (PizzaContext DatabasePizza = new PizzaContext())
                {
                    Pizze AddFavourtie = DatabasePizza.Pizzas
                       .Where(Pizze => Pizze.Id == id)
                       .First();

                    if (AddFavourtie != null)
                    {
                        MyFavouritePizza.Add(AddFavourtie);
                        
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            

        }
    }
}
