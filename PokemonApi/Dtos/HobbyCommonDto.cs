using System.Runtime.Serialization;
namespace PokemonApi.Dtos;

[DataContract(Name = "HobbyCommonDto", Namespace = "http://pokemon-api/hobbies-service")]
[KnownType(typeof(CreateHobbyDto))]
[KnownType(typeof(UpdateHobbyDto))]

public class HobbyCommonDto{
    

         [DataMember(Name = "Name", Order = 1)]
         public string Name { get; set; }
        
         [DataMember(Name = "Top", Order = 2)]
         public int Top { get; set; }

}

