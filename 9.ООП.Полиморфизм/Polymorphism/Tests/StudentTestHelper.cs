using Polymorphism;
using System;
using System.Linq;

namespace Tests
{
	public static class StudentTestHelper
	{
		public static void AddFakeStudent(Student st)
		{
			PersonsCollection.AddStudent(st);
		}

		public static void RemoveStudentById(Guid studentId)
		{
			var index = 0;
			
			foreach(var pers in PersonsCollection._persons)
			{
				if ((pers as Student)?.Id == studentId)
					break;
				
				index++;
			}

			var index2 = PersonsCollection._persons.Select((p, index) 
				=>	(p as Student)?.Id == studentId ? index : -1).FirstOrDefault(i => i > -1);

			PersonsCollection._persons.RemoveAt(index);
		}
	}
}
