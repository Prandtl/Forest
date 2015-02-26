using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Forest
{
	interface IForest
	{
		void Put(string name, Point coordinates);

		void Move(string creatureName, Point vector);

		void GenerateFromMatrice();
	}

	internal class FunkyForest : IForest
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

		}

		public void Move(string creatureName, Point vector)
		{
			throw new NotImplementedException();
		}

		public void GenerateFromMatrice()
		{
			throw new NotImplementedException();
		}

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

	class MatriceForest : IForest
	{

		public void Put(string newCreatureName, Point coordinates)
		{
			var newAdventurer = new Creature(newCreatureName);
			newAdventurer.MoveTo(forest[coordinates.X, coordinates.Y]);
			forest[coordinates.X, coordinates.Y] = newAdventurer;//TODO: name collision detection

		}

		public void Move(string creatureName, Point vector)
		{
			CheckName(creatureName);
			var chosenOne = creatures[creatureName];

			vector.IsValidMoveVector();

			var position = creaturePosition[chosenOne];
			var nextPoint = position.Add(vector);
			CheckPoint(nextPoint);

			chosenOne.MoveTo(forest[nextPoint.X, nextPoint.Y]);
			forest[nextPoint.X, nextPoint.Y] = chosenOne;
			forest[position.X, position.Y] = new RoadCell();
		}

		public void GenerateFromMatrice()
		{
			throw new NotImplementedException();
		}

		private void CheckName(string name)
		{
			if (!creatures.ContainsKey(name))
				throw new ForestExceptions.NoCreatureWithThisName();
		}

		private void CheckPoint(Point x)
		{
			if ((x.X < 0 || x.X >= forest.GetLength(0)) || (x.Y < 0 || x.Y >= forest.GetLength(1)))
				throw new ForestExceptions.OutOfMapBounds();
		}

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
