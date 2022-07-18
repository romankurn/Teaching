using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
	public abstract class HorseDecorator : Horse
	{
		protected Horse _horse;

		protected HorseDecorator(Horse horse, string name) : base(name)
		{
			_horse = horse;
		}

	}
}
