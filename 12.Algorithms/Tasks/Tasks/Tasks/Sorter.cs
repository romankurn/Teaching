namespace Tasks
{
	public class Sorter
	{
		
		public int[] GetSordedByCount(int[] array)
		{
			if(array.Length == 1) // есть ли для этого условия место лучше? 
				return array;
			
			var sorter = new SortHelper();
			sorter.CountRepetitions(array);
			sorter.SortByRepetitions();
			//sorter.SortByValue();

			return sorter.GetSortedArray();
		}
	}
}
