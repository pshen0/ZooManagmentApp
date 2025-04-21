namespace ZooManagmentApp.Domain;

public class Enclosure
{
    public Guid Id { get; private set; }
    public string Type { get; private set; }
    public double Size { get; private set; }
    public int MaxCapacity { get; private set; }
    private List<Animal> animals;
    public IReadOnlyList<Animal> Animals => animals.AsReadOnly();
    public Enclosure(string type, double size, int maxCapacity)
    {
        Id = Guid.NewGuid();
        Type = type;
        Size = size;
        MaxCapacity = maxCapacity;
        animals = new List<Animal>();
    }
    public void AddAnimal(Animal animal)
    {
        if(animals.Count >= MaxCapacity)
            throw new Exception();
        animals.Add(animal);
        animal.AssignEnclosure(this);
    }
    public void RemoveAnimal(Animal animal)
    {
        animals.Remove(animal);
        if(animal.CurrentEnclosure == this)
            animal.AssignEnclosure(null);
    }
    public void Clean() { }
}