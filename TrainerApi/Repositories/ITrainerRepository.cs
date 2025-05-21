using TrainerApi.Models;

namespace TrainerApi.Repositories;

public interface ITrainerRepository
{
    Task<Trainer?> GetByIdAsync(string id, CancellationToken cancellationToken); //? significa que se acepta null
    Task<List<Trainer>> GetByNameAsync(string name, CancellationToken cancellationToken);
    Task<Trainer> CreateAsync(Trainer trainer, CancellationToken cancellationToken);
}