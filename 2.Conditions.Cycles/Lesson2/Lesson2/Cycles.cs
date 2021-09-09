using System;

namespace Lesson2
{
	public class Cycles
	{
		#region Description
		public static void Description()
		{
			//цикл с параметром/условием/счетчиком
			for (var i = 1; i < 10; i++)
			{
				if (i == 5)
					continue; //перейти к следующему шагу цикла

				Console.Write($"{i} ");
			}

			for (var i = 10; i > 1; --i)
			{
				if (i == 5)
					break;

				Console.Write($"{i} ");
			}

			var condition = true;
			//цикл do-while
			do
			{
				//action
			} while (condition);
			//int number;
			//do
			//{
			//	Console.Write("Введите отрицательное число >> ");
			//	number = Convert.ToInt32(Console.ReadLine());
			//}
			//while (number >= 0);

			while (condition)
			{

			}
			//int number = 0;
			//while (number >= 0)
			//{
			//	Console.Write("Введите отрицательное число >> ");
			//	number = Convert.ToInt32(Console.ReadLine());
			//}





		}
		#endregion

		#region Цикл for

		#region Простота


		/// <summary>
		/// Найти сумму всех целых чисел от –10 до b (значение b вводится с клавиатуры; b>–10)
		/// </summary>
		public static void Func1()
		{
			Console.WriteLine("Введите число b");
			var b = Convert.ToInt32(Console.ReadLine());
			var sum = 0;

			for (var i = -10; i < b; i++)
			{
				sum += i; // sum = sum + i;
			}

			Console.WriteLine(sum);
		}

		/// <summary>
		/// среднее арифметическое всех целых чисел от a до b (значения a и b вводятся с клавиатуры; b>a)
		/// </summary>
		public static void Func2()
		{
			Console.WriteLine("Введите число a");
			var a = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine($"Введите число b>{a}");
			var b = Convert.ToInt32(Console.ReadLine());

			double sum = 0;
			var counter = 0;
			for (var i = a; i <= b; i++)
			{
				sum += i;
				counter++;
			}

			Console.WriteLine(sum / counter);
		}

		/// <summary>
		/// сумму квадратов всех целых чисел от a до b (значения a и b вводятся с клавиатуры).
		/// </summary>
		public static void Func3()
		{
			Console.WriteLine("Введите два разных целых числа");
			var a = Convert.ToInt32(Console.ReadLine());
			var b = Convert.ToInt32(Console.ReadLine());

			var sum = 0;
			var max = Math.Max(a, b);
			var min = Math.Min(a, b);

			for (var number = min; number <= max; number++)
			{
				sum += number * number;
			}
			Console.WriteLine($"Сумма квадратов чисел = {sum}");

		}

		/// <summary>
		/// Вычислить сумму 1 + 1/3 + 1/3^2 + 1/3^3 + ... + 1/3^n.
		/// Операцию возведения в степень не использовать. Вложенные циклы тоже
		/// </summary>
		public static void Func4()
		{
			Console.WriteLine("Введите число n");
			var n = Convert.ToInt32(Console.ReadLine());

			double sum = 0;
			int denominator = 1;
			var start = DateTime.Now;
			for (var i = 1; i <= n; i++)
			{
				sum += 1.0 / denominator;
				denominator *= 3;
			}
			var end = DateTime.Now;
			var time = end - start;

			Console.WriteLine(sum);
		}

		/// <summary>
		/// Вычислить сумму 1 — 1/2 + 1/3 +  … (-1)^(n+1) / n .
		/// Условный оператор и операцию возведения в степень не использовать.
		/// </summary>
		public static void Func5()
		{
			Console.WriteLine("Введите число n");
			var n = Convert.ToInt32(Console.ReadLine());

			double sum = 0;
			int denominator = 1;
			int numerator = 1;
			for (var number = 1; number <= n; number++)
			{
				sum += (double)numerator / denominator;
				numerator *= -1;
				denominator++;
			}
			Console.WriteLine($"Сумма всех членов последовательности = {sum}");

		}

		#endregion

		#region Обработка данных во время ввода

		/// <summary>
		/// Даны числа a1, a2, …, a10. Определить их сумму.
		/// </summary>
		public static void Func6()
		{
			Console.WriteLine("Вводите 10 чисел через ентер");

			var sum = 0;
			for (var i = 1; i <= 10; i++)
			{
				sum += Convert.ToInt32(Console.ReadLine());
			}
			Console.WriteLine(sum);
		}

		/// <summary>
		/// Даны натуральное число n и целые числа a1, a2, …, an.
		/// Определить среднее арифметическое чисел a
		/// </summary>
		public static void Func7()
		{
			Console.WriteLine("Введите количество чисел");
			var n = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine($"Вводите {n} чисел через ентер");

			double sum = 0;
			for (var i = 1; i <= n; i++)
			{
				sum += Convert.ToInt32(Console.ReadLine());
			}
			Console.WriteLine(sum / n);
		}

		/// <summary>
		/// Даны натуральное число n и целые числа a1, a2, …, an..
		/// Определить без использования условий и возведения в степень:
		///а) |a1| + |a2| + … + |an|;
		///б) |a1| * |a2| * … * |an|;
		///в) a1 + a2, a2 + a3 …, an-1 + an; ???? 1) как так можно выводить? 2) а что если n нечётное? 
		///г) a1 — a2, a2 — a3, …, an-1 — an; ????
		/// </summary>
		public static void Func8()
		{
			Console.WriteLine("Введите количество чисел");
			var n = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine($"Вводите {n} целых чисел через ентер");

			var sumOfAbses = 0;
			var multOfAbses = 1;
			for (var i = 1; i <= n; i++) // как обычно называют переменную в счётчике?
			{
				var enteredNumber = Math.Abs(Convert.ToInt32(Console.ReadLine()));
				sumOfAbses += enteredNumber;
				multOfAbses *= enteredNumber;
				var previousNumber = enteredNumber;
			}
			Console.WriteLine($"Сумма модулей введёных чисел = {sumOfAbses}, произведение модулей = {multOfAbses}");
		}

		#endregion

		#region Рекуррентные соотношения

		/// <summary>
		/// Последовательность Фибоначчи образуется так: первый и второй члены последовательности равны 1,
		/// каждый следующий равен сумме двух предыдущих (1, 1, 2, 3, 5, 8, 13, …).
		/// Дано натуральное число n (n > 3).
		///а) Найти k-й член последовательности Фибоначчи.
		///б) Получить первые n членов последовательности Фибоначчи. ??? как вывести первые 2 один раз? 
		///в) Верно ли, что сумма первых n членов последовательности Фибоначчи есть четное число?
		/// </summary>
		public static void Func9()
		{
			//f(An)=An-2+An-1;
			// считаю, что n = k, чтобы не делать 2 цикла

			Console.WriteLine("Какой член последовательности ищем?");
			var k = Convert.ToInt32(Console.ReadLine());

			long current = 0;
			long previous = 1;
			long prePrevious = 1;
			long sum = 2;

			Console.Write("1й = 1; 2й = 1;");
			for (var i = 3; i <= k; i++)
			{
				current = previous + prePrevious;

				prePrevious = previous;
				previous = current;
				sum += current;
				Console.Write($" {i}й = {current};");
			}
			Console.WriteLine($"\n{k}-й член последовательности: {current}");

			Console.WriteLine(sum);
			if (sum % 2 == 0)
			{
				Console.WriteLine($"сумма первых {k} членов последовательности Фибоначчи - четное число");
			}
			else
			{
				Console.WriteLine($"сумма первых {k} членов последовательности Фибоначчи не является четным числом");
			}
		}

		/// <summary>
		/// Одноклеточная амеба каждые 3 часа делится на 2 клетки.
		/// Определить, сколько клеток будет через n часов, если первоначально была одна амеба
		/// </summary>
		public static void Func10()
		{
			Console.WriteLine("Сколько часов у амёбы на деление?");
			var n = Convert.ToInt32(Console.ReadLine());

			var numberOfAmebs1 = 1 * Math.Pow(2, (n / 3));

			var numberOfAmebs2 = 1;
			for (var hours = 1; hours <= (n / 3); hours++)
			{
				numberOfAmebs2 *= 2;
			}
			Console.WriteLine($"Количество амёб 1 = {numberOfAmebs2}; количество 2 ={numberOfAmebs2}");

		}

		#endregion

		#region Посерьезнее

		/// <summary>
		/// Расчет факториала натурального числа n
		/// </summary>
		public static void Func12()
		{
			Console.WriteLine("Факториал какого числа ищем?");
			var n = Convert.ToInt32(Console.ReadLine());

			var factorial = 1;
			for (var i = 1; i <= n; i++)
			{
				factorial *= i;
			}
			Console.WriteLine($"Факториал числа {n} = {factorial}");
		}

		/// <summary>
		/// Вычислить сумму 1! + 2! + 3! +  … + n!
		/// 1 < n <= 10
		/// без вложенных цыклов
		/// </summary>
		public static void Func13()
		{
			Console.WriteLine("До факториала какого числа <10 будем складывать?");
			var n = Convert.ToInt32(Console.ReadLine());

			var factorial = 1;
			var sum = 0;
			for (var i = 1; i <= n; i++)
			{
				factorial *= i;
				sum += factorial;
			}
			Console.WriteLine($"Сумма {n} факториалов равно {sum}");

		}
		//TODO: Сделать красиво с использованием функций


		/// <summary>
		/// Дано число любой степени. Выяснить, является ли оно палиндромом, т. е. таким числом,
		/// десятичная запись которого читается одинаково слева направо и справа налево.
		/// </summary>
		public static void Func14()
		{
			Console.WriteLine("Введите число n");
			var n = Convert.ToInt32(Console.ReadLine());

			var numberOfDischarges = (int)Math.Log10(n);

			//589
			var newNumber = 0;
			var newDischarge = numberOfDischarges;
			for (var i = 1; i <= numberOfDischarges + 1; i++)
			{
				var currentDischrge = (int)(n % Math.Pow(10, i) / Math.Pow(10, i - 1));//985
				newNumber += currentDischrge * (int)Math.Pow(10, newDischarge);//985
				newDischarge--;//10
			}
			if (n == newNumber)
			{
				Console.WriteLine($"Число {n} является палиндромом");
			}
			else
			{
				Console.WriteLine($"Число {n} НЕ является палиндромом");
			}

			// Console.WriteLine($"nomberOfDischarges = {nomberOfDischarges};\n newNumber = {newNumber} ");
		}

		/// <summary>
		/// Дано число любой степени. Определить:входит ли в него цифра а.
		/// </summary>
		public static void Func15()
		{
			//a2*10^2+a1*10^1+a0*10^0, a2=3, a1=4, a0=8: 3*10^2+4*10^1+8 = 348
			//an*10^n+an-1 * 10^n-1 .... + a1*10^1+a0*10^0

			//45: lg(45)=[1-2)
			//48798: lg(48798) = [4-5)

			Console.WriteLine("Введите число");
			var number = Convert.ToInt64(Console.ReadLine());
			Console.WriteLine("Введите цифру");
			var digit = Convert.ToByte(Console.ReadLine());

			var degree = (byte)Math.Log10(number);

			//258
			//258 % 10^3 / 10^2 - 2
			//258 % 10^2 / 10^1 - 5
			//258 % 10^1 / 10^0 - 8
			var isDigitExists = false;
			for (var currentDegree = 0; currentDegree <= degree; currentDegree++)
			{
				var discharge = (int)(number % Math.Pow(10, currentDegree + 1)) / (int)Math.Pow(10, currentDegree);
				if (discharge == digit)
				{
					isDigitExists = true;
					break;
				}
			}

			Console.WriteLine($"Цифра {digit} {(isDigitExists ? "" : "не")} входит в число {number}");
		}

		/// <summary>
		/// Дано число любой стпени. Определить:
		/// 1) Сумму его цифр
		/// 2) Сумму всех цифр, стоящих в нечетной степени
		/// 3) Сумму кубов цифр, стоящих в нечетной степени с разностью квадратов цифр, стоящих в четной степени 
		/// </summary>
		/// 123456 => 1^3-2^2+3^3-4^2
		public static void Func16()
		{
			Console.WriteLine("Введите число n");
			var n = Convert.ToInt32(Console.ReadLine());

			var numberOfDischarges = (int)Math.Log10(n);

			var sumOfDigits = 0;
			var sumOfOddDigits = 0;

			for (var currentDischarge = 1; currentDischarge <= numberOfDischarges + 1; currentDischarge++)
			{
				var currentDischrge = (int)(n % Math.Pow(10, currentDischarge) / Math.Pow(10, currentDischarge - 1));
				sumOfDigits += currentDischrge;
				if (currentDischarge % 2 != 0)
				{
					sumOfOddDigits += currentDischrge;
				}
			}
			Console.WriteLine($"1) Сумма цифр = {sumOfDigits};\n2) Сумма нечётных цифр = {sumOfOddDigits}");
		}

		/// <summary>
		/// Напечатать таблицу истинности, заменив true и false на 1 и 0 соотвественно
		/// X || !Y && !(X || !Z)
		/// </summary>
		/// 0 0 0
		/// 0 0 1
		/// 0 1 0 
		/// 0 1 1 
		/// 1 0 0
		/// 1 0 1
		/// 1 1 0
		/// 1 1 1
		public static void Func17()
		{
			bool x, y, z, res;

			for (var i = 1; i <= 8; i++)
			{
				x = i > 4;
				y = i == 3 || i == 4 || i == 7 || i == 8;
				z = i % 2 == 0;
				res = x || !y && !(x || !z);

				Console.WriteLine($"{(x ? 1 : 0)} {(y ? 1 : 0)} {(z ? 1 : 0)} {(res ? 1 : 0)}");
			}
		}

		#endregion

		#endregion

		#region Цикл while

		/// <summary>
		/// Дана непустая последовательность целых чисел, оканчивающаяся нулем. Найти
		/// сумму всех чисел последовательности;
		/// количество всех чисел последовательности.
		/// </summary>
		public static void Func18()
		{
			var number = 1;
			var couter = 0;
			var sum = 0;
			while (number != 0)
			{
				number = Convert.ToInt32(Console.ReadLine());
				sum += number;
				couter++;
			}
		}

		/// <summary>
		/// Найти:
		/// а) первое число в последовательности Фибоначчи, большее n(значение n вводится с клавиатуры; n > 1);
		/// б) сумму всех чисел в последовательности Фибоначчи, которые не превосходят n
		/// </summary>
		public static void Func19()
		{
			Console.WriteLine("Введите число n");
			var n = Convert.ToInt32(Console.ReadLine());

			var current = 0;
			var previous = 1;
			var prePrevious = 1;
			var k = 2;
			var sum = 2;

			while (current <= n) //1 1 2 3 5 8 13 21
			{
				current = previous + prePrevious;// 2 + 3

				prePrevious = previous;
				previous = current;
				k++; //4 5

				sum += current; //2 + 2 + 3 + 5
			}
			if (n == prePrevious)
			{
				sum -= (prePrevious + previous);
			}
			else
			{
				sum -= previous;
			}
			Console.WriteLine($"Число последовательности = {current}; порядковый номер члена {k}; сумма = {sum}");
		}

		/// <summary>
		/// Найти минимальное число, большее n, которое нацело делится на k
		/// </summary>
		public static void Func20()
		{
			Console.WriteLine("Введите число n и делитель k");
			var n = Convert.ToInt32(Console.ReadLine());
			var k = Convert.ToInt32(Console.ReadLine());

			var newNomber = n;
			while (newNomber % k != 0)
			{
				newNomber++;
			}

			Console.WriteLine($"Минимальное число, большее n, которое нацело делится на k = {newNomber}");
		}

		/// <summary>
		/// Гражданин открыл счет в банке, вложив amount руб.
		/// Через каждый месяц размер вклада увеличивается на percentage % от имеющейся суммы. Определить:
		/// а) прирост суммы вклада за n-й месяц;
		/// б) сумму вклада через n месяцев
		/// в) в каком месяце счет достигнет goalSum
		/// </summary>
		public static void Func11()
		{
			Console.WriteLine("Какая сумма вклада");
			var amout = Convert.ToDecimal(Console.ReadLine());
			Console.WriteLine("Какой процент");
			var percentage = Convert.ToDecimal(Console.ReadLine());
			Console.WriteLine("Количество месяцев");
			var n = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Желаемая сумма");
			var goalSum = Convert.ToDecimal(Console.ReadLine());

			//for (var month = 1; month <= n; month++)
			//{
			//	amout *= 1 + percentage;
			//}
			//var increase = amout - (amout / (1 + percentage));

			var counter = 0;

			while (amout < goalSum)
			{
				amout *= 1 + percentage;
				counter++;
			}
			Console.WriteLine($"Через {counter} месяцев");
		}

		/// <summary>
		/// Дано натуральное число. Определить количество цифр в нем
		/// </summary>
		public static void Func26()
		{
			var n = Convert.ToInt64(Console.ReadLine());
			var counter = 0;

			while (n != 0)
			{
				n /= 10;
				counter++;
			}

			while (true)
			{
				n /= 10;
				counter++;

				if (n == 0)
					break;
			}
			Console.WriteLine(counter);
		}

		#endregion

		#region Вложенные цыклы

		/// <summary>
		/// Напечатать числа в виде следующей таблицы:
		/// а)
		/// 1
		/// 2 2
		/// 3 3 3
		/// 4 4 4 4
		/// 5 5 5 5 5
		///
		/// б)
		/// 20 21 22 23 24
		///	19 20 21 22
		/// 18 19 20
		/// 17 18
		/// 16
		/// </summary>
		public static void Func21()
		{

		}

		/// <summary>
		/// Напечатать полную таблицу умножения в виде:
		/// 1 х 1 = 1   2 x 1 = 2   ...   9 x 1 = 9 
		/// 1 х 2 = 2   2 x 2 = 4   ...   9 x 2 = 18 
		/// ...         ...         ...   ... 
		/// 1 х 9 = 9   2 х 9 = 18  ...   9 х 9 = 81
		/// </summary>
		public static void Func22()
		{

		}

		/// <summary>
		/// Найти все трехзначные простые числа
		/// </summary>
		public static void Func23()
		{

		}

		/// <summary>
		/// Найти размеры всех прямоугольников, площадь которых равна заданному натуральному числу s и стороны которых выражены натуральными числами
		/// При этом решения, которые получаются перестановкой размеров сторон считать разными
		/// </summary>
		public static void Func24()
		{

		}

		/// <summary>
		/// Составить программу нахождения цифрового корня натурального числа. Цифровой корень данного числа получается следующим образом:
		/// Если сложить все цифры этого числа, затем все цифры найденной суммы и повторять этот процесс, то в результате будет получено однозначное число (цифра),
		/// которая и называется цифровым корнем данного числа.
		/// </summary>
		public static void Func25()
		{

		}

		#endregion

		#region Задания из файла

		/// <summary>
		/// см. №1 в файле
		/// </summary>
		public static void Exercise1()
		{

		}

		/// <summary>
		/// см. №2 в файле
		/// </summary>
		public static void Exercise2()
		{

		}

		/// <summary>
		/// см. №3 в файле
		/// </summary>
		public static void Exercise3()
		{

		}

		#endregion

	}
}
