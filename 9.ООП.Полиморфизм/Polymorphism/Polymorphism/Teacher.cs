using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
	public class Teacher : Student
	{
		public List<Guid> StudentIds { get; set; } = new List<Guid>();

		public Teacher(string name, int age, string facility, int course) : base(name, age, facility, course)
		{

		}

		public override void Print()
		{
			Console.WriteLine($"{GetType().Name}. Name: {Name}, Age: {Age}");
		}

		public override object Clone()
		{
			return new Teacher(Name, Age, Facility, Course) { Id = Id, StudentIds = StudentIds.Select(id => id).ToList() };
		}

		public override string ToString()
		{
			return $"{GetType().Name}. Name: {Name}, Age: {Age}, Facility: {Facility}, Course: {Course}, Students: достать имена";
		}
	}
}
