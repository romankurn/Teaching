using System;
using System.Collections.Generic;

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
			foreach (var person in Persons)
			{
				if (person is Student)
				{
					if ((person as Student).Id == id)
					{
						return person.Name;
					}
				}
			}
			return "Student not Found";
		}

		public int CountPersons()
		{
			var counter = 0;

			foreach (var person in Persons)
			{
				if (person.GetType().Name == typeof(Person).Name)
					counter++;
			}

			return counter;
		}

		public int CountStudents()
		{
			var counter = 0;

			foreach (var person in Persons)
			{
				if (person.GetType().Name == typeof(Student).Name)
					counter++;
			}

			return counter;
		}

		public int CountTeachers()
		{
			var counter = 0;

			foreach (var person in Persons)
			{
				if (person.GetType().Name == typeof(Teacher).Name)
					counter++;
			}

			return counter;
		}

		public void MoveStudentToTheNextCourse()
		{
			foreach (var person in Persons)
			{
				if (person is Student)
					(person as Student).Course += 1;
			}
		}

		public IEnumerator<Person> GetEnumerator()
		{
			return new UniversityEnumerator(Persons);
		}
	}
}
