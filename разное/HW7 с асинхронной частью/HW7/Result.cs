namespace HW7
{
	public class Result
	{
		double SearchTime { get; set; }
		int ReceivedValue { get; set; }

		public Result(double searchTime, int receivedValue)
		{
			SearchTime = searchTime;
			ReceivedValue = receivedValue;
		}

		public override string ToString()
		{
			return $"Searching time: {SearchTime}, Received value: {ReceivedValue}";
		}
	}
}
