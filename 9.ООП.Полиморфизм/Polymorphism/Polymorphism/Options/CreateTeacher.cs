using HWMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
	public class CreateTeacher : IAction
	{
		public void Execute()
		{
			Console.Write("Enter the teacher's name");
			var name = Console.ReadLine();
			Console.Write("Enter the teacher's age");
			var age = int.Parse(Console.ReadLine());
			Console.Write("Enter the teacher's facility");
			var facility = Console.ReadLine();
			Console.Write("Enter the teacher's Course");
			var course = int.Parse(Console.ReadLine());

			var teacher = new Teacher(name, age, facility, course);

			University.Persons.Add(teacher);
		}
	}
}
