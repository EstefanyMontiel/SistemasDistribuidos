
using System.Runtime.Serialization;
using  PokedexApi.Infrastructure.Soap.Dtos;
namespace  PokedexApi.Infrastructure.Soap.Dtos;
[DataContract(Name ="HobbyCommon", Namespace="http://pokemon-api/hobby-service")]
[KnownType(typeof(CreateHobbyDto))]
[KnownType(typeof(UpdateHobbyDto))]

public class HobbyCommon
{
      [DataMember(Name = "Name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "Top", Order = 2)]
        public int Top { get; set; }
}