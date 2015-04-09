namespace Forest
{
	interface ForestSquare
	{
		bool ReactWith(Creature adventurer);
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

		public bool ReactWith(Creature adventurer)
		{
			return false;
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

		public int GetAmountOfLifes()
		{
			return lifes;
		}

		private string name;

		private int lifes;
	}

	class ForestCell : ForestSquare
	{
		public bool ReactWith(Creature adventurer)
		{
			return false;
		}

		public string GetSquareCode()
		{
			return "1";
		}
	}

	class RoadCell : ForestSquare
	{
		public bool ReactWith(Creature adventurer)
		{
			return true;
		}

		public string GetSquareCode()
		{
			return "0";
		}
	}

	class LifeCell : ForestSquare
	{
		public bool ReactWith(Creature adventurer)
		{
			adventurer.AddLife();
			return true;
		}

		public string GetSquareCode()
		{
			return "L";
		}
	}

	class TrapCell : ForestSquare
	{
		public bool ReactWith(Creature adventurer)
		{
			adventurer.RemoveLife();
			return true;
		}

		public string GetSquareCode()
		{
			return "T";
		}
	}
}
