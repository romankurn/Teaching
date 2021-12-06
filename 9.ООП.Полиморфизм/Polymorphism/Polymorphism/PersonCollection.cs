using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
	public static class PersonCollection
	{
		public static List<Person> Persons { get; set; }

		static PersonCollection()
		{
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

			Persons.AddRange(new List<Person> { student1, student2 });
		}
	}
}
