using PokedexApi.Models;

namespace PokedexApi.Repositories;

public interface ITrainerRepository
{
    Task<Trainer?> GetTrainerByIdAsync(string id, CancellationToken cancellationToken);

    IAsyncEnumerable<Trainer> GetAllByNamesAsync(string name, CancellationToken cancellationToken);
    
    Task<(int SuccessCount, List<Trainer> CreatedTrainers)> CreateTrainersAsync(List<Trainer> trainers, CancellationToken cancellationToken);
}
