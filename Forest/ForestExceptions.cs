using System;

namespace Forest
{
	class ForestExceptions
	{
		public class ForestException : Exception
		{
			public override string Message
			{
				get { return "Unknown forest exception"; }
			}
		}

		public class NotFreeCellException : ForestException
		{
			public override string Message
			{
				get { return "The cell, you want to move in is occupied"; }
			}
		}

		public class OutOfMapBounds : ForestException
		{
			public override string Message
			{
				get { return "You can't move here: it's not on the map"; }
			}
		}

		public class ForestCellException:ForestException
		{
			public override string Message
			{
				get { return "You can't move to the forrest. Sorry. :'("; }
			}
		}

		public class NoCreatureWithThisName : ForestException
		{
			public override string Message
			{
				get { return "Move creature on the map, please. Not the one on your mind."; }
			}
		}

		public class InavalidMoveVector : ForestException
		{
			public override string Message
			{
				get { return "Can't move there, your move vector is Invalid. "; }
			}
		}
	}

}
