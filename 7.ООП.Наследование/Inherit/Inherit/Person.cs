using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
	public class Person
	{
		private string _passport;

		public string Name { get; set; }

		public int Age { get; set; }

		public Gender Gender { get; set; }

		public Person()
		{

		}

		public Person(string name, Gender gender, int age, string passport)
		{
			_passport = passport;
			Name = name;
			Age = age;
			Gender = gender;
		}

		protected void Introduce()
		{
			Console.WriteLine($"Hello, my name is {Name}, I'm {Age}");
		}
	}
}
