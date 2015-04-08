using System;

namespace Forest
{
	class Program
	{
		static void Main(string[] args)
		{
			IMapReader reader = new MapReader();
			var map = reader.ReadFrom("Maps/map1.txt");
			var forest = new FunkyForest(map);
			var visualisator = new Visualisator();
			forest.OnChange += visualisator.OnNewState;
			forest.Put("John",new Point(1,1));
			Console.ReadKey();
		}
	}
}
