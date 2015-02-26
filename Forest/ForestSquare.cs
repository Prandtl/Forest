namespace Forest
{
	interface ForestSquare
	{
		void ReactWith(Creature adventurer);
		string GetSquareCode();
	}

	class Creature : ForestSquare
	{
		public Creature(string name)
		{
			this.name = name;
			lifes = 1;
		}
		public void MoveTo(ForestSquare cell)
		{
			cell.ReactWith(this);
		}

		public void ReactWith(Creature adventurer)
		{
			throw new ForestExceptions.NotFreeCellException();
		}

		public string GetSquareCode()
		{
			return name;
		}

		public void AddLife()
		{
			lifes++;
		}

		public void RemoveLife()
		{
			lifes--;
		}

		private string name;

		private int lifes;
	}

	class ForestCell : ForestSquare
	{
		public void ReactWith(Creature adventurer)
		{
			throw new ForestExceptions.ForestCellException();
		}

		public string GetSquareCode()
		{
			return "1";
		}
	}

	class RoadCell : ForestSquare
	{
		public void ReactWith(Creature adventurer)
		{
		}

		public string GetSquareCode()
		{
			return "0";
		}
	}

	class LifeCell : ForestSquare
	{
		public void ReactWith(Creature adventurer)
		{
			adventurer.AddLife();
		}

		public string GetSquareCode()
		{
			return "L";
		}
	}

	class TrapCell : ForestSquare
	{
		public void ReactWith(Creature adventurer)
		{
			adventurer.RemoveLife();
		}

		public string GetSquareCode()
		{
			return "T";
		}
	}
}
