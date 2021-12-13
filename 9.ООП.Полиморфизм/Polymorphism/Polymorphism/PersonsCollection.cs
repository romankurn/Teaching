using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
	public static class PersonsCollection
	{
		public static List<Person> Persons { get; set; } = new List<Person>();

		static PersonsCollection()
		{
			var random = new Random();

			for(var i = 0; i < 5; i++)
			{
				Person person = new Person(Names.RandomNames[random.Next(0, 34)], random.Next(0, 99));
				Persons.Add(person);
			}

			for(var i = 0;i < 25;i++)
			{
				Student student = new Student(Names.RandomNames[random.Next(0, 34)], random.Next(0, 99), $"fac{random.Next(1, 50)}", random.Next(1, 6));
				Persons.Add(student);
			}

			for(int i = 0; i < 5; i++)
			{
				Teacher teacher = new Teacher(Names.RandomNames[random.Next(0, 34)], random.Next(0, 99), $"fac{random.Next(1, 50)}", random.Next(6, 10));
				Persons.Add(teacher);
			}
		}
	}
}
