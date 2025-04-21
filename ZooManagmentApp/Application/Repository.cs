namespace ZooManagmentApp.Application;
using Domain;

public interface IAnimalRepository
{
    Animal GetById(Guid id);
    void Add(Animal animal);
    void Remove(Animal animal);
    IEnumerable<Animal> GetAll();
}

public interface IEnclosureRepository
{
    Enclosure GetById(Guid id);
    void Add(Enclosure enclosure);
    void Remove(Enclosure enclosure);
    IEnumerable<Enclosure> GetAll();
}

public interface IFeedingScheduleRepository
{
    FeedingSchedule GetById(Guid id);
    void Add(FeedingSchedule schedule);
    void Remove(FeedingSchedule schedule);
    IEnumerable<FeedingSchedule> GetAll();
}