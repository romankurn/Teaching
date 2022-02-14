using System;

namespace Task2
{
	internal class Program
	{
		//private List<int> parametersRange = [1-n] все качества в природе
		//private List<Person> Girls;
		//private List<Person> Men;
		// создать лист пар с максимально совпадающими свойствами;

		static void Main(string[] args)
		{
			var personsCreator = new PersonsCreator(5, 2);

			for (int i = 0; i < 2; i++)
			{
				personsCreator.GetPersons(2, 2);
			}

			var x = personsCreator.Mens;
			var y = personsCreator.Womens;
		}
	}
}
