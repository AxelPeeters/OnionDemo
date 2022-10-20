using Application.Cars.Commands;
using Application.Cars.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("cars")]
public class CarController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCars()
    {
        var result = await _mediator.Send(new GetCarsQuery());
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetCarById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetCarByIdQuery(id));
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCar([FromBody] AddCarCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}