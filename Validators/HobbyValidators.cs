using System.ServiceModel;
using PokemonApi.Models;

namespace PokemonApi.Validators;

public static class HobbyValidator {
    public static Hobby ValidateName(this Hobby hobby)=>
    string.IsNullOrEmpty(hobby.Name)?
    throw new FaultException("Hobby name is requerided"): hobby; 

     
     public static Hobby ValidateTop (this Hobby hobby)=>
    hobby.Top <= 0 ? throw new FaultException("Hobby level is requerided"): hobby; 
     
}