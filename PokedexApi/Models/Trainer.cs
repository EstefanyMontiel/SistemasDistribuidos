namespace PokedexApi.Models;

public class Trainer
{
    public string Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public required IReadOnlyList<Medal> Medals { get; set; }
}

public class Medal
{
    public required string Region { get; set; }
    public required string Type { get; set; }
}