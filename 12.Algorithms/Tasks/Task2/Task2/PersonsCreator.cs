using System.Collections.Generic;

namespace Task2
{
	public class PersonsCreator
	{
		private int _parametersRange;
		private int _parametersCount;

		public List<Person> Mens { get; private set; }
		public List<Person> Womens { get; private set; }

		public PersonsCreator(int parametersRange, int parametersCount)
		{
			_parametersRange = parametersRange;
			_parametersCount = parametersCount;
			Mens = new List<Person>();
			Womens = new List<Person>();
		}

		public void GetPersons(int mensCount, int womensCount)
		{
			for(int i = 0; i < mensCount; i++)
			{
				Mens.Add(new Person(_parametersCount, _parametersRange, true));
			}

			for (int i = 0; i < womensCount; i++)
			{
				Womens.Add(new Person(_parametersCount, _parametersRange, false));
			}
		}
	}
}
