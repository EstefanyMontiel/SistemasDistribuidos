using Microsoft.AspNetCore.Mvc;
using PokedexApi.Services;
using PokedexApi.Dtos;
using PokedexApi.Mappers;
using PokedexApi.Infrastructure.Soap.Dtos;
using System.ServiceModel.Channels;
using PokedexApi.Models;
using PokedexApi.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace PokedexApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PokemonsController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonsController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    //localhost/api/v1/pokemons/idpokemon 1233434353
    [HttpGet("{id}")]
    [Authorize(Policy = "Read")]


    public async Task<ActionResult<PokemonResponse>> GetPokemonById(Guid id, CancellationToken cancellationToken)
    {
        var pokemon = await _pokemonService.GetPokemonById(id, cancellationToken);
        if (pokemon == null)
        {
            return NotFound();
        }
        return Ok(pokemon.ToDto());
    }

    //localhost/api/v1/pokemons/byname/Pikachu
    [HttpGet]
    public async Task<ActionResult<List<PokemonResponse>>> GetPokemonByName([FromQuery] string name, CancellationToken cancellationToken)
    {
        var pokemons = await _pokemonService.GetPokemonByName(name, cancellationToken);

        if (pokemons == null || !pokemons.Any())
        {
            return Ok(new List<PokemonResponse>()); // Mejor devolver lista vacía en lugar de 404
        }
        return Ok(pokemons.Select(p => p.ToDto()).ToList());
    }
    //404 -not found
    //204 -No content(se encontro y elimino el pokemon) de forma correcta pero el body de respuesta esta vacia
    //200 -OK se encontró y se elimino el pokemon y en el body de respuesta se envia un msj de exito
    //201 Información 

    [HttpDelete("{id}")]
    [Authorize(Policy = "Write")]

    public async Task<ActionResult> DeletePokemonById(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _pokemonService.DeletePokemonByIdAsync(id, cancellationToken);

        if (deleted)
        {
            return NoContent();
        }

        return NotFound();

    }

    [HttpPost]

    public async Task<ActionResult<PokemonResponse>> CreatePokemon([FromBody] CreatePokemonRequest pokemon, CancellationToken cancellationToken)
    {
        try
        {


            var createdPokemon = await _pokemonService.CreatePokemonAsync(pokemon.ToModel(), cancellationToken);

            return CreatedAtAction(nameof(GetPokemonById), new { id = createdPokemon.Id }, createdPokemon.ToDto());

        }
        catch (PokemonValidationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (PokemonAlreadyExistsException ex)
        {
            return Conflict(new { message = $"Pokemon' {ex.PokemonName}'already exists", exception = ex.Message });
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePokemon(Guid id, [FromBody] UpdatePokemonRequest pokemon, CancellationToken cancellationToken)
    {
        try
        {
            await _pokemonService.UpdatePokemonAsync(id, pokemon.ToModel(), cancellationToken);
            return NoContent();
        }
        catch (NameValidationException)
        {
            return Conflict(new {message=$"Pokemon alredy exists with the name:",pokemon.Name});
        }
        catch (PokemonValidationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (PokemonNotFoundException)
        {
            return NotFound();
        }
    }
}






