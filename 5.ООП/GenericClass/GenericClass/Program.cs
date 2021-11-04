using OOP1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericClass
{
	class Program
	{
		static void Main(string[] args)
		{
			var myDict = new MyDictionary<string, Point>();
			var random = new Random();

			for (var i = 0; i < 100; i++)
			{
				myDict.TryAdd($"fio{i}", new Point(random.Next(100), random.Next(100)));
			}

			var p1 = myDict["fio1"];
			myDict["fio1"] = new Point(1,1);

			myDict.TryGet("sdf", out Point p2);
		}
	}
}

//var dictionary = new Dictionary<string, int>
//			{
//				{ "fio2", 12},
//				{ "fio3", 33},
//				{ "fio1", 10}
//			};

//dictionary.Add("new fio", 10);
//var sucesses = dictionary.TryAdd("fio1", 52);

//var age = dictionary["fio1"];
//if (dictionary.TryGetValue("fio12", out var age2))
//{
//	Console.WriteLine(age2);
//}
