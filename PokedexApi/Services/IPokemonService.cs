using PokedexApi.Models; 
namespace PokedexApi.Services;

public interface IPokemonService
{
    Task<Pokemon?> GetPokemonById(Guid id, CancellationToken cancellationToken); //metódo
    Task<List<Pokemon>> GetPokemonByName(string name, CancellationToken cancellationToken);
    Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<Pokemon> CreatePokemonAsync(Pokemon pokemon, CancellationToken cancellationToken); 
    Task  UpdatePokemonAsync(Guid id, Pokemon pokemon, CancellationToken cancellationToken);
    
}