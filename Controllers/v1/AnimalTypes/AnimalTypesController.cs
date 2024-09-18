using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Farm.Data;
using API_Farm.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace API_Farm.Controllers.v1.AnimalTypes;

[ApiController]
[Route("api/v1/[controller]")]
public class AnimalTypesController : ControllerBase
{
    private readonly ApplicationDbContext Context;

    public AnimalTypesController(ApplicationDbContext context)
    {
        Context = context;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieves all animal types",
        Description = "Gets a list of all animal types in the database"
    )]
    [SwaggerResponse(200, "Returns a list of animal types.", typeof(IEnumerable<AnimalType>))]
    [SwaggerResponse(204, "There are no animals with that description.")]
    public async Task<IActionResult> GetAll(){
        var animalTypes = await Context.AnimalTypes.ToListAsync();
        
        if(animalTypes.Count() == 0)
        {
            return NoContent();
        }
        return Ok(animalTypes);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody]AnimalType newAnimalType){
        if(ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }
        Context.AnimalTypes.Add(newAnimalType);
        await Context.SaveChangesAsync();
        return Ok("The animal type was created");
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var AnimalType = await Context.AnimalTypes.Where(animalTypes => animalTypes.Id ==id).ToListAsync();
        if(AnimalType == null)
        {
            return NoContent();
        }
        return Ok(AnimalType);
    }


    [HttpGet("search/{Keyword}")]
    public async Task<IActionResult> SearchByKeyword([FromRoute] string Keyword)
    {
        var animalTypes = await Context.AnimalTypes.Where(p => p.Name.Contains(Keyword)).ToListAsync();
        if(animalTypes.Count() == 0)
        {
            NoContent();
        }
        return Ok(animalTypes);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AnimalType updatedAnimalType)
    {
        var animalType = checkExistence(id);
        if(animalType == false)
        {
            return NoContent();
        }
        updatedAnimalType.Id = id;
        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }
        Context.Entry(updatedAnimalType).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return Ok("updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var animalType = checkExistence(id);
        if (animalType == false)
        {
            return NoContent();
        }
        var animalTypeUbication  = await Context.AnimalTypes.FirstOrDefaultAsync(at => at.Id ==id);
        Context.AnimalTypes.Remove(animalTypeUbication);
        await Context.SaveChangesAsync();
        return Ok("deleted");
    }


    private bool checkExistence(int id)
    {
        return Context.AnimalTypes.Any(p=> p.Id == id);
    }
}


