using System;
using System.Collections.Generic;

namespace Task2
{
	public class Person
	{
		public bool Male { get; private set; }

		public List<int> Parameters { get; private set; }

		public Person(int parameterCount, int parametersRange, bool male)
		{
			Male = male;

			Parameters = new List<int>();

			var random = new Random();
			for (var i = 0; i < parameterCount; i++) // как сделать без цикла?
			{
				Parameters.Add(random.Next(1, parametersRange));
			}
		}
	}
}
