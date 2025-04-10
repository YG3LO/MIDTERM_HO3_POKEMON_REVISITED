using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Server;


namespace PokemonAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PokemonController : ControllerBase
	{
		private static List<Pokemon> pokemons = new List<Pokemon>
		{
			new Pokemon { Id = 1, Name = "Ivysaur", Type = "Grass/Poison", PowerLevel = 85, BaseEvolution = "Bulbasaur", NextEvolution = "Venusaur", Generation = 1, Height = 1.0, Weight = 13.0, ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/2.png" },
			new Pokemon { Id = 2, Name = "Charmeleon", Type = "Fire", PowerLevel = 88, BaseEvolution = "Charmander", NextEvolution = "Charizard", Generation = 1, Height = 1.1, Weight = 19.0, ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/5.png" },
			new Pokemon { Id = 3, Name = "Wartortle", Type = "Water", PowerLevel = 84, BaseEvolution = "Squirtle", NextEvolution = "Blastoise", Generation = 1, Height = 1.0, Weight = 22.5, ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/7.png" },
			new Pokemon { Id = 4, Name = "Haunter", Type = "Ghost/Poison", PowerLevel = 86, BaseEvolution = "Gastly", NextEvolution = "Gengar", Generation = 1, Height = 1.6, Weight = 0.1, ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/93.png" },
			new Pokemon { Id = 5, Name = "Pidgeotto", Type = "Normal/Flying", PowerLevel = 82, BaseEvolution = "Pidgey", NextEvolution = "Pidgeot", Generation = 1, Height = 1.1, Weight = 30.0, ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/17.png" },

			new Pokemon { Id = 6, Name = "Bayleef", Type = "Grass", PowerLevel = 80, BaseEvolution = "Chikorita", NextEvolution = "Meganium", Generation = 2, Height = 1.2, Weight = 15.8, ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/153.png" },
			new Pokemon { Id = 7, Name = "Quilava", Type = "Fire", PowerLevel = 83, BaseEvolution = "Cyndaquil", NextEvolution = "Typhlosion", Generation = 2, Height = 0.9, Weight = 19.0, ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/156.png" },
			new Pokemon { Id = 8, Name = "Croconaw", Type = "Water", PowerLevel = 82, BaseEvolution = "Totodile", NextEvolution = "Feraligatr", Generation = 2, Height = 1.1, Weight = 25.0, ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/159.png" },
			new Pokemon { Id = 9, Name = "Flaaffy", Type = "Electric", PowerLevel = 81, BaseEvolution = "Mareep", NextEvolution = "Ampharos", Generation = 2, Height = 0.8, Weight = 13.3, ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/180.png" },
			new Pokemon { Id = 10, Name = "Pupitar", Type = "Rock/Ground", PowerLevel = 89, BaseEvolution = "Larvitar", NextEvolution = "Tyranitar", Generation = 2, Height = 1.2, Weight = 152.0, ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/247.png" },

			new Pokemon { Id = 11, Name = "Combusken", Type = "Fire/Fighting", PowerLevel = 87, BaseEvolution = "Torchic", NextEvolution = "Blaziken", Generation = 3, Height = 0.9, Weight = 19.5, ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/257.png" },
			new Pokemon { Id = 12, Name = "Grovyle", Type = "Grass", PowerLevel = 85, BaseEvolution = "Treecko", NextEvolution = "Sceptile", Generation = 3, Height = 0.9, Weight = 21.6, ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/253.png" },
			new Pokemon { Id = 13, Name = "Marshtomp", Type = "Water/Ground", PowerLevel = 86, BaseEvolution = "Mudkip", NextEvolution = "Swampert", Generation = 3, Height = 0.7, Weight = 28.0, ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/259.png" },
			new Pokemon { Id = 14, Name = "Lairon", Type = "Steel/Rock", PowerLevel = 88, BaseEvolution = "Aron", NextEvolution = "Aggron", Generation = 3, Height = 0.9, Weight = 120.0, ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/304.png" },
			new Pokemon { Id = 15, Name = "Vibrava", Type = "Ground/Dragon", PowerLevel = 84, BaseEvolution = "Trapinch", NextEvolution = "Flygon", Generation = 3, Height = 1.1, Weight = 15.3, ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/329.png" }

		};

		[HttpGet]
		public ActionResult<IEnumerable<Pokemon>> GetAllPokemons()
		{
			return Ok(pokemons);
		}

		[HttpGet("{id}")]
		public ActionResult<Pokemon> GetPokemonById(int id)
		{
			var pokemon = pokemons.FirstOrDefault(p => p.Id == id);
			if (pokemon == null) return NotFound();
			return Ok(pokemon);
		}

		[HttpPost]
		public ActionResult<Pokemon> AddPokemon([FromBody] Pokemon newPokemon)
		{
			newPokemon.Id = pokemons.Max(p => p.Id) + 1;
			pokemons.Add(newPokemon);
			return CreatedAtAction(nameof(GetPokemonById), new { id = newPokemon.Id }, newPokemon);
		}

		[HttpPut("{id}")]
		public IActionResult UpdatePokemon(int id, [FromBody] Pokemon updatedPokemon)
		{
			var pokemon = pokemons.FirstOrDefault(p => p.Id == id);
			if (pokemon == null) return NotFound();

			pokemon.Name = updatedPokemon.Name;
			pokemon.Type = updatedPokemon.Type;
			pokemon.PowerLevel = updatedPokemon.PowerLevel;
			pokemon.NextEvolution = updatedPokemon.NextEvolution;
			pokemon.BaseEvolution = updatedPokemon.BaseEvolution;
			pokemon.Generation = updatedPokemon.Generation;
			pokemon.Height = updatedPokemon.Height;
			pokemon.Weight = updatedPokemon.Weight;

			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeletePokemon(int id)
		{
			var pokemon = pokemons.FirstOrDefault(p => p.Id == id);
			if (pokemon == null) return NotFound();

			pokemons.Remove(pokemon);
			return NoContent();
		}
	}
}
