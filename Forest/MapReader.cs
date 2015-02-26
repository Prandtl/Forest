using System.IO;
using System.Linq;

namespace Forest
{
	interface IMapReader
	{
		IMap ReadFrom(string path);
	}
	class MapReader : IMapReader
	{
		public IMap ReadFrom(string path)
		{
			var lines = File.ReadAllLines(path);

			var map = new char[lines.Count(),lines[0].Length];

			var height = map.GetLength(0);
			var width = map.GetLength(1);

			for (var i = 0;i< height; i++)
			{
				for (var j = 0; j < width; j++)
				{
					map[i, j] = lines[i][j];
				}
			}

			return new Map(map);
		}
	}
}
