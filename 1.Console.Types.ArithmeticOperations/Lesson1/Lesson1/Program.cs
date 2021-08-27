using System;

namespace Lesson1
{
	class Program
	{
        #region basic things
        private static void BasicThings()
        {
			bool a1 = true; //false;								!!!

			byte a2 = 55; //2^8 [0-255]								!
			sbyte a3 = 5;// [-128; 127]
			int a4; //negative: 2^16; 0, positive: (2^16) - 1		!!!
			long a5; // 2^32: negative, 0, 2^32 - 1 : positive		!!!

			float a6; //											!
			double a7; //											!!!
			decimal a8; //											!!

			char ch = '\n'; //enter									!!
			string str; //											!!!!

			Console.ReadLine(); // ввод строки с клавиатуры
			Console.WriteLine("чето"); // вывод чето на консоль 
			Convert.ToInt32("число");  // преобразовать строку в число
									   // $"{выполняемый блок кода}"

			int num;
			num = 10;
			//var number; //НЕЗЯ
			//number = 10;

			var doubl1 = 1.234;
			var str2 = "sdfsdf";
			var bl = true;
			var ch1 = 'f';

		}

		private static void ArithmeticOperations()
        {
			// + - сумма
			// - - разность
			// * - умноежение
			// / - деление
			// ++ - увеличить значение переменной на 1: а++
			// -- - уменьшить значение переменной на 1: а--
			// % - получить остаток от деления: 10%4=2; 10%5=0;
		}
		#endregion

		static void Main(string[] args)
		{
			Func9();
		}

		/// <summary>
		/// Составить программу вывода на экран числа, вводимого с клавиатуры.
		/// Выводимому числу должно предшествовать сообщение «Вы ввели число».
		/// </summary>
		private static void Func1()
		{
			Console.Write("Введите число ");
			int a = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine($"Вы ввели число {a}.");
		}

		/// <summary>
		/// Составить программу вывода на экран в одну строку трех любых чисел с двумя пробелами между ними.
		/// </summary>
		private static void Func2()
		{
			byte a = 5;
			byte b = 12;
			int c = -25;

			Console.WriteLine($"{a}  {b}  {c}");
		}

		/// <summary>
		/// Составить программу вывода на экран «столбиком» четырех любых чисел.
		/// </summary>
		private static void Func3()
		{
			byte a = 6;
			byte b = 8;
			int c = 54;
			double g = -51.83;

			Console.WriteLine($"{a}\n{b}\n{c}\n{g}");

		}

		/// <summary>
		/// вычислить значение функции y=7x^2+3x+6 при любом значении x
		/// </summary>
		private static void Func4()
		{
			Console.Write("Введите число ");
			var x = Convert.ToInt32(Console.ReadLine());
			var y = 7 * x * x + 3 * x + 6;
			Console.WriteLine($"Y = {y}.");
		}

		/// <summary>
		/// вычислить значение функции y=7x^2+x/3+6 при любом значении x
		/// </summary>
		private static void Func5()
		{
			Console.Write("Введите число ");
			var x = Convert.ToDouble(Console.ReadLine());
			var y = 7 * x * x + x / 3 + 6;
			Console.WriteLine($"Y = {y}.");
		}

		/// <summary>
		/// Даны два целых числа. Найти:
		/// а) их среднее арифметическое;
		/// б) их среднее геометрическое.
		/// </summary>
		private static void Func6()
		{

		}

		/// <summary>
		/// Составить программу решения линейного уравнения ax+b=0
		/// При любых (как целых так и вещественных) а и b, вводимых с клавиатуры
		/// </summary>
		private static void Func7()
		{

		}

		/// <summary>
		/// Дано вещественное число а. Пользуясь только операцией умножения, получить:
		/// а) a4 за две операции;
		/// б) a6 за три операции;
		/// в) a7 за четыре операции;
		/// г) a8 за три операции;
		/// д) a9 за четыре операции;
		/// е) a10 за четыре операции.
		/// </summary>
		private static void Func8()
		{

		}

		/// <summary>
		/// Дано двузначное число. Найти:
		/// а) число десятков в нем;
		/// б) число единиц в нем;
		/// в) сумму его цифр;
		/// г) произведение его цифр.
		/// </summary>
		private static void Func10()
		{
			var number = Convert.ToByte(Console.ReadLine()); //45: 4,5,9,20
			var tens = number / 10;
			var units = number % 10;
			var sum = tens + units;
			var mult = tens * units;
			Console.WriteLine($"a {tens}\nb {units}\nc {sum}\nd {mult}");
		}

		/// <summary>
		/// Дано трехзначное число. Найти число, полученное при прочтении его цифр справа налево.
		/// </summary>
		private static void Func11()
		{

		}

		/// <summary>
		/// Дано трехзначное число. В нем зачеркнули первую слева цифру и приписали ее в конце. Найти полученное число.
		/// </summary>
		private static void Func12()
		{

		}

		/// <summary>
		/// Даны два целых числа a и b.
		/// Если a делится на b или b делится на a, то вывести 1, иначе — любое другое число. 
		/// </summary>
		private static void Func15()
		{
			//TODO: после логических операций
		}

		#region Уух сложна

		/// <summary>
		/// С начала суток прошло n секунд. Определить:
		/// а) сколько полных часов прошло с начала суток;
		/// б) сколько полных минут прошло с начала очередного часа;
		/// в) сколько полных секунд прошло с начала очередной минуты.
		/// </summary>
		private static void Func9()
		{
			//7:23:59 = 26639;
			var n = Convert.ToInt32(Console.ReadLine());

			var hour = n / 3600;
			var min = (n % 3600) / 60;
			var sec = n % 60;

			Console.WriteLine($"a) {hour}\nб) {min}\nв) {sec}");


		}

		/// <summary>
		/// С начала суток часовая стрелка повернулась на y градусов (0 ≤ y ≤ 360, y — вещественное число).
		/// Определить число полных часов и число полных минут, прошедших с начала суток.
		/// </summary>
		private static void Func14()
		{

		}

		#endregion
	}
}
