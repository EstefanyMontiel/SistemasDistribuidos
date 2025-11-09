using System.ServiceModel; //Esto importa el namespace System.ServiceModel, que contiene atributos y clases para crear servicios WCF en C#.
using PokemonApi.Dtos;

namespace PokemonApi.Services;

   [ServiceContract(Name = "PokemonService", Namespace ="http://pokemon-api/pokemon-service")]/*Esto es un atributo de WCF que marca la interfaz como un contrato de servicio. Define cómo se expone el servicio a otros clientes.
   // Marca la interfaz como un contrato de servicio de WCF.*/
   public interface IPokemonService
   {
   [OperationContract] /*Marca el método como una operación de servicio en WCF.
   Define que este método estará disponible para llamadas remotas.*/
      Task<PokemonResponseDto> GetPokemonById(Guid id, CancellationToken cancellationToken); 

   [OperationContract]
      Task<List<PokemonResponseDto>> GetPokemonByName(string name, CancellationToken cancellationToken);

   [OperationContract]
      Task<bool> DeletePokemon(Guid id, CancellationToken cancellationToken);

   [OperationContract]
      Task<PokemonResponseDto> CreatePokemon(CreatePokemonDto createPokemon, CancellationToken cancellationToken);

   [OperationContract]
      Task<PokemonResponseDto> UpdatePokemon(UpdatePokemonDto pokemon, CancellationToken cancellationToken);
   }
   