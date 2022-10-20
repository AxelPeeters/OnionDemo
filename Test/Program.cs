// See https://aka.ms/new-console-template for more information

using Domain;
using Persistence;

var context = new ApplicationDbContext();
context.Database.EnsureCreated();

context.Cars.Add(new Car
{
    Id = 1,
    Brand = "Merry",
    Model = "test"
});

context.SaveChanges();