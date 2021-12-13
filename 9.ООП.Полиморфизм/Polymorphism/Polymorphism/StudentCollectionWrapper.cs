using System.Collections.Generic;
using System.Linq;

namespace Polymorphism
{
	public class StudentCollectionWrapper : IStudentCollection
	{
		public IEnumerable<Student> GetStudents(string name)
		{
			return PersonsCollection.GetStudents().Where(p => p is Student && p.Name == name);
		}
	}
}
