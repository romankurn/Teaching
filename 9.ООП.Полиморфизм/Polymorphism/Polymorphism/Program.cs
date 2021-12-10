using DynamicMenu;
using System;
using System.Linq;

namespace Polymorphism
{
	class Program
	{
		private static University _university = new University();

		static void Main(string[] args)
		{
			var mainMenu = new Menu();

			var type1 = typeof(Person);
			var type2 = typeof(Student);
			var type3 = typeof(Teacher);

			Person pers = new Student("Bob", 20, "JD", 2);

			var name = pers.GetType().Name;

			var student1 = new Student("Bob", 20, "JD", 2);
			var student2 = new Student("Tom", 21, "BF", 3);
			var student3 = new Student("name1", 1, "fac1", 1);
			var student4 = new Student("name2", 2, "fac1", 1);
			var student5 = new Student("name3", 3, "fac1", 2);
			var student6 = new Student("name4", 4, "fac1", 2);
			var student7 = new Student("name5", 5, "fac2", 3);
			var student8 = new Student("name6", 6, "fac2", 3);
			var student9 = new Student("name7", 7, "fac2", 4);
			var student10 = new Student("name1", 8, "fac2", 4);

			var teacher = new Teacher("Tim", 52, "hg", 4);
			var teacher1 = new Teacher("1name", 11, "fac1", 5);
			var teacher2 = new Teacher("2name", 12, "fac2", 6);

			var person1 = new Person("Bomj", 42);
			var person2 = new Person("Bomj2", 43);

			var x1 = person1.PersonalNumber;
			var x2 = person2.PersonalNumber;
			var y1 = student1.PersonalNumber;
			var y2 = student2.PersonalNumber;

			_university.Move(student1);
			_university.Move(student2);
			_university.Move(student3);
			_university.Move(student4);
			_university.Move(student5);
			_university.Move(student6);
			_university.Move(student7);
			_university.Move(student8);
			_university.Move(student9);
			_university.Move(student10);
			_university.Move(teacher);
			_university.Move(teacher1);
			_university.Move(teacher2);
			_university.Move(person1);
			_university.Move(person2);

			student1.TeacherId = teacher.Id;
			student2.TeacherId = teacher.Id;
			student3.TeacherId = teacher1.Id;
			student4.TeacherId = teacher2.Id;
			student5.TeacherId = teacher1.Id;
			student6.TeacherId = teacher2.Id;
			student7.TeacherId = teacher1.Id;
			student8.TeacherId = teacher2.Id;
			student9.TeacherId = teacher1.Id;
			student10.TeacherId = teacher2.Id;

		

			teacher.StudentIds.Add(student1.Id);
			teacher.StudentIds.Add(student2.Id);
			teacher1.StudentIds.Add(student3.Id);
			teacher1.StudentIds.Add(student5.Id);
			teacher1.StudentIds.Add(student7.Id);
			teacher1.StudentIds.Add(student9.Id);
			teacher2.StudentIds.Add(student4.Id);
			teacher2.StudentIds.Add(student6.Id);
			teacher2.StudentIds.Add(student8.Id);
			teacher2.StudentIds.Add(student10.Id);

			var x = Person.GetRandomPerson();


			foreach (var person in _university)
			{
				person.Print();
			}
		}

		static void Introduse(Person person)
		{
			person.Print();
		}
	}
}