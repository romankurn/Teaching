namespace OOP1
{
	public class Car
	{
		public int number = 1;

		private Car()
		{

		}

		public static Car Create()
		{
			return new Car();
		}

		public int GetNumber()
		{
			return number;
		}
	}
}
