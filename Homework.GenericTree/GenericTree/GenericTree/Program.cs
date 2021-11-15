using GenealogicalTree;
using System;
using System.Collections.Generic;

namespace GenericTree
{
	class Program
	{
		private static Content<string> forerunner;

		static void Main(string[] args)
		{
			var root = new Content<People>();

			var item1 = new Content<People>(new People("item 1", 1));
			var item2 = new Content<People>(new People("item 2", 2));

			var item11 = new Content<People>(new People("item 1.1", 11));
			var item12 = new Content<People>(new People("item 1.2", 12));

			var item21 = new Content<People>(new People("item 2.1", 21));
			var item211 = new Content<People>(new People("item 2.1.1", 211));
			var item212 = new Content<People>(new People("item 2.1.2", 212));


			root.Add(item1);
			root.Add(item2);
			item1.Add(item11);
			item1.Add(item12);
			item2.Add(item21);
			item21.Add(item211);
			item21.Add(item212);

			root["2.1.1"] = new People("new", 0);

			root.Scan();

			var exit = false;
			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("Choose action:");
				Console.WriteLine("1: Create new item");
				Console.WriteLine("2: Сhange existing item");
				Console.WriteLine("3: Delete item");
				Console.WriteLine("4: Show tree starting from item");

				Console.WriteLine("6: Save");
				Console.WriteLine("7: Load");
				Console.WriteLine("0: Close");
				var option = Convert.ToByte(Console.ReadLine());

				Console.WriteLine();
				switch (option)
				{
					case 1:
						//CreateItem();
						break;

					case 2:
						break;



					case 0:
						exit = true;
						break;
				}
				if (exit)
					break;
			}
		}

		//static void CreateItem()
		//{
			
		//	if (Content<string>.Counter == 0)
		//	{
		//		var firstItem = new Content<string>();
		//		forerunner.Add(firstItem);
		//		Console.WriteLine("Сreated element with id 1");
		//	}

		//	Console.WriteLine("Specify the id of the ancestor");
		//	var ancestorId = ConvertStringToId(Console.ReadLine());
		//	var item = new Content<string>(ancestorId);
		//	forerunner.Add(item, ancestorId);
		//}

		static List<int> ConvertStringToId(string str)
		{
			str = str.Replace(".", "");

			var Id = new List<int>();
			foreach (var elem in str)
			{
				Id.Add((int)elem - 48);
			}

			return Id;
		}
	}
}
