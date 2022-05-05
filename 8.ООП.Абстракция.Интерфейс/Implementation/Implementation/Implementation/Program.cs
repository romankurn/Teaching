using System;

namespace Implementation
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ICat cat = new Animal();
			IDog dog = new Animal();
			var animal = new Animal();
			var animal2 = new Animal2();

			cat.Say();
			cat.Move();

			dog.Say();
			dog.Move();

			//animal.Say();
			animal2.Say();

			((IDog)animal).Move();
			((IDog)animal).Say();
			((ICat)animal).Say();
		}


	}
}
