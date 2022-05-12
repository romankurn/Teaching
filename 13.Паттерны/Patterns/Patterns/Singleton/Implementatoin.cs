using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Singleton
{
	public class Implementatoin
	{
		public static void Imp()
		{
			var singletoneOwner1 = new SingletoneOwner();

			singletoneOwner1.CreateSingleton("name1");
			Console.WriteLine(singletoneOwner1.Singleton.Name);

			var singletoneOwner2 = new SingletoneOwner();
			singletoneOwner2.CreateSingleton("name2");
			Console.WriteLine(singletoneOwner2.Singleton.Name);
		}

		public static async Task ImpMultiThread()
		{
			var task1 = new Task( () =>
			{
				var singletoneOwner1 = new SingletoneOwner();

				singletoneOwner1.CreateSingleton("name1");
				Console.WriteLine(singletoneOwner1.Singleton.Name);
			});

			var task2 = new Task( () =>
			{
				var singletoneOwner2 = new SingletoneOwner();
				singletoneOwner2.CreateSingleton("name2");
				Console.WriteLine(singletoneOwner2.Singleton.Name);
			});

			task1.Start();
			task2.Start();

			await Task.WhenAll(task1, task2);
		}
	}
}
