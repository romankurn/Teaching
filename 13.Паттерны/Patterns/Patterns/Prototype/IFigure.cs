using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Prototype
{
	public interface IFigure
	{
		public IFigure Clone();

		public IFigure DeepClone();
	}
}
