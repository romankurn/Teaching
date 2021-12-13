using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
	public static class PersonsCollection
	{
		public static List<Person> _persons;

		public static Person GetRandomPerson()
		{
			var persons = GetPersons();

			var random = new Random();

			var max = persons.Count;

			return persons[random.Next(0, max)];
		}

		public static List<Person> GetPersons()
		{
			return _persons.Where(person => person.GetType().Name == typeof(Person).Name).ToList();
		}

		public static List<Student> GetStudents()
		{
			return _persons.Where(person => person.GetType().Name == typeof(Student).Name).Select(p => p as Student).ToList();
		}

		public static List<Teacher> GetTeachers()
		{
			return _persons.Where(person => person.GetType().Name == typeof(Teacher).Name).Select(p => p as Teacher).ToList();
		}

		public static void AddPerson(Person person)
		{
			_persons.Add(person);
		}

		public static void AddStudent(Student student)
		{
			_persons.Add(student);
		}

		public static void AddTeacher(Teacher teacher)
		{
			_persons.Add(teacher);
		}

		static PersonsCollection()
		{
			_persons = new List<Person>();

			var random = new Random();

			for(var i = 0; i < 5; i++)
			{
				Person person = new Person($"RandomName{random.Next(1, 35)}", random.Next(0, 99));
				_persons.Add(person);
			}

			for(var i = 0;i < 25;i++)
			{
				Student student = new Student($"RandomName{random.Next(1, 35)}", random.Next(0, 99), $"fac{random.Next(1, 50)}", random.Next(1, 6));
				_persons.Add(student);
			}

			for(int i = 0; i < 5; i++)
			{
				Teacher teacher = new Teacher($"RandomName{random.Next(1, 35)}", random.Next(0, 99), $"fac{random.Next(1, 50)}", random.Next(6, 10));
				_persons.Add(teacher);
			}
		}
	}
}
