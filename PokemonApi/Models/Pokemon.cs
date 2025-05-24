using PokemonApi.Dtos;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace PokemonApi.Models;

public class Pokemon
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Level { get; set; }
    public Stats Stats { get; set; }
    
    
    }