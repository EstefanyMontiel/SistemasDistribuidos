using System.Runtime.Serialization;
using PokemonApi.Dtos;

namespace PokemonApi.Dtos; 

[DataContract(Name = "UpdatePokemonDto", Namespace = "http://pokemon-api/hobbies-service")]
        public class UpdatePokemonDto : PokemonCommonDto
{

        [DataMember(Name = "Id", Order = 1)]
        public Guid Id { get; set; }

}