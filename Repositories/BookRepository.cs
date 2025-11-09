using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Models;    
using PokemonApi.Mappers;

namespace PokemonApi.Repositories;


//inyeccion de dependencia
public class BookRepository : IBookRepository 
{

    private readonly RelationalDbContext _context;

    public BookRepository(RelationalDbContext context)
    {
        _context = context; 

        }

    public async Task<Book> GetBookByIdAsync(int id, CancellationToken cancellationToken)
    {
    var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    return book.ToModel();
    }

   
}