using System.Runtime.Serialization;
using  PokedexApi.Infrastructure.Soap.Dtos;

namespace  PokedexApi.Infrastructure.Soap.Dtos;
[DataContract(Name ="CreateHobbyDto", Namespace="http://pokemon-api/hobby-service")]

public class CreateHobbyDto : HobbyCommon
{
    
}