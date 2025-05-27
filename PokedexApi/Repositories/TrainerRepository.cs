using System.ComponentModel;
using Grpc.Core;
using PokedexApi.Mappers;
using PokedexApi.Models;
using TrainerApi;

namespace PokedexApi.Repositories;

public class TrainerRepository : ITrainerRepository
{
    private readonly TrainerService.TrainerServiceClient _client;

    public TrainerRepository(TrainerService.TrainerServiceClient client)
    {
        _client = client;
    }

    public async Task<Trainer?> GetTrainerByIdAsync(string id, CancellationToken cancellationToken)
    {
        try
        {
            var trainer = await _client.GetTrainerAsync(new TrainerByIdRequest { Id = id }, cancellationToken: cancellationToken);

            return trainer.ToModel();
        }
        catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
        {
            return null;
        }
    }


    public async IAsyncEnumerable<Trainer> GetAllByNamesAsync(string name, CancellationToken cancellationToken)
    {


        var request = new GetTrainersByNameRequest { Name = name };
        using var call = _client.GetTrainersByName(request, cancellationToken: cancellationToken);
        while (await call.ResponseStream.MoveNext(cancellationToken))
        {
            yield return call.ResponseStream.Current.ToModel();
        }
    }
    
    }