using Domain.Generic;

namespace Domain;

public class Part : Entity
{
    public string Partnumber { get; }
    public Car Car { get; }

    public Part(string partnumber, Car car)
    {
        Partnumber = partnumber;
        Car = car;
    }

    public Part()
    {
    }
}