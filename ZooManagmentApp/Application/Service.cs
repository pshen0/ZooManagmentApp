namespace ZooManagmentApp.Application;
using Domain;

public class AnimalTransferService
{
    public AnimalMovedEvent Transfer(Animal animal, Enclosure target)
    {
        return animal.TransferTo(target);
    }
}

public class FeedingOrganizationService
{
    private readonly IFeedingScheduleRepository scheduleRepository;
    public FeedingOrganizationService(IFeedingScheduleRepository repo)
    {
        scheduleRepository = repo;
    }
    public FeedingEvent FeedAnimal(Animal animal, DateTime feedingTime, string foodType)
    {
        var schedule = new FeedingSchedule(animal, feedingTime, foodType);
        scheduleRepository.Add(schedule);
        return schedule.MarkAsCompleted();
    }
}

public class ZooStatisticsService
{
    private readonly IAnimalRepository animalRepository;
    private readonly IEnclosureRepository enclosureRepository;
    public ZooStatisticsService(IAnimalRepository aRepo, IEnclosureRepository eRepo)
    {
        animalRepository = aRepo;
        enclosureRepository = eRepo;
    }
    public (int totalAnimals, int freeEnclosures) GetStatistics()
    {
        var animalsCount = animalRepository.GetAll().Count();
        var freeEnclosures = enclosureRepository.GetAll().Count(e => e.Animals.Count == 0);
        return (animalsCount, freeEnclosures);
    }
}