namespace SortAlgorithms
{
	public class ShakerSort : SortBase
	{
		public override void Sort(int[] array)
		{
			var left = 0;
			var right = array.Length - 1;

			while (left < right)
			{
				for (var i = left; i < right; i++)
				{
					if (array[i] > array[i + 1])
						Swap(array, i, i + 1);
				}
				right--;
				for (var i = right; i > left; i--)
				{
					if (array[i] < array[i - 1])
						Swap(array, i, i - 1);
				}
				left++;
			}
		}
	}
}
