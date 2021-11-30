using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
	public class University
	{
		public List<Person> Persons { get; set; } = new List<Person>();

		public void Move(Person person)
		{
			Persons.Add(person);
		}

		public string GetStudentNameById(Guid id)
		{
			var names = "";

			foreach (var person in Persons)
			{
				if(person is Student)
				{
					if((person as Student).Id == id)
					{
						names.Concat($" {person.Name}");
					}
				}
			}
			return names;
		}
	}	
}
