using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract.Homework
{
	public class Mushrooms : LivingOrganisms
	{
		private static int _coloniesNumber = 0;
		
		public double MyceliumArea { get; private set; }

		public Mushrooms()
		{

		}

		public Mushrooms(NutritionType nutritionType, double myceliumArea) :base(nutritionType)
		{
			MyceliumArea = myceliumArea;
		}

		public override void Growth()
		{
			MyceliumArea *= 1.35;
		}

		public override Mushrooms Reproduction<Mushrooms>()
		{
			var progenyNumber = (int)(MyceliumArea / 3);
			_coloniesNumber += progenyNumber;

			var NewMushroom = new Mushrooms();

			for (var progen = 0; progen < progenyNumber; progen++)
			{
				NewMushroom = new Mushrooms(NutritionType.Heterotrophs, 1.5);
			}
			return NewMushroom;
		}
	}
}
