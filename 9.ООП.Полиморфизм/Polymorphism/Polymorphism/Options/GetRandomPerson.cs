using DynamicMenu;
using System;

namespace Polymorphism
{
	public class GetRandomPerson : IAction
	{
		public void Execute()
		{
			var random = new Random();

			University.Persons.Add(PersonsCollection.Persons[random.Next(0, 34)]);
		}
	}
}
