namespace Forest
{
	interface IMap
	{
		char[,] GetMapMatrice();
	}
	class Map : IMap
	{
		public char[,] GetMapMatrice()
		{
			return map;
		}
		public Map(char[,] map)
		{
			this.map = map;
		}

		private readonly char[,] map;
	}
}
