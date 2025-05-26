using System.Runtime.Serialization;
using  PokedexApi.Infrastructure.Soap.Dtos;

namespace  PokedexApi.Infrastructure.Soap.Dtos;
[DataContract(Name ="UpdatePokemonDto", Namespace="http://pokemon-api/hobby-service")]

public class UpdateHobbyDto:HobbyCommon
{
      [DataMember(Name = "Id", Order = 3)]
        public int Id { get; set; }
}