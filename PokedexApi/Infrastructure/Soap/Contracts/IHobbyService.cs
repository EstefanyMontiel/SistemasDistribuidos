using System.ServiceModel;
using  PokedexApi.Infrastructure.Soap.Dtos;

namespace PokedexApi.Infrastructure.Soap.Contracts;

[ServiceContract(Name ="EstefanyMontielService",Namespace ="http://pokemon-api/hobby-service")]
public interface IHobbyService
{
        [OperationContract ]
        Task<HobbiesResponseDto> GetHobbyById(int id,CancellationToken cancellationToken);

        [OperationContract ]
        Task<bool> DeleteHobbyById(int id, CancellationToken cancellationToken);

        [OperationContract]
         Task<List<HobbiesResponseDto>> GetHobbyByName(string name,CancellationToken cancellationToken);

        [OperationContract]
        Task<HobbiesResponseDto> CreateHobby(CreateHobbyDto createHobbyDto,CancellationToken cancellationToken);

        [OperationContract]
        Task<HobbiesResponseDto> UpdateHobby(UpdateHobbyDto hobby,CancellationToken cancellationToken);
}