using System;

namespace Functions
{
	//See Homework.docx

	public class Homework
	{
		//public static string tasl1 (string str)
		//{
		//	foreach (var symbol in str)
		//	{

		//	}	
		//}




	}

	public class Recursion
	{
		#region task 1
		public static double cFunction1(int z)
		{
			return Math.Sqrt(Math.Abs(pFunction1(4, z) + hFunction1(6, z)));
		}

		public static double pFunction1(int indexP, int z)
		{
			if (indexP == 1)
				return Math.Sin(0.5);

			return (z * pFunction1(indexP - 1, z) * pFunction1(indexP - 1, z) + pFunction1(indexP - 1, z) + 2);
		}

		public static double hFunction1(int indexH, int z)
		{
			if (indexH == 1)
				return Math.Cos(0.5);

			return (3 * hFunction1(indexH - 1, z) / (2 * z));
		}
		#endregion
	}
}
