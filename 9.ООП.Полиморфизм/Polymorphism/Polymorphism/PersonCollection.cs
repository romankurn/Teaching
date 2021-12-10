using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
	public static class PersonCollection
	{
		public static List<Person> Persons;

		static PersonCollection()
		{
			Persons = new List<Person>();
			
			for (var i = 1; i <= 50; i++)
			{
				Persons.Add(new Student($"Name{i}", i, $"Facility-{i}", i % 5));
			}
		}
	}
}
