using System;

namespace Polymorphism
{
	public class Student : Person
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Facility { get; set; }
		public int Course { get; set; }
		public Guid TeacherId { get; set; }

		public Student()
		{

		}

		public Student(string name, int age, string facility, int course) : base(name, age)
		{
			Facility = facility;
			Course = course;
		}
		public override void Print()
		{
			Console.WriteLine($"{GetType().Name}. Name: {Name}, Age: {Age}, Facility: {Facility}, Course: {Course}");
		}

		public override object Clone()
		{
			return new Student(Name, Age, Facility, Course) { Id = Id, TeacherId = TeacherId };
		}

		public override string ToString()
		{
			var teacherName = ""; // выковырять имя

			return $"{GetType().Name}. Name: {Name}, Age: {Age}, Facility: {Facility}, Course: {Course}, Teacher's name: {teacherName}";
		}

		public override bool Equals(object obj)
		{
			if (obj.GetType().Name != typeof(Student).Name)
				return false;

			var person = obj as Student;

			if (!base.Equals(person))
				return false;

			if (Id != (person as Student).Id)
				return false;
			if (Facility != (person as Student).Facility)
				return false;
			if (Course != (person as Student).Course)
				return false;
			if (TeacherId != (person as Student).TeacherId)
				return false;

			return true;
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
