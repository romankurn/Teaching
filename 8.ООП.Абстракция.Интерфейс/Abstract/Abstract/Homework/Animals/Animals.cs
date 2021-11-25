using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract.Homework
{
	public class Animals : LivingOrganisms
	{
		protected AnimalSubkingdoms _animalSubkingdoms;

		protected GrowthStage _growthStage;

		public Animals()
		{
			
		}

		public Animals(AnimalSubkingdoms animalSubkingdoms) : base(NutritionType.Heterotrophs)
		{
			_animalSubkingdoms = animalSubkingdoms;
			_growthStage = GrowthStage.Inception;
		}

		public override void Growth()
		{
			if (_growthStage == GrowthStage.Inception)
				_growthStage = GrowthStage.Maturity;
			else if (_growthStage == GrowthStage.Maturity)
				_growthStage = GrowthStage.Senility;
			else
			{
				Console.WriteLine("Died of old age");
				// тут должна вызываться функция, которая будет умирать животинку
			}
		}

		public abstract organismType Reproduction<organismType>();
		// вот тут вопрос 4
	}
}
