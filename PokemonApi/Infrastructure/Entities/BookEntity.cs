namespace PokemonApi.Infrastructure.Entities; 


    public class BookEntity
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate {get; set;}
    }
        
    