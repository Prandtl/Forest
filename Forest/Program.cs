using System;

namespace Forest
{
	class Program
	{
		static void Main(string[] args)
		{
			IMapReader reader = new MapReader();
			var map = reader.ReadFrom("Maps/map2.txt");
			var forest = new FunkyForest(map);
			var visualisator = new Visualisator();
			forest.OnChange += visualisator.OnNewState;
			//forest.Put("Kirill", new Point(1, 2));
			//Console.ReadKey();
			//forest.Move("Kirill",new Point(0,1));
			//Console.ReadKey();
			//forest.Move("Kirill", new Point(0, 1));
			//Console.ReadKey();
			//forest.Move("Kirill", new Point(1, 0));
			//Console.ReadKey();
			//forest.Move("Kirill", new Point(0, -1));
			Console.ReadKey();
			forest.Put("John",new Point(1,1));
			Console.ReadKey();
			forest.Move("Kirill", new Point(1, 0));
			Console.ReadKey();
			forest.Move("John", new Point(0, 1));
			Console.ReadKey();
			forest.Move("John", new Point(0, 1));
			Console.ReadKey();
			forest.Move("John", new Point(1, 0));
			Console.ReadKey();

		}
	}
}
