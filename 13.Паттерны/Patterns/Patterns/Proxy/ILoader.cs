using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Proxy
{
	public interface ILoader
	{
		Page Find(string url);
	}
}
