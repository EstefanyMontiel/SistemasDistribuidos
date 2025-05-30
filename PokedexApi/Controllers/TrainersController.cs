using Microsoft.AspNetCore.Mvc;
using PokedexApi.Dtos;
using PokedexApi.Mappers;
using PokedexApi.Models;
using PokedexApi.Services;
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
}