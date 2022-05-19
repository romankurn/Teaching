using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Strategy
{
	public interface IFigure
	{
		string Name { get; }
		
		double CalculateArea();
	}
}
