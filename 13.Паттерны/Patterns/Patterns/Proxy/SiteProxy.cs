using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Proxy
{
	public class SiteProxy : ILoader
	{
		private Dictionary<string, Page> _pagesCache;

		private ILoader _loader;

		public SiteProxy(ILoader loader)
		{
			_loader = loader;
			_pagesCache = new Dictionary<string, Page>();
		}

		public Page Find(string url)
		{
			if(!_pagesCache.TryGetValue(url, out var page))
			{
				page = _loader.Find(url);
				_pagesCache.Add(url, page);
			}
			else
				Console.WriteLine($"Page {page.Url} opened...in 0 sec");

			return page;
		}
	}
}
