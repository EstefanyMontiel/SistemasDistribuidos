
using System.ServiceModel;
using PokedexApi.Models;
using PokedexApi.Mappers;
using PokedexApi.Infrastructure.Soap.Contracts;
namespace PokedexApi.Repositories;

public class HobbyRepository: IHobbyRepository

{
    private readonly ILogger<HobbyRepository> _logger;
    private readonly IHobbyService _hobbyService;

    public HobbyRepository(ILogger<HobbyRepository> logger, IConfiguration configuration)
    {
        _logger = logger;
        var endpoint = new EndpointAddress(configuration.GetValue<string>("HobbyServiceEndpoint"));
        var binding = new BasicHttpBinding();
        _hobbyService = new ChannelFactory<IHobbyService>(binding, endpoint).CreateChannel();
    }

public async Task<Hobby> GetHobbyByIdAsync(int id, CancellationToken cancellationToken)
{
    try
    {
        var hobby = await _hobbyService.GetHobbyById(id, cancellationToken);
        return hobby.ToModel();
    }
    catch (FaultException ex) when (ex.Message == "Hobby not found")
    {
        _logger.LogError(ex, "Failed to get hobby with id: {id}", id);
        return null;
    }
    }

    public async Task<List<Hobby>> GetHobbyByNameAsync(string name, CancellationToken cancellationToken)
    {
        try
        {
            var hobbies = await _hobbyService.GetHobbyByName(name, cancellationToken);
            return hobbies?.Select(h => h.ToModel()).ToList() ?? new List<Hobby>();
        }
        catch (FaultException ex) when (ex.Message.Contains("Hobbie not found"))
        {
            _logger.LogError(ex, "Failed to get hobbie with name: {name}", name);
            return new List<Hobby>();
        }
    }

    public async Task<bool> DeleteHobbyByIdAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            await _hobbyService.DeleteHobbyById(id, cancellationToken);
            return true;
        }
        catch (FaultException ex) when (ex.Message.Contains("Hobby not found"))
        {
            return false;
        }
        catch (FaultException ex)
    {
        _logger.LogError(ex, "Failed to delete hobbie with id: {id}", id);
        throw;
    }
    }
}