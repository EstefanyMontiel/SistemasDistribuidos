using System.Drawing.Printing;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;

//ENTIDAD CREADA 
namespace PokemonApi.Infrastructure
{
    public class RelationalDbContext : DbContext
    {

        public  DbSet<PokemonEntity> Pokemons { get; set; } //DbSet es una coleccion de entidades que se mapean a una tabla en la base de datos
        public  DbSet<HobbyEntity> Hobbies { get; set; } //DbSet es una coleccion de entidades que se mapean a una tabla en la base de datos
        public  DbSet<BookEntity> Books { get; set; } 

        public RelationalDbContext(DbContextOptions<RelationalDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonEntity>(entity=>{

                entity.HasKey(s=>s.Id); //Llave primaria
                entity.Property(s=>s.Name).IsRequired().HasMaxLength(100); //Nombre es requerido
                entity.Property(s=>s.Type).IsRequired().HasMaxLength(50); //Tipo es requerido
                entity.Property(s=>s.Level).IsRequired(); //Nivel es requerido
                entity.Property(s=>s.Attack).IsRequired(); //Ataque es requerido
                entity.Property(s=>s.Defense).IsRequired(); //Defensa es requerido
                entity.Property(s=>s.Speed).IsRequired(); //Velocidad es requerido
            }); 
            
            modelBuilder.Entity<HobbyEntity>(entity=>{

                entity.HasKey(b=>b.Id); //Llave primaria
                entity.Property(b=>b.Name).IsRequired().HasMaxLength(100); //Nombre es requerido
                entity.Property(b=>b.Top).IsRequired(); //Top es requerido
            }); 


            modelBuilder.Entity<BookEntity>(entity=>{
                entity.HasKey(a=>a.Id); //Llave primaria
                entity.Property(a=>a.Title).IsRequired().HasMaxLength(100); 
                entity.Property(a=>a.Author).IsRequired().HasMaxLength(100);  
                entity.Property(a=>a.PublishedDate).IsRequired(); 
            }); 

         }
       
    }
   
}