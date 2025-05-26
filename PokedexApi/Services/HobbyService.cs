  using PokedexApi.Models;
  using PokedexApi.Repositories;

   namespace PokedexApi.Services;
   public class HobbyService : IHobbyService
   {
     private readonly IHobbyRepository _hobbyRepository;

     public HobbyService(IHobbyRepository hobbyRepository)
     {
       _hobbyRepository = hobbyRepository;
     }

     public async Task<Hobby?> GetHobbyById(int id, CancellationToken cancellationToken)
     {
       return await _hobbyRepository.GetHobbyByIdAsync(id, cancellationToken);
     }

     public async Task<List<Hobby>> GetHobbyByName(string name, CancellationToken cancellationToken)
     {
       var response = await _hobbyRepository.GetHobbyByNameAsync(name, cancellationToken);
       return response?.ToList() ?? new List<Hobby>();
     }

     public async     Task<bool> DeleteHobbyByIdAsync(int id, CancellationToken cancellationToken){
       return await _hobbyRepository.DeleteHobbyByIdAsync(id, cancellationToken);
     }
     

}
