using Microsoft.AspNetCore.Mvc;
using ZooManagmentApp.Domain;
using ZooManagmentApp.Application;
namespace ZooManagmentApp.Presentation;


[ApiController]
[Route("api/feedings")]
public class FeedingScheduleViewController : ControllerBase
{
    private readonly IFeedingScheduleRepository _scheduleRepository;

    public FeedingScheduleViewController(IFeedingScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var schedules = _scheduleRepository.GetAll();
        return Ok(schedules);
    }

    [HttpPost]
    public IActionResult Add([FromBody] FeedingScheduleDto dto)
    {
        var animal = new Animal(dto.AnimalSpecies, dto.AnimalName, dto.AnimalBirthDate, dto.AnimalGender, dto.AnimalFavoriteFood);
        var schedule = new FeedingSchedule(animal, dto.FeedingTime, dto.FoodType);
        _scheduleRepository.Add(schedule);
        return Ok(schedule);
    }
}

public class FeedingScheduleDto
{
    public string AnimalSpecies { get; set; }
    public string AnimalName { get; set; }
    public DateTime AnimalBirthDate { get; set; }
    public Gender AnimalGender { get; set; }
    public string AnimalFavoriteFood { get; set; }
    public DateTime FeedingTime { get; set; }
    public string FoodType { get; set; }
}