using DynamicMenu;
using System;

namespace Polymorphism
{
	internal class CreateStudent : IAction
	{
		public void Execute()
		{
			Console.Write("Enter the student's name");
			var name = Console.ReadLine();
			Console.Write("Enter the student's age");
			var age = int.Parse(Console.ReadLine());
			Console.Write("Enter the student's facility");
			var facility = Console.ReadLine();
			Console.Write("Enter the student's Course");
			var course = int.Parse(Console.ReadLine());

			var student = new Student(name, age, facility, course);

			University.Persons.Add(student);
		}
	}
}
