namespace GenericClass
{
	public class MyKeyValue<TKey, TValue>
	{
		public TKey Key { get; private set; }

		public TValue Value { get; set; }

		public MyKeyValue(TKey key, TValue value)
		{
			Key = key;
			Value = value;
		}
	}
}
