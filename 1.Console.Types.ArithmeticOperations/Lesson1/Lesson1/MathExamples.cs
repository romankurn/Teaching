using System;

namespace Lesson1
{
	public class MathExamples
	{
		#region Math functions

		private static void MathFunctions()
		{
			//Abs(double value): возвращает абсолютное значение для аргумента value
			var result = Math.Abs(-12.4); // 12.4

			//Acos(double value): возвращает арккосинус value. Параметр value должен иметь значение от -1 до 1
			var result2 = Math.Acos(1); // 0

			//Asin(double value): возвращает арксинус value.Параметр value должен иметь значение от -1 до 1
			//Atan(double value): возвращает арктангенс value
			//Cos(double d): возвращает косинус угла d
			//Cosh(double d): возвращает гиперболический косинус угла d
			//Sin(double value): возвращает синус угла value
			//Sinh(double value): возвращает гиперболический синус угла value
			//Tan(double value): возвращает тангенс угла value
			//Tanh(double value): возвращает гиперболический тангенс угла value

			//BigMul(int x, int y): возвращает произведение x* y в виде объекта long
			var result3 = Math.BigMul(100, 9340); // 934000

			//Ceiling(double value): возвращает наименьшее целое число которое не меньше value - округление вверх до целого
			var result4 = Math.Ceiling(2.34); // 3

			//Floor(decimal d): возвращает наибольшее целое число, которое не больше d - округление вниз до целого
			var result5 = Math.Floor(2.56); // 2

			//DivRem(int a, int b, out int result): возвращает результат от деления a/b, а остаток помещается в параметр result
			int result6;
			var div = Math.DivRem(14, 5, out result6);
			//result6 = 4
			// div = 2

			//Exp(double d): возвращает основание натурального логарифма, возведенное в степень d. По-русски говоря - e^d

			//IEEERemainder(double a, double b): возвращает остаток от деления a на b - проще использовать %
			var result7 = Math.IEEERemainder(26, 4); // 2 = 26-24

			//Log(double d): возвращает натуральный логарифм числа d
			//Log(double a, double newBase): возвращает логарифм числа a по основанию newBase
			//Log10(double d): возвращает десятичный логарифм числа d
			//Max(double a, double b): возвращает максимальное число из a и b
			//Min(double a, double b): возвращает минимальное число из a и b

			//Pow(double a, double b): возвращает число a, возведенное в степень b
			var result8 = Math.Round(20.56); // 21
			var result9 = Math.Round(20.46); //20

			//Sign(double value): возвращает число 1, если число value положительное, и -1, если значение value отрицательное. Если value равно 0, то возвращает 0
			var result10 = Math.Sign(15); // 1
			var result11 = Math.Sign(-5); //-1

			//Truncate(double value): отбрасывает дробную часть числа value, возвращаяя лишь целое значние. Помоему, тоже самое что и Floor
			var result12 = Math.Truncate(16.89); // 16

			//Также класс Math определяет две константы: Math.E и Math.PI
		}

		#endregion

		public static void Func1()
		{

		}

		public static void Func2()
		{

		}

		public static void Func3()
		{

		}

		public static void Func4()
		{

		}

		public static void Func5()
		{

		}
	}
}
