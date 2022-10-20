using Domain.Generic;

namespace Domain;

public class Car : Entity
{
    public string Brand { get; private set; }
    public string Model { get; private set; }

    public List<Part> Parts { get; private set; }

    public Car(string brand, string model)
    {
        Brand = brand;
        Model = model;
        Parts = new List<Part>();
    }

    public void AddPart(string partName)
    {
        Parts.Add(new Part(partName, this));
    }
}