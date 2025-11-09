using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Models;    
using PokemonApi.Mappers;

namespace PokemonApi.Repositories;


//inyeccion de dependencia
 public class HobbyRepository : IHobbyRepository 
{

    private readonly RelationalDbContext _context;

     public HobbyRepository(RelationalDbContext context)
    {
        _context = context; 

        }

     public async Task<Hobby> GetHobbyIdAsync(int id, CancellationToken cancellationToken)
    {
     var Hobby = await _context.Hobbies.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
     return Hobby.ToModel();
    }

     public async Task DeleteHobbyAsync(Hobby hobby, CancellationToken cancellationToken){
         _context.Hobbies.Remove(hobby.ToEntity());
        await _context.SaveChangesAsync(cancellationToken); 
    }

    public async Task <List<Hobby>> GetHobbiesByNamedAsync (string name, CancellationToken cancellationToken){
        var hobby = await _context.Hobbies.AsNoTracking().Where(s => s.Name.Contains(name)).ToListAsync(cancellationToken);
        return hobby.Select(s => s.ToModel()).ToList();

    }

public async Task AddAsync(Hobby hobby, CancellationToken cancellationToken)
    {
        await _context.Hobbies.AddAsync(hobby.ToEntity(), cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        }

    public async Task UpdateAsync(Hobby hobby, CancellationToken cancellationToken){
       _context.Hobbies.Update(hobby.ToEntity()); 
       await _context.SaveChangesAsync(cancellationToken);
    }
    
}
