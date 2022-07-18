using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ArtWorkshop.Service.Autorization
{
	public static class AutorizedUserStorage
	{
		public static int ExpiredTimeMinutes => 15;

		public static ConcurrentDictionary<int, LastActivity> Users { get; set; } = new ConcurrentDictionary<int, LastActivity>();
	}
}
