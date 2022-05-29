using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
	internal class Expression
	{
		public double Value1 { get; set; }

		public double Value2 { get; set; }

		public string Operation { get; set; }

		public Expression(string expression)
		{
			var components = expression.Split(' '); // обработка получения строки

			Value1 = double.Parse(components[0]);

			switch (components[1])
			{ 
				case "+":
					Operation = Client.Operation.Addition.ToString();
					break;

				case "-":
					Operation = Client.Operation.Subtraction.ToString();
					break;

				case "*":
					Operation = Client.Operation.Multiplication.ToString();
					break;

				case "/":
					Operation = Client.Operation.Division.ToString();
					break;

				case "^":
					Operation = Client.Operation.Pow.ToString();
					break;

				default:
					Operation = Client.Operation.Utca.ToString();
					break;
			}

			Value2 = double.Parse(components[2]);
		}
	}
}
