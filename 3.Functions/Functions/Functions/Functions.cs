﻿using System;

namespace Functions
{
	public class Functions
	{
		public static int GetMin(int[] array, out int index)
		{
			index = 0;
			var min = array[0];

			for (var i = 1; i < array.Length; i++)
			{
				if (array[i] < min)
				{
					min = array[i];
					index = i;
				}
			}

			return min;
		}

		public static int CalculateFactorial(int n)
		{
			if (n == 1)
				return 1;

			return CalculateFactorial(n - 1) * n;
			//n! = (n-1)! * n
			// 4! = 3! * 4; 3! = 2! * 3; 2! = 1! * 2; 1! = 1;
		}

		public static ulong Pow(ulong number, int power)
		{
			if (power == 1)
				return number;

			return Pow(number, power - 1) * number;

			//a^n = a^(n-1)*a
			//a^5 = a^4 * a; a^4 = a^3 * a; a^2 * a; a^1 * a; a^1 = a

		}

		public static int Fib(int n)
		{
			if (n == 2)
				return 1;

			if (n == 1)
				return 0;

			var n_1 = Fib(n - 1);
			var n_2 = Fib(n - 2);

			//5 = 4 + 3
			//4 = 3 + 2
			//3 = 2 + 1



			return n_1 + n_2;

			//f(3) = f(2) + f(1);
			//f(n) = f(n-2) + f(n-1)
			//f(1)= 0, f(2)= 1
			// 0 1 | 1 
		}


		






	}


}
