using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaAgrippino.Data;
using PizzeriaAgrippino.Models;

namespace PizzeriaAgrippino.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Pizzerias : ControllerBase
    {
        [HttpGet]
        
        public IActionResult Get(string? search)
        {
            // questo controller vede se ci sono corrispondenze per con il titolo o la descrizione
            //se la ricerca è diversa da null e non è vuota, cerca la pizza, altrimenti stampa tutta la lista di pizze.
            List<Pizze> pizzes = new List<Pizze>();
            using (PizzaContext DatabasePizza = new PizzaContext())
                if (search != null && search != "")
                {
                    pizzes = DatabasePizza.Pizzas.Where(pizzes => pizzes.NamePizza.Contains(search) || pizzes.DescriptionPizza.Contains(search)).ToList<Pizze>();
                }
                else
                {
                    pizzes = DatabasePizza.Pizzas.ToList<Pizze>();
                }
        
                return Ok(pizzes);
        }     
    }
 }

