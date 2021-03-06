using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract.Homework
{
	public abstract class LivingOrganisms
	{
		protected NutritionType _nutritionType;

		protected LivingOrganisms()
		{

		}

		public LivingOrganisms(NutritionType nutritionType)
		{
			_nutritionType = nutritionType;
		}

		public abstract void Growth();

		public abstract LivingOrganisms Reproduction();
	}
}
