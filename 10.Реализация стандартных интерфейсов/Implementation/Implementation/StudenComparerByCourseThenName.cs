using Polymorphism;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
	public class StudenComparerByCourseThenName : IComparer<Student>
	{
		public int Compare(Student first, Student second)
		{
			if (second == null)
				throw new ArgumentNullException("Unpossible to compare with null");
			if (second.Course < first.Course)
			{
				return 1;
			}
			if (second.Course == first.Course)
			{
				return first.Name.CompareTo(second.Name);
			}
			return -1;
		}
	}
}
