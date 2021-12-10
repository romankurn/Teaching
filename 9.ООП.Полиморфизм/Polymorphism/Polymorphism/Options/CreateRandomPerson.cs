using HWMenu;
using System;

namespace Polymorphism
{
	public class CreateRandomPerson : IAction
	{
		public void Execute()
		{
			var random = new Random();

			var person = new Person(Names.RandomNames[random.Next(0, 34)], random.Next(0, 99));

			University.Persons.Add(person);
		}
	}
}
