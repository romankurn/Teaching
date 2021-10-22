namespace OOP1
{
	public struct TestStruct
	{
		public int number;
		public int[] numbers;

		public TestStruct(int number, int[] numbers)
		{
			this.number = number;
			this.numbers = numbers;
		}
	}
}

//var str1 = new TestStruct(1, new[] { 1 });

////str2.number: 1, str2.numbers: {1}
//var str2 = str1;

//str2.number = 2;
//str2.numbers = new[] { 2 };

////str1.number: 1; str1.numbers: {1}