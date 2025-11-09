
using System.Globalization;
using PokemonApi.Models;

namespace PokemonApi.Repositories;

    public interface IBookRepository
    {
    Task<Book> GetBookByIdAsync (int id,CancellationToken cancellationToken);
    
    }