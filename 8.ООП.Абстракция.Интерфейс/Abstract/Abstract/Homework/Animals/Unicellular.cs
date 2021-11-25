using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract.Homework
{
	public class Unicellular : Animals
	{
		private static int _unicellularsNumber = 0;

		public UnicellularReproductionTypes UnicellularReproductionType { get; private set; }
		public AnimalSubkingdoms AnimalSubkingdoms { get; private set; }
		public GrowthStage GrowthStage { get; private set; }
		public NutritionType NutritionType { get; private set; }

		public Unicellular()
		{

		}

		public Unicellular(UnicellularReproductionTypes unicellularReproductionType) : base(AnimalSubkingdoms.Unicellular)
		{
			UnicellularReproductionType = unicellularReproductionType;
		}

		public override LivingOrganisms Reproduction()
		{
			throw new NotImplementedException();
		}

		// метод Growth этот класс должен знать от родителя, т.к. он от него наследуется, правильно?

		// метод Reproduction должен быть определён так:
		// проверка GrowthStage - должен быть от GrowthStage.Maturity
		// если UnicellularReproductionType.division, то сама микроба помирает, появляется 2 новых
		// если UnicellularReproductionType.gemmation, то микроба остаётся и появляется 1 новая микроба

		// метод Devour
		// вызывается для микробы, в параметрах другая микроба 
		// у вызвавшей микробы рост, целевая микроба умирает
	}
}
