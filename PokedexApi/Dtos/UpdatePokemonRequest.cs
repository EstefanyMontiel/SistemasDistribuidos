using PokedexApi.Models;

namespace PokedexApi.Dtos
{
    public class UpdatePokemonRequest
    {
        public required string Name { get; set; }
        public  required string Type { get; set; }
        public int Level { get; set; }

        public Pokemon ToModel()
        {
            return new Pokemon
            {
                Name = this.Name,
                Type = this.Type,
                Level = this.Level
            };
        }
    }
}