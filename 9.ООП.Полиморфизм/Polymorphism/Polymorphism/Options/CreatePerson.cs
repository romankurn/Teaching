using DynamicMenu;
using System;

namespace Polymorphism
{
	public class CreatePerson : IAction
	{
		public void Execute()
		{
			var person = new Person();

			Console.Write("Enter the person's name");
			person.Name = Console.ReadLine();
			Console.Write("Enter the person's age");
			person.Age = int.Parse(Console.ReadLine());

			University.Persons.Add(person);
		}
	}
}
