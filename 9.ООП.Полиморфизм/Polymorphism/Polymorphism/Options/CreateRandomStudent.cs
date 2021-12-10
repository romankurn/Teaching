using HWMenu;
using System;

namespace Polymorphism
{
	public class CreateRandomStudent : IAction
	{
		public void Execute()
		{
			var random = new Random();

			var student = new Student(Names.RandomNames[random.Next(0, 34)], random.Next(0, 99), $"fac{random.Next(1, 50)}", random.Next(1, 6));

			University.Persons.Add(student);
		}
	}
}
