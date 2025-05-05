namespace PokemonApi.Dtos;

using System.Runtime.Serialization; 

[DataContract(Name = "CreateHobbyDto", Namespace = "http://pokemon-api/hobbies-service")]

public class CreateHobbyDto : HobbyCommonDto
{
}