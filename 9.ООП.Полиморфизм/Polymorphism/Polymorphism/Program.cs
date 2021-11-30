using System;

namespace Polymorphism
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var student1 = new Student("Bob", 20, "JD", 2);
			var student2 = new Student("Tom", 21, "BF", 3);
			var teacher = new Teacher("Tim", 52, "hg", 4);


		}

		static void Introduse(Person person)
		{
			person.Print();
		}

	}
}
