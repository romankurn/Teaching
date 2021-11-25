using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
	public class Student : Person
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public string Facility { get; set; }
		public int Course { get; set; }
		public Guid TeacherId { get; set; }

		public Student(string name, int age, string facility, int course) : base(name, age)
		{
			Facility = facility;
			Course = course;
		}
		public override void Print()
		{
			base.Print();
			Console.WriteLine($", Facility: {Facility}, Course: {Course}");
		}

		public override Person Clone()
		{
			return new Student(Name, Age, Facility, Course) { Id = Id, TeacherId = TeacherId};
		}
	}
}
