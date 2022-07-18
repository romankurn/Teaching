using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns.Proxy
{
	public class Site : ILoader
	{
		private static List<Page> _pages;

		static Site()
		{
			_pages = new List<Page>();

			_pages.Add(new Page() { Url = "url1", Content = "Content1", ExternalLinks = new List<string> {"url3" } });
			_pages.Add(new Page() { Url = "url2", Content = "Content2", ExternalLinks = new List<string> { "url1" } });
			_pages.Add(new Page() { Url = "url3", Content = "Content3", ExternalLinks = new List<string> { "url1", "url2" } });
		}

		public Page Find(string url)
		{
			var time = 1500;


			Thread.Sleep(time);
			
			var page = _pages.FirstOrDefault(x => x.Url == url);

			if (page == null)
				throw new Exception("Page is not found");

			Console.WriteLine($"Page {page.Url} opened...in {time / 1000.0} sec");

			return page;
		}
	}
}
