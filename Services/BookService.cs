using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Mappers;
using PokemonApi.Models;
using PokemonApi.Repositories;
namespace PokemonApi.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository; 
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookResponseDto> GetBookById(int id, CancellationToken cancellationToken){
        var book = await _bookRepository.GetBookByIdAsync(id, cancellationToken);
        if (book == null){
            throw new FaultException("Book not found");
        }
        return book.ToDto();      
    }

}
