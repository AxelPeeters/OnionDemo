using Application.Cars.Persistence;
using Domain;
using MediatR;

namespace Application.Cars.Queries;

public class GetCarsQuery : IRequest<List<Car>>
{
    
}

public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, List<Car>>
{
    private readonly ICarRepository _carRepository;

    public GetCarsQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<List<Car>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
    {
        return await _carRepository.GetCars();
    }
}