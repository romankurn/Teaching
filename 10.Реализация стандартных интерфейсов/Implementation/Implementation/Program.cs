using GenericClass;
using MoreLinq;
using Polymorphism;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Implementation
{
	internal class Program
	{
		static void Main(string[] args)
		{


			var count = new Random().Next(10, 100);

			IEnumerable<Student> students = new List<Student>
			{
				new Student("aaa3", 15, "1", 2),
				new Student("bbb2", 15, "1", 1),
				new Student("aaa1", 15, "1", 1)
			};

			var studentDictionary = new MyDictionary<Guid, Student>();
			students.ForEach(s => studentDictionary.TryAdd(s.Id, s));

			foreach(var student in studentDictionary)
			{
				student.Value.Print();
			}

			//var customContainer = new CustomCollection(new List<int> { 1, 2, 3, 4 });

			//foreach(var element in customContainer)
			//{
			//	Console.Write($"{element} ");
			//}
		}

		//static IEnumerable<Student> CreateStudents(int count)
		//{
		//	var random = new Random();

		//	for (var i = 0; i < count; i++)
		//	{
		//		var name = Guid.NewGuid().ToString();
		//		var age = random.Next(18, 50);
		//		var facility = Guid.NewGuid().ToString();
		//		var course = random.Next(1, 7);

		//		yield return new Student(name, age, facility, course);
		//	}
		//}
	}
}
