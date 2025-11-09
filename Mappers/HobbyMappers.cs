using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;

namespace PokemonApi.Mappers;

 public static class HobbyMappers{

     public static HobbyEntity ToEntity(this Hobby hobby){
         return new HobbyEntity{
             Id = hobby.Id,
             Name = hobby.Name,
             Top = hobby.Top
        };
    }

    public static Hobby ToModel(this HobbyEntity entity){
     if(entity is null) {
        return null;
    }

    return new Hobby
    {
        Id = entity.Id,
        Name = entity.Name,
        Top = entity.Top
    
     
   };
}
    public static HobbiesResponseDto ToDto(this Hobby hobby){
    
            return new HobbiesResponseDto
       {
            Id = hobby.Id,
            Name = hobby.Name,
            Top = hobby.Top
         
       };
   }


   
   public static Hobby ToModel (this CreateHobbyDto hobby){
    return new Hobby {
        
            Name = hobby.Name,
            Top = hobby.Top
    };
   }
   
}
