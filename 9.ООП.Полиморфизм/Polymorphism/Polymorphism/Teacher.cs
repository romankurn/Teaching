using System;
using System.Collections.Generic;
using System.Linq;

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
			base.Print();
		}

		public override object Clone()
		{
			return new Teacher(Name, Age, Facility, Course) { Id = Id, StudentIds = StudentIds.Select(id => id).ToList() };
		}

		public override string ToString()
		{
			var studentNames = ""; // выковырять имена

			return $"{GetType().Name}. Name: {Name}, Age: {Age}, Facility: {Facility}, Course: {Course}, Students: {studentNames}";
		}

		public override bool Equals(object obj)
		{
			if (obj.GetType().Name != typeof(Teacher).Name)
				return false;

			var person = obj as Teacher;

			if (Id != Id)
				return false;
			if (Facility != person.Facility)
				return false;
			if (Course != person.Course)
				return false;
			if (TeacherId != person.TeacherId)
				return false;

			if (StudentIds.Count != person.StudentIds.Count)
				return false;
			for (var i = 0; i < StudentIds.Count; i++)
			{
				if (StudentIds[i] != person.StudentIds[i])
					return false;
			}

			return true;
		}
	}
}
