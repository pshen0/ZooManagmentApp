namespace ZooManagmentApp.Domain;

public enum Gender { Male, Female }
public enum HealthStatus { Healthy, Sick }
public class Animal
{
    public Guid Id { get; private set; }
    public string Species { get; private set; }
    public string Name { get; private set; }
    public DateTime BirthDay { get; private set; }
    public Gender Gender { get; private set; }
    public string FavoriteFood { get; private set; }
    public HealthStatus HealthStatus { get; private set; }
    public Enclosure CurrentEnclosure { get; private set; }
    public Animal(string species, string name, DateTime birthDay, Gender gender, string favoriteFood)
    {
        Id = Guid.NewGuid();
        Species = species;
        Name = name;
        BirthDay = birthDay;
        Gender = gender;
        FavoriteFood = favoriteFood;
        HealthStatus = HealthStatus.Healthy;
    }
    public void Feed() { }
    public void Heal()
    {
        HealthStatus = HealthStatus.Healthy;
    }
    public void AssignEnclosure(Enclosure enclosure)
    {
        CurrentEnclosure = enclosure;
    }
    public AnimalMovedEvent TransferTo(Enclosure target)
    {
        var source = CurrentEnclosure;
        CurrentEnclosure?.RemoveAnimal(this);
        target.AddAnimal(this);
        CurrentEnclosure = target;
        return new AnimalMovedEvent(this, source, target);
    }
}