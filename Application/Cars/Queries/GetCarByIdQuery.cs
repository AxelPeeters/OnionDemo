using Application.Cars.Persistence;
using Domain;
using MediatR;

namespace Application.Cars.Queries;

public class GetCarByIdQuery : IRequest<Car>
{
    public GetCarByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}

public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, Car>
{
    private readonly ICarRepository _carRepository;

    public GetCarByIdQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<Car> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        return await _carRepository.GetCarById(request.Id);
    }
}