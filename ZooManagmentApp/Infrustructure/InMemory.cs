namespace ZooManagmentApp.Infrastructure;
using Application;
using Domain;

public class InMemoryAnimalRepository : IAnimalRepository
{
    private readonly List<Animal> animals = new List<Animal>();
    public Animal GetById(Guid id) => animals.FirstOrDefault(a => a.Id == id);
    public void Add(Animal animal) => animals.Add(animal);
    public void Remove(Animal animal) => animals.Remove(animal);
    public IEnumerable<Animal> GetAll() => animals;
}

public class InMemoryEnclosureRepository : IEnclosureRepository
{
    private readonly List<Enclosure> enclosures = new List<Enclosure>();
    public Enclosure GetById(Guid id) => enclosures.FirstOrDefault(e => e.Id == id);
    public void Add(Enclosure enclosure) => enclosures.Add(enclosure);
    public void Remove(Enclosure enclosure) => enclosures.Remove(enclosure);
    public IEnumerable<Enclosure> GetAll() => enclosures;
}

public class InMemoryFeedingScheduleRepository : IFeedingScheduleRepository
{
    private readonly List<FeedingSchedule> schedules = new List<FeedingSchedule>();
    public FeedingSchedule GetById(Guid id) => schedules.FirstOrDefault(s => s.Id == id);
    public void Add(FeedingSchedule schedule) => schedules.Add(schedule);
    public void Remove(FeedingSchedule schedule) => schedules.Remove(schedule);
    public IEnumerable<FeedingSchedule> GetAll() => schedules;
}