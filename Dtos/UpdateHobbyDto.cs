using System.Runtime.Serialization;
namespace PokemonApi.Dtos; 

 [DataContract(Name = "UpdateHobbyDto", Namespace = "http://pokemon-api/hobbies-service")]
 public class UpdateHobbyDto : HobbyCommonDto
 {

         [DataMember(Name = "Id", Order = 3)]
         public int Id { get; set; }
 

}