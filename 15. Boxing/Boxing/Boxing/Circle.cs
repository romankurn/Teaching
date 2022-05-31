using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing
{
	internal class Circle
	{
		public Point Center { get; set; }

		public int Radius { get; set; }

		public override string ToString()
		{
			return $"Center {Center}; Radius = {Radius}";
		}

		public override bool Equals(object obj)
		{
			if(obj == null)
				return false;

			var circleObj = obj as Circle;

			return circleObj?.Center.Equals(Center) == true && circleObj?.Radius == Radius;
		}

		public override int GetHashCode()
		{
			return Center.GetHashCode() ^ Radius.GetHashCode();
				;
		}
	}
}
