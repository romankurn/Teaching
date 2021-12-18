using System.Collections.Generic;

namespace Polymorphism
{
	public interface IStudentCollection
	{
		IEnumerable<Student> GetStudents(string name);
	}
}
