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
        public IActionResult Get()
        {
           List<Pizze> pizzes = new List<Pizze>();

            using (PizzaContext DatabasePizza = new PizzaContext())
            {
                pizzes = DatabasePizza.Pizzas.ToList<Pizze>();
            }
            
            return Ok(pizzes);
        }
    }
}
