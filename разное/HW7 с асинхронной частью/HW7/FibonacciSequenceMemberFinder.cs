namespace HW7
{
	public class FibonacciSequenceMemberFinder
	{
		public int GetFibonacciMemberByRecursion(int n)
		{
			if (n == 2)
				return 1;

			if (n == 1)
				return 0;

			var n_1 = GetFibonacciMemberByRecursion(n - 1);
			var n_2 = GetFibonacciMemberByRecursion(n - 2);

			return n_1 + n_2;
		}

		public int GetFibonacciMemberByCycle(int n)
		{
			var previous = 1;
			var previousprevious = 0;
			var current = 0;

			if (n == 1)
				return previousprevious;

			if (n == 2)
				return previous;

			for (int i = 2; i < n; i++)
			{
				current = previous + previousprevious;
				previousprevious = previous;
				previous = current;
			}

			return current;
		}
	}
}
