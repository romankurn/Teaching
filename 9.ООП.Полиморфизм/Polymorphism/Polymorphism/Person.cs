using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
	public class Person : ICloneable
	{
		public string Name { get; set; }
		public int Age { get; set; }

		public Person(string name, int age)
		{
			Name = name;
			Age = age;
		}

		public virtual void Print()
		{
			Console.Write($"{GetType().Name}. Name: {Name}, Age: {Age}");
		}

		//public virtual Person Clone()
		//{
		//	return new Person(Name, Age);
		//}

		public virtual object Clone()
		{
			return new Person(Name, Age);
		}
	}
}
