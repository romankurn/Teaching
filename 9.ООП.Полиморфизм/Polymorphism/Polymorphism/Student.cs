using System;

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

		public override object Clone()
		{
			return new Student(Name, Age, Facility, Course) { Id = Id, TeacherId = TeacherId };
		}

		//public int CompareTo(Student other)
		//{
		//	if(other == null)
		//		throw new ArgumentNullException("Unpossible to compare with null");
		//	if (other.Course < Course)
		//	{
		//		return 1;
		//	}
		//	if (other.Course == Course)
		//	{
		//		return Name.CompareTo(other.Name);
		//	}
		//	return -1;
		//}
	}
}
