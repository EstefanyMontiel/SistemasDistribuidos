using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Models;

namespace PokemonApi.Services;

      [ServiceContract(Name = "EstefanyMontielService", Namespace ="http://pokemon-api/hobbies-service")]

      public interface IHobbyService
     {
     
      [OperationContract]
       Task<HobbiesResponseDto> GetHobbyById(int id, CancellationToken cancellationToken); //metodo que se va a exponer
     
     [OperationContract]
      Task<bool> DeleteHobby(int id, CancellationToken cancellationToken);

    
     [OperationContract]
       Task<List<HobbiesResponseDto>> GetHobbiesByName(string name, CancellationToken cancellationToken);


      [OperationContract]
      Task<HobbiesResponseDto> CreateHobby(CreateHobbyDto createHobbyDto, CancellationToken cancellationToken);

     [OperationContract]
      Task<HobbiesResponseDto> UpdateHobby(UpdateHobbyDto updateHobbyDto, CancellationToken cancellationToken);

     }
     