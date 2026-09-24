using GamebudsAPI.Models;
using GamebudsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamebudsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    [HttpGet(Name = "GetPizzas")]
    public IEnumerable<Pizza> GetPizzas()
    {
        return PizzaService.GetAll();
    }

    [HttpGet("{id}", Name = "GetPizza")]
    public Pizza? GetPizza(int id)
    {
        return PizzaService.Get(id);
    }

    [HttpPost(Name = "AddPizza")]
    public IActionResult AddPizza([FromBody] Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(GetPizza), new { id = pizza.Id }, pizza);
    }
    [HttpPut("{id}", Name = "UpdatePizza")]
    public IActionResult UpdatePizza(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();
                
        var existingPizza = PizzaService.Get(id);
        if(existingPizza is null)
            return NotFound();

        PizzaService.Update(pizza);           

        return NoContent();
    }
    
    [HttpDelete("{id}", Name = "DeletePizza")]
    public IActionResult DeletePizza(int id)
    {
        var pizza = PizzaService.Get(id);
    
        if (pizza is null)
            return NotFound();
        
        PizzaService.Delete(id);
    
        return NoContent();
    }
}
