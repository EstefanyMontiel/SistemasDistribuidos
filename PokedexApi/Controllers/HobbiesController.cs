using Microsoft.AspNetCore.Mvc;
using PokedexApi.Dtos;
using PokedexApi.Services;
using PokedexApi.Mappers;


namespace PokedexApi.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class HobbiesController:ControllerBase
{
    private readonly IHobbyService _hobbyService;

        public HobbiesController(IHobbyService hobbyService)
        {
            _hobbyService = hobbyService;
        }

        // localhost/api/v1/hobbies/12
        [HttpGet("{id}")]
        public async Task<ActionResult<HobbiesResponse>> GetHobbyById(int id, CancellationToken cancellationToken)
        {
        var hobby = await _hobbyService.GetHobbyById(id, cancellationToken);
            if (hobby is null)
            {
                return NotFound();
            }
            return Ok(hobby.ToDto());
        }

        // localhost/api/v1/hobbies/byname/Chess
        //pokemons?name=pikach&variable2=343.....  query paremerters
        //Se deja solo para query parameters  -->Se usa FromQuery en el metodo gethobbiesbyname
        [HttpGet]
        public async Task<ActionResult<List<HobbiesResponse>>> GetHobbyByName([FromQuery]string name, CancellationToken cancellationToken)
        {
            var hobby = await _hobbyService.GetHobbyByName(name, cancellationToken);

            if (hobby == null || !hobby.Any())
            {
                return Ok(new List<HobbiesResponse>()); // Retornar lista vacía si no hay coincidencias
            }
            return Ok(hobby.Select(h => h.ToDto()).ToList());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHobbyById(int id, CancellationToken cancellationToken)
        {
            var result = await _hobbyService.DeleteHobbyByIdAsync(id, cancellationToken);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }