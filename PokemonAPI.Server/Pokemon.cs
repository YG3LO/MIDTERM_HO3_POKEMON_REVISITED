namespace PokemonAPI.Server
{
	public class Pokemon
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Type { get; set; } = string.Empty;
		public int PowerLevel { get; set; }
		public string BaseEvolution { get; set; } = string.Empty;
		public string NextEvolution { get; set; } = string.Empty;
		public int Generation { get; set; }
		public double Height { get; set; }
		public double Weight { get; set; }
		public string ImageUrl { get; set; } = string.Empty;
	}

}
