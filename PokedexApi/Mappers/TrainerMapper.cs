using PokedexApi.Dtos;
using PokedexApi.Models;
using TrainerApi;

namespace PokedexApi.Mappers;

public static class TrainerMappers
{
    public static TrainerResponseDto ToDto(this Trainer trainer)
    {
        return new TrainerResponseDto
        {
            Id = trainer.Id,
            Name = trainer.Name,
            Age = trainer.Age,
            BirthDate = trainer.BirthDate,
            CreatedAt = trainer.CreatedAt,
            Medals = trainer.Medals.Select(s => new MedalDto
            {
                Region = s.Region,
                Type = s.Type
            }).ToList()
        };
    }

    public static Trainer ToModel(this TrainerResponse trainer)
    {
        return new Trainer
        {
            Id = trainer.Id,
            Name = trainer.Name,
            Age = trainer.Age,
            BirthDate = trainer.Birthdate.ToDateTime(),
            CreatedAt = trainer.CreatedAt.ToDateTime(),
            Medals = trainer.Medals.Select(s => new Medal
            {
                Region = s.Region,
                Type = s.Type.ToString()
            }).ToList()
        };
    }

    public static IEnumerable<TrainerResponseDto> ToDto(this IEnumerable<Trainer> trainers)
    {
        return trainers.Select(s => s.ToDto());
    }


    public static List<Trainer> ToModel(this List<CreateTrainerRequestDto> request)
    {
        return request.Select(s => new Trainer
        {
            Name = s.Name,
            Age = s.Age,
            BirthDate = s.BirthDate,
            Medals = s.Medals.Select(m => new Medal
            {
                Region = m.Region,
                Type = m.Type.ToString()
            }).ToList()
        }).ToList();
    }
    


    public static List<Trainer> ToModel(this Google.Protobuf.Collections.RepeatedField<TrainerResponse> trainers)
    {
        return trainers.Select(s => s.ToModel()).ToList();
    }
}