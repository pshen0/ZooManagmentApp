using Microsoft.AspNetCore.Mvc;
using ZooManagmentApp.Domain;
using ZooManagmentApp.Application;

namespace ZooManagmentApp.Presentation;

[ApiController]
[Route("api/animals")]
public class AnimalsViewController : ControllerBase
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalsViewController(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var animals = _animalRepository.GetAll();
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult Add([FromBody] AnimalDto dto)
    {
        var animal = new Animal(dto.Species, dto.Name, dto.BirthDate, dto.Gender, dto.FavoriteFood);
        _animalRepository.Add(animal);
        return Ok(animal);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var animal = _animalRepository.GetById(id);
        if (animal == null)
            return NotFound();

        _animalRepository.Remove(animal);
        return Ok();
    }
}

public class AnimalDto
{
    public string Species { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string FavoriteFood { get; set; }
}
