using Microsoft.AspNetCore.Mvc;
using ZooManagmentApp
.Domain;
using ZooManagmentApp.Application;

namespace ZooManagmentApp.Presentation;

[ApiController]
[Route("api/enclosures")]
public class EnclosureViewController : ControllerBase
{
    private readonly IEnclosureRepository _enclosureRepository;

    public EnclosureViewController(IEnclosureRepository enclosureRepository)
    {
        _enclosureRepository = enclosureRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var enclosures = _enclosureRepository.GetAll();
        return Ok(enclosures);
    }

    [HttpPost]
    public IActionResult Add([FromBody] EnclosureDto dto)
    {
        var enclosure = new Enclosure(dto.Type, dto.Size, dto.MaxCapacity);
        _enclosureRepository.Add(enclosure);
        return Ok(enclosure);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var enclosure = _enclosureRepository.GetById(id);
        if (enclosure == null)
            return NotFound();

        _enclosureRepository.Remove(enclosure);
        return Ok();
    }
}

public class EnclosureDto
{
    public string Type { get; set; }
    public double Size { get; set; }
    public int MaxCapacity { get; set; }
}
