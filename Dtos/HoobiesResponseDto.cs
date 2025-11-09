 using System.Runtime.Serialization;
 using Microsoft.AspNetCore.Authorization.Infrastructure;  //libreria para serializar 

 namespace PokemonApi.Dtos; 

 [DataContract(Name = "HobbiesResponseDto", Namespace = "http://pokemon-api/hobbies-service")]
 public class HobbiesResponseDto
 {

         [DataMember(Name = "Id", Order = 1)]
         public int Id { get; set; }
 
         [DataMember(Name = "Name", Order = 2)]
         public string Name { get; set; }
        
         [DataMember(Name = "Top", Order = 3)]
         public int Top { get; set; }

}