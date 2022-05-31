using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Boxing
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int a = 5;
			double b = 5.0;
			var eq1 = ReferenceEquals(a, a); //t f
			var eq2 = Equals(a, a); //t t
			var eq3 = Equals(a, b); //f
			var eq4 = a == b; //t

			object obj1 = a;
			object obj2 = b;
			object obj3 = a;
			var eq11 = ReferenceEquals(obj1, obj1);//t
			var eq12 = ReferenceEquals(obj1, obj2);//f
			var eq13 = ReferenceEquals(obj1, obj3);//f
			var eq14 = Equals(obj1, obj2);//f
			var eq15 = Equals(obj1, obj3);//f //t
			var eq16 = obj1 == obj2;//f
			var eq17 = obj1 == obj3;//f

			var eq21 = obj1.Equals(a);//t
			var eq22 = a.Equals(obj1);//t
			var eq23 = Equals(a, obj1);//t
			var eq24 = ReferenceEquals(a, obj1);//f

			var myObj1 = new MyObject { a = 1 };
			var myObj2 = new MyObject { a = 1 };
			var eq31 = myObj1.Equals(myObj2);//f
			var eq32 = myObj1 == myObj2;//f
			var eq33 = Equals(myObj1, myObj1);//t

			var p1 = new Point(1, 1);
			Console.WriteLine(p1); // 1 1

			p1.Change(2, 2);
			Console.WriteLine(p1);// 2 2

			object objP = p1;
			Console.WriteLine(objP); // кто он такой // 2 2

			((Point)objP).Change(3, 3);
			Console.WriteLine(p1); // 2 2 
			Console.WriteLine(objP); // 3 3 // 2 2

			((IChangePoint)p1).Change(4, 4);
			Console.WriteLine(p1); // 2 2

			((IChangePoint)objP).Change(5, 5);
			Console.WriteLine(objP); // 2 2 // 5 5
			
			double doub1 = 5.3;
			object doub1Obj = doub1;
			int int1 = (int)(double)doub1Obj;

			//for (int i = 0; i <= 2; i++)
			//{
			//	dynamic dyn = i == 0 ? "A" : i == 1 ? 5 : false;
			//	var result = Add(dyn, dyn);
			//	Console.WriteLine(result);
			//}

			byte num1 = 3;  // 0011
			byte num2 = 10; // 1010
			var byteRes1 = num1 & num2; // 0010 = 2
			var byteRes2 = num1 | num2; // 1011 = 11
			var byteResu3 = num1 ^ num2; //1001 = 9

			var dictionary = new Dictionary<Point, string>();
			p1 = new Point(1, 1);
			var p2 = new Point(2, 2);
			dictionary.Add(p1, "p1");
			dictionary.Add(p2, "p2");

			var value1 = dictionary[p1];
			var value2 = dictionary[p2];
		}

		static string Add(string str1, string str2)
		{
			return str1 + str2;
		}

		static int Add(int int1, int int2)
		{
			return int1 + int2;
		}
	}
}
