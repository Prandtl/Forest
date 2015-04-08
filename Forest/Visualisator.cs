using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Forest
{
	interface IVisualisator
	{
		void OnNewState(IForest map);
	}
	class Visualisator : IVisualisator
	{
		public void OnNewState(IForest forest)
		{
			var size = forest.GetForestSize();

			var width = size.X;

			var rows = forest.GetPoints();
			var enumerator = rows.GetEnumerator();


			var j = 0;
			while (enumerator.MoveNext())
			{
				if (j == width)
				{
					j = 0;
					Console.Write('\n');
				}
				var e = enumerator.Current;
				char c;
				if (!artistsView.TryGetValue(e, out c))
					c = e[0];
				Console.Write(c);
			}
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
