using Microsoft.AspNetCore.Mvc;
using PokedexApi.Dtos;
using PokedexApi.Mappers;
using PokedexApi.Models;
using PokedexApi.Services;
using PokedexApi.Exceptions;


namespace PokedexApi.Controllers;


[ApiController]
[Route("api/v1/[controller]")]

public class TrainersController : ControllerBase
{
    private readonly ITrainerService _trainerService;

    public TrainersController(ITrainerService trainerService)
    {
        _trainerService = trainerService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TrainerResponseDto>> GetTrainerByIdAsync(string id, CancellationToken cancellationToken)
    {
        var trainer = await _trainerService.GetTrainerByIdAsync(id, cancellationToken);
        if (trainer is null)
        {
            return NotFound();
        }
        return Ok(trainer.ToDto());
    }


    //api/v1/trainers?name=Ash
    //retornar lista de entrenadores 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainerResponseDto>>> GetAllTrainersAsync([FromQuery] string name, CancellationToken cancellationToken)
    {
        try
        {
            var trainers = await _trainerService.GetAllByNamesAsync(name, cancellationToken);
            return Ok(trainers.ToDto());
        }
        catch (TrainerValidationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<TrainerResponseDto>>
    CreateTrainerAsync([FromBody] List<CreateTrainerRequestDto> request, CancellationToken cancellationToken)
    {
        var trainers = request.ToModel();

        var (createdTrainers, successCount) = await _trainerService.CreateTrainerAsync(trainers, cancellationToken);

        return Ok(new{SuccessCount = successCount, Trainers = createdTrainers});

    }




}


