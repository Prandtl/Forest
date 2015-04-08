using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest
{
	interface IVisualisator
	{
		void OnNewState(IForest map);
	}
	class Visualisator:IVisualisator
	{
		public void OnNewState(IForest forest)
		{
			var size = forest.GetForestSize();

			var width = size.X;

			var rows = forest.G
		}

		private Dictionary<string, char> artistsView = new Dictionary<string, char>
		{
			{"0", ' '},
			{"1",'█'},
			{"L",'♥'},
			{"K",'X'}
		};
	}
}
