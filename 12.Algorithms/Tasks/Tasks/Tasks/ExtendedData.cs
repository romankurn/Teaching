namespace Tasks
{
	public class ExtendedData
	{
		public int Value { get; set; }

		public int Repetitions { get; set; }

		public ExtendedData(int value)
		{
			Value = value;
			Repetitions = 1;
		}

		public ExtendedData(int value, int repetitions)
		{
			Value = value;
			Repetitions = repetitions;
		}
	}
}
