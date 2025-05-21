using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using TrainerApi.Mappers;
using TrainerApi.Repositories;

namespace TrainerApi.Services;

public class TrainerService : TrainerApi.TrainerService.TrainerServiceBase
{
    private readonly ITrainerRepository _trainerRepository;
    public TrainerService(ITrainerRepository trainerRepository)
    {
        _trainerRepository = trainerRepository;
    }
    public override async Task<TrainerResponse> GetTrainer(TrainerByIdRequest request, ServerCallContext context)
    {
        var trainer = await _trainerRepository.GetByIdAsync(request.Id, context.CancellationToken);
        if (trainer is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"Trainer with id {request.Id} not found"));
        }
        return trainer.ToResponse();
    }
    public override async Task<CreateTrainersResponse> CreateTrainer(IAsyncStreamReader<CreateTrainerRequest> requestStream, ServerCallContext context) //IAsyncStreamReader genera un stream de peticiones
    {
        var createdTrainers = new List<TrainerResponse>();
        while (await requestStream.MoveNext(context.CancellationToken)) //.moveNext() se usa para avanzar al siguiente elemento del stream
        {
            var request = requestStream.Current; //trainer in progress
            var trainer = request.ToModel(); //trainer de tipo model
            var trainerExists = await _trainerRepository.GetByNameAsync(trainer.Name, context.CancellationToken);
            if (trainerExists.Any())
            {
                continue;
            }
            var createdTrainer = await _trainerRepository.CreateAsync(trainer, context.CancellationToken);
            createdTrainers.Add(createdTrainer.ToResponse());

        };
        return new CreateTrainersResponse
        {
            SuccessCount = createdTrainers.Count,
            Trainers = { createdTrainers }
        };
    }
}