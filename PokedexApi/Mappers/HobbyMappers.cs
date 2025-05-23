using PokedexApi.Dtos;
using PokedexApi.Models;
using PokedexApi.Infrastructure.Soap.Dtos;

namespace PokedexApi.Mappers;

public static class HobbyMapper
{
public static HobbiesResponse ToDto(this Hobby hobby){
return new HobbiesResponse{
    Id=hobby.Id,
    Name=hobby.Name,
    Top=hobby.Top
};
}
 

public static Hobby ToModel(this HobbiesResponseDto hobby){
return new Hobby{
    Id=hobby.Id,
    Name=hobby.Name,
    Top=hobby.Top
};

}

}

