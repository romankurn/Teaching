namespace SortAlgorithms.EffictiveSorts
{
	public class QuickSort : SortBase
	{
		public override void Sort(int[] array)
		{
			Sort(array, 0, array.Length - 1);
		}

		private void Sort(int[] array, int start, int end)
		{
			if (start >= end)
				return;

			var partitionIndex = GetPartitionIndex(array, start, end);

			Sort(array, start, partitionIndex - 1);
			Sort(array, partitionIndex + 1, end);
		}

		private int GetPartitionIndex(int[] array, int start, int end)
		{
			var pivotIndex = start - 1;

			for (int j = start; j < end; j++)
			{
				if (array[j] < array[end])
				{
					pivotIndex++;
					Swap(ref array[pivotIndex], ref array[j]);
				}
			}

			Swap(ref array[pivotIndex + 1], ref array[end]);

			return pivotIndex + 1;
		}

		private void Swap(ref int first, ref int second)
		{
			var temp = first;
			first = second;
			second = temp;
		}

	}
}
