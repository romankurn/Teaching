using System;

namespace Polymorphism
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Animal bird = new Bird();
			bird.Say(); // Animal says

			var mammal = new Mammal();
			mammal.Say(); // Mammal says
		}

		static void MakeAnimalSay(Animal animal)
		{
			animal.Say();
		}
	}
}
