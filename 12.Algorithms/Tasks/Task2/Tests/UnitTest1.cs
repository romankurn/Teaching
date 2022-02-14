using NUnit.Framework;
using Task2;

namespace Tests
{
	public class Tests
	{
		
		[Test]
		public void GetDecisionsFieldTest()
		{
			var personsCreator = new PersonsCreator(5, 2);

			for (int i = 0; i < 2; i++)
			{
				personsCreator.GetPersons(2, 2);
			}
		}
	}
}