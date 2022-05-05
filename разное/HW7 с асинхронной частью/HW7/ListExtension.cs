using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
	public static class ListExtension
	{
		public static void ConsoleList(this List<Result> results)
		{
			foreach (Result result in results)
			{
				Console.WriteLine(result);
			}
		}
	}
}
