using PokedexApi.Models;

namespace PokedexApi.Services;

public interface ITrainerService
{
    Task<Trainer?> GetTrainerByIdAsync(string id, CancellationToken cancellationToken);

    Task<IEnumerable<Trainer>> GetAllByNamesAsync(string name, CancellationToken cancellationToken);
}
