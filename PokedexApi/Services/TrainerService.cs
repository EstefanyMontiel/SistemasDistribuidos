using Grpc.Core;
using PokedexApi.Models;
using PokedexApi.Repositories;
using PokedexApi.Exceptions;

namespace PokedexApi.Services;

public class TrainerService : ITrainerService
{
    private readonly ITrainerRepository _trainerRepository;

    public TrainerService(ITrainerRepository trainerRepository)
    {
        _trainerRepository = trainerRepository;
    }

    public async Task<Trainer?> GetTrainerByIdAsync(string id, CancellationToken cancellationToken)
    {
        return await _trainerRepository.GetTrainerByIdAsync(id, cancellationToken);
    }

    //
    public async Task<IEnumerable<Trainer>> GetAllByNamesAsync(string name, CancellationToken cancellationToken)
    {
        //Se envian todos los entrenadores
        var trainers = new List<Trainer>();


        try
        {
            await foreach (var trainer in _trainerRepository.GetAllByNamesAsync(name, cancellationToken))
            {
                trainers.Add(trainer);
            }
        }
        catch (RpcException ex) when (ex.StatusCode == StatusCode.InvalidArgument)
        {
            throw new TrainerValidationException("Se requiren al menos dos caracteres.");
        }
        return trainers;
    }

    public async Task<(int SuccessCount, List<Trainer> CreatedTrainers)>
    CreateTrainerAsync(List<Trainer> trainers, CancellationToken cancellationToken)
    {
        return await _trainerRepository.CreateTrainersAsync(trainers, cancellationToken);
    }


}