using Newtonsoft.Json;
using System.IO;

namespace ObjectSaver
{
	public class File<TItem>
	{
		public static void Save(string fileName, TItem item)
		{
			var text = JsonConvert.SerializeObject(item);

			using(var sw = File.CreateText(fileName))
			{
				sw.WriteLine(text);
			}
		}

		public static TItem GetItemFromFile(string fileName)
		{
			var text = File.ReadAllText(fileName);

			return JsonConvert.DeserializeObject<TItem>(text);
		}
	}
}
