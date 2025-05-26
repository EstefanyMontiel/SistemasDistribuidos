namespace PokedexApi.Dtos;

public class TrainerResponseDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public required IReadOnlyList<MedalDto> Medals { get; set; }
}

public class MedalDto
{
    public required string Region { get; set; }
    public required string Type { get; set; }
}