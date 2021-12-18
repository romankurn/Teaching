using System;
using System.Collections.Generic;
using System.Linq;

namespace Polymorphism
{
	public class University
	{
		public static List<Person> Persons { get; set; } = new List<Person>();

		private IStudentCollection _studentCollection;

		public University(IStudentCollection studentCollection)
		{
			_studentCollection = studentCollection;
		}

		public void Move(Person person)
		{
			Persons.Add(person);
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

		public IEnumerable<Student> GetStudentsByName(string name)
		{
			return _studentCollection.GetStudents(name);
		}

		public void SetStudentToTeacher(Guid studentId, Guid teacherId)
		{

		}
	}
}

//public int CountPersons()
//{
//	var counter = 0;

//	foreach (var person in Persons)
//	{
//		if (person.GetType().Name == typeof(Person).Name)
//			counter++;
//	}

//	return counter;
//}

//public int CountStudents()
//{
//	var counter = 0;

//	foreach (var person in Persons)
//	{
//		if (person.GetType().Name == typeof(Student).Name)
//			counter++;
//	}

//	return counter;
//}

//public int CountTeachers()
//{
//	var counter = 0;

//	foreach (var person in Persons)
//	{
//		if (person.GetType().Name == typeof(Teacher).Name)
//			counter++;
//	}

//	return counter;
//}
