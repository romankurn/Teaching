using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
	public class DecisionsField
	{
		public List<List<int>> GetDecisionsField (List<Person> mens, List<Person> womens)
		{
			var basis = new List<Person>();
			var options = new List<Person>();

			if(mens.Count <= womens.Count)
			{
				basis = mens;
				options = womens;
			}
			else
			{
				basis = womens;
				options = mens;
			}

			var field = new List<List<int>>();
			
			for(var i = 0; i < basis.Count; i++)
			{
				field.Add(new List<int>());

				for(var j = 0; j < options.Count; j++)
				{
					field[i].Add(CountMatches(basis[i], options[j]));
				}
			}

			return field;
		}

		private int CountMatches(Person basisPerson, Person optionPerson)
		{
			var MatchesNomber = 0;

			for(var i=0; i < basisPerson.Parameters.Count; i++)
			{
				if (basisPerson.Parameters[i] == optionPerson.Parameters[i])
						{
					MatchesNomber++;
			}
			}

			return MatchesNomber;
		}
	}
}
