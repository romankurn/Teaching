using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Adapter
{
	public class Driver
	{
		public void Travel(ITransport transport)
		{
			transport.Drive();
		}
	}
}
