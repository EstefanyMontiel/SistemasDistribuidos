using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Mappers;
using PokemonApi.Models;
using PokemonApi.Repositories;
using PokemonApi.Validators;
namespace PokemonApi.Services;

 public class HobbyService : IHobbyService
{
      private readonly IHobbyRepository _hobbyRepository; 
      public HobbyService(IHobbyRepository hobbyRepository)
    {
         _hobbyRepository = hobbyRepository;
    }

      public async Task<HobbiesResponseDto> GetHobbyById(int id, CancellationToken cancellationToken){
         var hobby = await _hobbyRepository.GetHobbyIdAsync(id, cancellationToken);
         if (hobby == null){
             throw new FaultException("hobby not found");
        }
         return hobby.ToDto();      
    }

     public async Task<bool> DeleteHobby(int id, CancellationToken cancellationToken){
         var hobby = await _hobbyRepository.GetHobbyIdAsync(id, cancellationToken);
         if(hobby is null){
             throw new FaultException("Hobby not found");
        }
         await _hobbyRepository.DeleteHobbyAsync(hobby, cancellationToken);
         return true;
    }

     public async Task<List<HobbiesResponseDto>> GetHobbiesByName(string name, CancellationToken cancellationToken){
         var hobbies = await _hobbyRepository.GetHobbiesByNamedAsync(name, cancellationToken);
 
         if (hobbies == null || !hobbies.Any())
        {
             return new List<HobbiesResponseDto>();
        }
         return hobbies.Select(s => s.ToDto()).ToList();
    }


public async Task<HobbiesResponseDto> CreateHobby(CreateHobbyDto createHobbyDto, CancellationToken cancellationToken){
        var  hobbyToCreate = createHobbyDto.ToModel();

        hobbyToCreate.ValidateName().ValidateTop();


        await _hobbyRepository.AddAsync(hobbyToCreate, cancellationToken);
        return hobbyToCreate.ToDto();
    }
    
    public async  Task<HobbiesResponseDto> UpdateHobby (UpdateHobbyDto hobby, CancellationToken cancellationToken){
        var hobbyToUpdate = await _hobbyRepository.GetHobbyIdAsync(hobby.Id, cancellationToken);
         if (hobbyToUpdate is null){
            throw new FaultException("Hobby  not found");
        }

        hobbyToUpdate.Name = hobby.Name;
        hobbyToUpdate.Top = hobby.Top;

        await _hobbyRepository.UpdateAsync(hobbyToUpdate, cancellationToken);
        return hobbyToUpdate.ToDto();
    }

    
}