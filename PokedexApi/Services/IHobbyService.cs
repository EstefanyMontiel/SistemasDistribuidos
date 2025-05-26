using PokedexApi.Models;
namespace PokedexApi.Services;

public interface IHobbyService
{
    Task<Hobby?> GetHobbyById (int id, CancellationToken cancellationToken);
    Task<List<Hobby>> GetHobbyByName (string name, CancellationToken cancellationToken);
    Task<bool> DeleteHobbyByIdAsync(int id, CancellationToken cancellationToken);
}
