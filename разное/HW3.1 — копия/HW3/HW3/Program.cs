using System;

namespace HW3
{
	internal class Program
	{
		private static string[] parameters = new[] { "a", "b", "c" };
		private static int selectedValue = 0;
		private static string _currentParameter;

		private static string _a, _b, _c;		

		private static bool _equationHasOneRoot = true;
		private static double _x1;
		private static double _x2;
		private static bool _parsingPassed = false;

		static void Main(string[] args)
		{
			ConsoleKeyInfo currentKey;

			do
			{
				PrintEquation();


				currentKey = Console.ReadKey();

				switch (currentKey.Key)
				{
					case ConsoleKey.UpArrow:
						SetUp();
						break;
					case ConsoleKey.DownArrow:
						SetDown();
						break;
					default:
						GetValues(selectedValue);
						break;
				}
				Console.Clear();
			}
			while (currentKey.Key != ConsoleKey.Escape);

			ConsoleKeyInfo currentKey1;
			var tempString = "";
			var curVariable = 0;
			string a, b, c;
			do
			{
				currentKey1 = Console.ReadKey();

				switch (currentKey1.Key)
				{
					case ConsoleKey.UpArrow:
						// Двигаем стрелку вверх
						// Ставим консольный курсор напротив переменной со стрелкой
						// Уменьшать curVariable (в пределах от 0 до 2)
						break;
					case ConsoleKey.DownArrow:
						// Двигаем стрелку вниз
						// Ставим консольный курсор напротив переменной со стрелкой
						// Увеличивать (в пределах от 0 до 2)
						break;
					case ConsoleKey.Enter:
						switch (curVariable)
						{
							case 0:
								a = tempString;
								break;
							case 1:
								b = tempString;
								break;
							case 2:
								c = tempString;
								break;
						}
						tempString = "";
						break;
					default:
						tempString += currentKey1.KeyChar;
						break;
				}
			} while (currentKey1.Key != ConsoleKey.Escape);
		}



		static void PrintEquation()
		{			
			switch (selectedValue)
			{
				case 0:
					_currentParameter = _a;
					break;

				case 1:
					_currentParameter = _b;
					break;

				case 2:
					_currentParameter = _c;
					break;
			}

			Console.WriteLine("a * x^2 + b * x + c = 0");

			for (var i = 0; i < parameters.Length; i++)
			{
				Console.WriteLine($"{(selectedValue == i ? ">" : "")}{parameters[i]}: {_currentParameter}");
			}
		}

		static void GetValues(int parameterNumber)
		{
			switch (parameterNumber)
			{
				case 0:
					_a = Console.ReadLine();
					break;

				case 1:
					_b = Console.ReadLine();
					break;

				case 2:
					_c = Console.ReadLine();
					break;
			}
		}

		private static void SetUp()
		{
			if (selectedValue > 0)
				selectedValue--;
		}

		private static void SetDown()
		{
			if (selectedValue < parameters.Length - 1)
			{
				selectedValue++;
			}
		}


	}
	//static void Main(string[] args)
	//{
	//	Console.WriteLine("a * x^2 + b * x + c = 0");

	//	while (!_parsingPassed)
	//	{
	//		_parsingPassed = true;

	//		try
	//		{
	//			GetValues();
	//			GetEquationsSolutions();
	//		}
	//		catch (IntParseException ex)
	//		{
	//			FormatData(ex.Message, Severity.Error, ex.Data);
	//			_parsingPassed = false;
	//		}
	//	}

	//	DisplayResult();
	//}


	//static void GetValues()
	//{
	//	Console.WriteLine("Введите значение a:");
	//	var a = Console.ReadLine();

	//	if (int.TryParse(a, out int parsedA))
	//		_a = parsedA;
	//	else
	//	{
	//		var aParseException = new IntParseException("a connot be parsed.");
	//		aParseException.Data.Add("param", a);
	//		throw aParseException;
	//	}

	//	Console.WriteLine("Введите значение b:");
	//	var b = Console.ReadLine();

	//	if (int.TryParse(b, out int parsedB))
	//		_b = parsedB;
	//	else
	//	{
	//		var bParseException = new IntParseException("b connot be parsed.");
	//		bParseException.Data.Add("param", b);
	//		throw bParseException;
	//	}

	//	Console.WriteLine("Введите значение c:");
	//	var c = Console.ReadLine();

	//	if (int.TryParse(c, out int parsedC))
	//		_c = parsedC;
	//	else
	//	{
	//		var cParseException = new IntParseException("c connot be parsed.");
	//		cParseException.Data.Add("c", c);
	//		throw cParseException;
	//	}
	//}

	//static void GetEquationsSolutions()
	//{

	//	var discriminant = _b * _b - 4 * _a * _c;

	//	try
	//	{
	//		if (discriminant < 0)
	//			throw new ValuesNotFoundException("Вещественных значений не найдено");
	//		else if (discriminant == 0)
	//		{
	//			_x1 = (-_b + Math.Sqrt(discriminant) / (2 * _a));
	//		}
	//		else
	//		{
	//			_equationHasOneRoot = false;
	//			_x1 = (-_b + Math.Sqrt(discriminant) / (2 * _a));
	//			_x2 = (-_b - Math.Sqrt(discriminant) / (2 * _a));
	//		}
	//	}
	//	catch (ValuesNotFoundException ex)
	//	{
	//		throw;
	//	}
	//}

	//static void DisplayResult()
	//{
	//	if (_equationHasOneRoot)
	//		Console.WriteLine($"x = {_x1}");
	//	else
	//		Console.WriteLine($"x1 = {_x1}, x2 = {_x2}");
	//}

	//static void FormatData(string message, Severity severity, IDictionary data)
	//{
	//	var separatorLine = new string('+', 50);

	//	Console.WriteLine(separatorLine);
	//	Console.WriteLine(message);
	//	Console.WriteLine(separatorLine);

	//	Console.WriteLine($"параметр = {data["param"]}");
	//}







	//static void GetValues()
	//{
	//	Console.WriteLine("Введите значение a:");
	//	var a = Console.ReadLine();

	//	Console.WriteLine("Введите значение b:");
	//	var b = Console.ReadLine();

	//	Console.WriteLine("Введите значение c:");
	//	var c = Console.ReadLine();

	//if (int.TryParse(a, out int parsedA))
	//		_b = parsedA;
	//	else
	//	{
	//		var aParseException = new IntParseException("a connot be parsed.");
	//aParseException.Data.Add("a", a);
	//		throw aParseException;
	//	}

	//	if (int.TryParse(b, out int parsedB))
	//		_b = parsedB;
	//	else
	//	{
	//		var bParseException = new IntParseException("b connot be parsed.");
	//		bParseException.Data.Add("b", b);
	//		throw bParseException;
	//	}

	//	if (int.TryParse(c, out int parsedC))
	//		_c = parsedC;
	//	else
	//	{
	//		var cParseException = new IntParseException("c connot be parsed.");
	//		cParseException.Data.Add("c", c);
	//		throw cParseException;
	//	}
}


