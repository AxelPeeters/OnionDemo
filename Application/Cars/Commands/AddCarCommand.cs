using Application.Cars.Persistence;
using Application.Persistence.Generic;
using Domain;
using MediatR;

namespace Application.Cars.Commands;

public class AddCarCommand : IRequest<Unit>
{
    public AddCarCommand(string brand, string model)
    {
        Brand = brand;
        Model = model;
    }

    public string Brand { get; }
    public string Model { get; }
}

public class AddCarCommandHandler : IRequestHandler<AddCarCommand, Unit>
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddCarCommandHandler(ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AddCarCommand request, CancellationToken cancellationToken)
    {
        await _carRepository.AddCar(new Car(request.Brand, request.Model));
        await _unitOfWork.Commit();
        return Unit.Value;
    }
}