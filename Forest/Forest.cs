using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;

namespace Forest
{
	interface IForest
	{
		void Put(string name, Point coordinates);

		void Move(string creatureName, Point vector);

		event Action<IForest> OnChange;

		IEnumerable<string> GetPoints();

		Point GetForestSize();
	}

	class FunkyForest : IForest
	{
		public FunkyForest(IMap map)
		{
			var mat = map.GetMapMatrice();
			for (int i = 0; i < mat.GetLength(0); i++)
			{
				for (int j = 0; j < mat.GetLength(1); j++)
				{
					forest[i, j] = SomeMagic(mat[i, j]);
				}
			}
		}

		public void Put(string name, Point coordinates)
		{
			var newAdventurer = new Creature(name);
			forest[coordinates.Y, coordinates.X].ReactWith(newAdventurer);

		}

		public void Move(string creatureName, Point vector)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<string> GetPoints()
		{
			for (int i = 0; i < forest.GetLength(0); i++)
			{
				for (int j = 0; j < forest.GetLength(1); j++)
				{
					yield return forest[i, j].GetSquareCode();
				}
			}
		}

		public Point GetForestSize()
		{
			return new Point(forest.GetLength(0), forest.GetLength(1));
		}

		public event Action<IForest> OnChange;

		private ForestSquare SomeMagic(char c)
		{
			return wizard[c].Invoke();
		}

		private static Dictionary<char, Func<ForestSquare>> wizard = new Dictionary<char, Func<ForestSquare>>
		{
			{'1',()=>new ForestCell()},
			{'0',()=>new RoadCell()},
			{'K',()=>new TrapCell()},
			{'L',()=>new LifeCell()}
		};

		private Dictionary<string, Creature> creatures;
		private Dictionary<Creature, Point> creaturePosition;

		private ForestSquare[,] forest;
	}

	public class Point
	{
		public int X { get; private set; }

		public int Y { get; private set; }

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public Point Add(Point a)
		{
			return new Point(X + a.X, Y + a.Y);
		}

		public Point Remove(Point a)
		{
			return new Point(a.X - X, a.Y - a.Y);
		}

		public bool IsValidMoveVector()
		{
			return X + Y <= 1;
		}
	}


}
