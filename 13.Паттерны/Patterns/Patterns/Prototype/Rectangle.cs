using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Prototype
{
	public class Rectangle : IFigure
	{
		public int Height { get; set; }

		public int Width { get; set; }
		
		public IFigure Clone()
		{
			return MemberwiseClone() as IFigure;
		}

		public IFigure DeepClone()
		{
			return Clone();
		}

		public override string ToString()
		{
			return $"Height: {Height}, Width: {Width}";
		}
	}
}
