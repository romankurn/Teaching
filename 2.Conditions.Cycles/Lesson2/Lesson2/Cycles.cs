﻿using System;

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

			for(var i = -10; i < b; i++)
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
			for(var i = a; i <= b; i++)
            {
				sum += i;
				counter++;
            }

			Console.WriteLine(sum / counter);
		}

		/// <summary>
		/// сумму квадратов всех целых чисел от a до b (значения a и b вводятся с клавиатуры; b>a).
		/// </summary>
		public static void Func3()
		{

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
			for( var i = 1; i <= n; i++)
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
		///в) a1 + a2, a2 + a3 …, an-1 + an;
		///г) a1 — a2, a2 — a3, …, an-1 — an;
		/// </summary>
		public static void Func8()
		{

		}

		#endregion

		#region Рекуррентные соотношения

		/// <summary>
		/// Последовательность Фибоначчи образуется так: первый и второй члены последовательности равны 1,
		/// каждый следующий равен сумме двух предыдущих (1, 1, 2, 3, 5, 8, 13, …).
		/// Дано натуральное число n (n > 3).
		///а) Найти k-й член последовательности Фибоначчи.
		///б) Получить первые n членов последовательности Фибоначчи.
		///в) Верно ли, что сумма первых n членов последовательности Фибоначчи есть четное число?
		/// </summary>
		public static void Func9()
		{
			//f(An)=An-2+An-1;

			Console.WriteLine("Какой член последовательности ищем?");
			var k = Convert.ToInt32(Console.ReadLine());

			var current = 0;
			var previous = 1;
			var prePrevious = 1;

			for(var i = 3; i <= k; i++)
            {
				current = previous + prePrevious;

				prePrevious = previous;
				previous = current;
			}
			Console.WriteLine($"k-й: {current}");
		}

		/// <summary>
		/// Одноклеточная амеба каждые 3 часа делится на 2 клетки.
		/// Определить, сколько клеток будет через n часов, если первоначально была одна амеба
		/// </summary>
		public static void Func10()
		{

		}

		/// <summary>
		/// Гражданин открыл счет в банке, вложив amount руб.
		/// Через каждый месяц размер вклада увеличивается на percentage % от имеющейся суммы. Определить:
		/// а) прирост суммы вклада за n-й месяц;
		/// б) сумму вклада через n месяцев
		/// </summary>
		public static void Func11()
		{

		}

		#endregion

		#region Посерьезнее

		/// <summary>
		/// Расчет факториала натурального числа n
		/// </summary>
		public static void Func12()
		{

		}

		/// <summary>
		/// Вычислить сумму 1! + 2! + 3! +  … + n!
		/// 1 < n <= 10
		/// без вложенных цыклов
		/// </summary>
		public static void Func13()
		{
			//TODO: Сделать красиво с использованием функций
		}

		/// <summary>
		/// Дано число любой степени. Выяснить, является ли оно палиндромом, т. е. таким числом,
		/// десятичная запись которого читается одинаково слева направо и справа налево.
		/// </summary>
		public static void Func14()
		{
			//TODO: После прохождения массивов сделать без составления нового числа
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
			for(var currentDegree = 0; currentDegree <= degree; currentDegree++)
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
		public static void Func16()
		{

		}

		/// <summary>
		/// Напечатать таблицу истинности, заменив true и false на 1 и 0 соотвественно
		/// X || !Y && !(X || !Z)
		/// </summary>
		public static void Func17()
		{

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

		}

		/// <summary>
		/// Найти:
		///а) первое число в последовательности Фибоначчи, большее n(значение n вводится с клавиатуры; n > 1);
		/// б) сумму всех чисел в последовательности Фибоначчи, которые не превосходят n
		/// </summary>
		public static void Func19()
		{

		}

		/// <summary>
		/// Найти минимальное число, большее n, которое нацело делится на k
		/// </summary>
		public static void Func20()
		{

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
