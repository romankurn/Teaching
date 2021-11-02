using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericClass
{
	public class MyDictionary<TKey, TValue>
	{
		private List<MyKeyValue<TKey, TValue>> _pairs;

		public MyDictionary()
		{
			_pairs = new List<MyKeyValue<TKey, TValue>>();
		}

		public MyDictionary(List<MyKeyValue<TKey, TValue>> pairs)
		{
			_pairs = pairs;
		}

		public bool TryAdd(TKey key, TValue value)
		{
			var exists = _pairs.Any(p => p.Key.Equals(key));
			if (exists)
				return false;

			_pairs.Add(new MyKeyValue<TKey, TValue>(key, value));

			return true;
		}

		public bool TryGet(TKey key, out TValue value)
		{
			var keyValue = _pairs.FirstOrDefault(p => p.Key.Equals(key));
			if (keyValue != null)
			{
				value = keyValue.Value;
				return true;
			}

			value = default;
			return false;
		}

		public TValue this[TKey key]
		{
			get
			{
				var keyValue = _pairs.FirstOrDefault(p => p.Key.Equals(key));

				if (keyValue != null)
				{
					return keyValue.Value;
				}
				else
				{
					throw new Exception("Element does not exist with provided key");
				}
			}
			set
			{
				var exists = _pairs.Any(p => p.Key.Equals(key));
				if (!exists)
					throw new Exception("Element does not exist with provided key");

				foreach(var pair in _pairs)
				{
					if (pair.Key.Equals(key))
					{
						pair.Value = value;
						break;
					}
				}
			}
		}
	}
}
