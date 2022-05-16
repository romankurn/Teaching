using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Prototype
{
	public class Circle : IFigure
	{
		public int Radius { get; set; }

		public Point Point { get; set; }

		public IFigure Clone()
		{
			return MemberwiseClone() as IFigure;
		}

		public IFigure DeepClone()
		{
			var json = JsonConvert.SerializeObject(this);
			return JsonConvert.DeserializeObject<Circle>(json);
		}

		public override string ToString()
		{
			return $"Radius: {Radius}, X: {Point.X}, Y: {Point.Y}";
		}
	}
}
