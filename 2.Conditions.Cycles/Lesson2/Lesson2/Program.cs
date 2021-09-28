using System;

namespace Lesson2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the string");
			var str = Console.ReadLine();

			Console.WriteLine("Enter the word");
			var word = Console.ReadLine();

			var res = Arrays.Func30(str, word);
			Console.Write(res);

		}
	}
}
