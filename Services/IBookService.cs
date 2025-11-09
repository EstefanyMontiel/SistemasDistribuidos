using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Models;

namespace PokemonApi.Services;

    [ServiceContract(Name = "BookService", Namespace ="http://pokemon-api/book-service")]

    public interface IBookService
    {
     
     [OperationContract]
     Task<BookResponseDto> GetBookById(int id, CancellationToken cancellationToken); //metodo que se va a exponer

    }
