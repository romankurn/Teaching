using System;
using System.Threading.Tasks;

namespace HW7
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var sequenceMembersNumber = new int[] { 5, 10, 20 , 45};
			var tester = new FibonacciTester();

			foreach (var sequenceMember in sequenceMembersNumber)
			{
				var result = await tester.DoTest(sequenceMember);
				result.ConsoleList();
			}
		}
	}
}
