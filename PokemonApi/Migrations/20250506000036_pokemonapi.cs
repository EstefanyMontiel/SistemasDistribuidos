using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonApi.Migrations
{
    /// <inheritdoc />
    public partial class pokemonapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Health",
                table: "Pokemons");

            migrationBuilder.RenameColumn(
                name: "attack",
                table: "Pokemons",
                newName: "Attack");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Attack",
                table: "Pokemons",
                newName: "attack");

            migrationBuilder.AddColumn<int>(
                name: "Health",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
