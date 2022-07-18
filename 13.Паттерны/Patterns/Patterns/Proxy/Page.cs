using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns.Proxy
{
	public class Page
	{
		public string Url { get; set; }

		public string Content { get; set; }

		public List<string> ExternalLinks { get; set; }

		public Page Click(ILoader site, string url)
		{
			return site.Find(url);			
		}
	}
}
