using System;

namespace OOP1
{
	public class TestClass
	{
		private int number;
		private int[] numbers;

		private Point point;

		private const int constValue = 5;
		private readonly int readonlyValue;

		public int IntProperty { get; set; }
		public int[] ArrayProperty { get; set; } = new[] { 10 };

		public TestClass()
		{
			ArrayProperty = new[] { 5 };
			IntProperty = 5;
		}

		public TestClass(int number, int[] numbers, Point point)
		{
			this.number = number;
			this.numbers = numbers;
			this.point = point;

			readonlyValue = number;
		}

		public TestClass(TestClass copyingObject)
		{
			number = copyingObject.number;

			numbers = new int[copyingObject.numbers.Length];
			Array.Copy(copyingObject.numbers, numbers, copyingObject.numbers.Length);

			point = new Point(copyingObject.point);
		}

		public void Modify()
		{
			IntProperty = 5;
		}
	}
}

//var ob1 = new TestClass(1, new[] { 1 });

////ob2.number: 1, ob2.numbers: {1}
//var ob2 = ob1;

//ob2.number = 2;
//ob2.numbers = new[] { 2 };

////ob1.number: 2 ; obj1.numbers: {2}


//Копирование значений
//var ob1 = new TestClass(1, new[] { 1 }, new Point(1, 1));

//TestClass obj2 = new TestClass(ob1);

//obj2.number = 2;
//obj2.numbers = new[] { 2 };
//obj2.point = new Point(2, 2);


//default 1
//ctor 2
//initializator 3