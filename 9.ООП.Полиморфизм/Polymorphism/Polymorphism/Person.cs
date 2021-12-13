using System;

namespace Polymorphism
{
	public class Person : ICloneable
	{
		public string Name { get; set; }
		public int Age { get; set; }

		public Person()
		{

		}

		public Person(string name, int age)
		{
			Name = name;
			Age = age;
		}

		public virtual void Print()
		{
			Console.WriteLine($"{GetType().Name}. Name: {Name}, Age: {Age}");
		}

		public virtual object Clone()
		{
			return new Person(Name, Age);
		}

		public override string ToString()
		{
			return $"{GetType().Name}. Name: {Name}, Age: {Age}";
		}

		public override bool Equals(object obj)
		{
			var person = obj as Person;


			if (Name != person.Name)
				return false;
			if (Age != person.Age)
				return false;

			return true;
		}

		public static Person GetRandomPerson()
		{
			var random = new Random();

			var max = PersonsCollection.Persons.Count;

			return PersonsCollection.Persons[random.Next(0, max)];
		}

	}
}
