using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Proxy
{
	public static class Implementation
	{
		public static void Execute()
		{
			var stopwatch = new Stopwatch();

			stopwatch.Start();
			var site = new Site();

			var page3 = site.Find("url3");

			var page2 = page3.Click(site, "url2");
			var page1 = page2.Click(site, "url1");
			page3 = page1.Click(site, "url3");
			page2 = page3.Click(site, "url2");
			stopwatch.Stop();

			Console.WriteLine(stopwatch.ElapsedMilliseconds);

			stopwatch.Restart();
			var siteProxy = new SiteProxy(site);
			
			page3 = siteProxy.Find("url3");
			page2 = page3.Click(siteProxy, "url2");
			page1 = page2.Click(siteProxy, "url1");
			page3 = page1.Click(siteProxy, "url3");
			page2 = page3.Click(siteProxy, "url2");
			stopwatch.Stop();

			Console.WriteLine(stopwatch.ElapsedMilliseconds);

		}
	}
}
