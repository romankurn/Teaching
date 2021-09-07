using System;

namespace Lesson2
{
	public class Conditions
	{
        #region Description
		private void Description()
        {
			//and &&: cond1 && cond2 - истина только когда оба истина
			//or ||: cond1 || cond2 - истина когда одно из условий истина
			//not !: !cond - истина когда условие ложно
			//equal == : cond1 == cond2 - истина когда условия равны
			//not equal != : cond1 != cond2 - истина когда условия разные

			bool cond1 = 1 != 2;

			//1
			if(cond1)
            {
				//выполнить если истина
            }

			//2
			if (cond1)
			{
				//выполнить если истина
			}
			else
			{
				//выполнить в противном случае
			}

			int value = 1;
			switch (value)
            {
				case 1:
					Console.WriteLine(1);
					break;
				case 2:
					Console.WriteLine(1);
					break;
				case 3:
					Console.WriteLine(1);
					break;
				default:
					Console.WriteLine("нинаю");
				break;
			}

			//тернарный оператор
			var value1 = 1;
			var value2 = 2;
			var result = cond1 ? value1 : value2;

			if (cond1)
            {
				result = value1;
            }
			else
            {
				result = value2;
            }
		}
		#endregion

		#region Simple conditions

		/// <summary>
		/// Вычислить значение логического выражения при любых возможных значениях логических величин А, В и С:
		///а) не(А или не В и С) или С;
		///б) не(А и не В или С) и В;
		///в) не(не А или В и С) или А.
		/// </summary>
		public static void Func1()
		{
			Console.WriteLine("Введите значение величины А");
			var A = Convert.ToBoolean(Console.ReadLine());
			Console.WriteLine("Введите значение величины B");
			var B = Convert.ToBoolean(Console.ReadLine());
			Console.WriteLine("Введите значение величины C");
			var C = Convert.ToBoolean(Console.ReadLine());

			var result1 = !(A || !B && C) || C;
			var result2 = !(A && !B || C) && B;
			var result3 = !(!A || B && C) || A;

			Console.WriteLine($"a) {result1}");
			Console.WriteLine($"б) {result2}");
			Console.WriteLine($"в) {result3}");
		}

		/// <summary>
		/// Вычислить значение логического выражения при любых возможных значениях логических величин X, Y и Z:
		///а) не(X или Y) и(не X или не Z);
		///б) не(не X и Y) или(X и не Z);
		///в) X или не Y и не(X или не Z)
		/// </summary>
		public static void Func2()
		{
			Console.WriteLine("Введите значение величины X");
			var X = Convert.ToBoolean(Console.ReadLine());
			Console.WriteLine("Введите значение величины Y");
			var Y = Convert.ToBoolean(Console.ReadLine());
			Console.WriteLine("Введите значение величины Z");
			var Z = Convert.ToBoolean(Console.ReadLine());

			var result1 = !(X || Y) && (!X || !Z);
			var result2 = !(!X && Y) || (X && !Z);
			var result3 = X || !Y && !(X || !Z);

			Console.WriteLine($"a) {result1}");
			Console.WriteLine($"б) {result2}");
			Console.WriteLine($"в) {result3}");
		}

		/// <summary>
		/// Записать логические выражения, которые имеют значение «Истина» только при выполнении указанных условий:
		///а) x < 2 и у < 3;
		///б) неверно, что x < 2;
		///в) x < 1 или y < 2;
		///г) неверно, что x < 0 и x < 5;
		///д) x < 0 и у > 5;
		///е) 10 < x < 20;
		///ж) x > 3 или x < 1;
		///з) 0 < y < 4 и x < 5;
		///и) х > 3  и x < 10.
		/// </summary>
		public static void Func3()
		{
			Console.WriteLine("Введите значение величины X");
			var X = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите значение величины Y");
			var Y = Convert.ToDouble(Console.ReadLine());

			var result1 = X < 2 && Y < 3;
			var result2 = !(X < 2);
			var result3 = X < 1 || Y < 2;
			var result4 = !(X < 0) && X < 5;
			var result5 = X < 0 && Y > 5;
			var result6 = X > 10 && X < 20;
			var result7 = X > 3 || X < 1;
			var result8  = Y > 0 && Y < 4 && X < 5;
			var result9 = X > 3 && X < 10;

			Console.WriteLine($"а) {result1}");
			Console.WriteLine($"б) {result2}");
			Console.WriteLine($"в) {result3}");
			Console.WriteLine($"г) {result4}");
			Console.WriteLine($"д) {result5}");
			Console.WriteLine($"е) {result6}");
			Console.WriteLine($"ж) {result7}");
			Console.WriteLine($"з) {result8}");
			Console.WriteLine($"и) {result9}");
		}


		/// <summary>
		/// Записать условие, которое является истинным, когда:
		///а) каждое из чисел А и В больше 100;
		///б) только одно из чисел А и В четное;
		///в) хотя бы одно из чисел А и В положительно;
		///г) каждое из чисел А, В, С кратно трем;
		///д) только одно из чисел А, В и С меньше 50;
		///е) хотя бы одно из чисел А, В, С отрицательно.
		/// </summary>
		public static void Func5()
		{
			Console.WriteLine("Введите значение величины А");
			var A = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите значение величины B");
			var B = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите значение величины C");
			var C = Convert.ToDouble(Console.ReadLine());

			var result1 = A > 100 && B > 100;
			var result2 = A % 2 == 0 ^ B % 2 == 0;
			var result3 = A > 0 || B > 0;
			var result4 = A % 3 == 0 && B % 3 == 0 && C % 3 == 0;
			var result5 = A < 50 ^ B < 50 ^ C < 50;
			var result6 = A < 0 || B < 0 || C < 0;

			Console.WriteLine($"а) {result1}");
			Console.WriteLine($"б) {result2}");
			Console.WriteLine($"в) {result3}");
			Console.WriteLine($"г) {result4}");
			Console.WriteLine($"д) {result5}");
			Console.WriteLine($"е) {result6}");
		}

		/// <summary>
		/// Записать условие, которое является истинным, когда:
		///а) целое А кратно двум или трем;
		///б) целое А не кратно трем и оканчивается 5.
		/// </summary>
		public static void Func6()
		{
			Console.WriteLine("Введите значение величины А");
			var A = Convert.ToInt32(Console.ReadLine());

			var result1 = A % 2 ==0 || A % 3 == 0;
			var result2 = A % 3 != 0 && A % 5 == 0 && A % 10 != 0;

			Console.WriteLine($"а) {result1}");
			Console.WriteLine($"б) {result2}");
		}

		/// <summary>
		/// Записать условие, которое является истинным, когда:
		///а) целое N кратно пяти или семи;
		///б) целое N кратно четырем и не оканчивается нулем.
		/// </summary>
		public static void Func7()
		{
			Console.WriteLine("Введите значение величины А");
			var N = Convert.ToInt32(Console.ReadLine());

			var result1 = N % 5 == 0 || N % 7 == 0;
			var result2 = N % 4 == 4 && N % 10 != 0;

			Console.WriteLine($"а) {result1}");
			Console.WriteLine($"б) {result2}");
		}

		#endregion

		#region Conditional operator

		/// <summary>
		/// Даны два целых числа a и b
		/// Если a делится на b или b делится на a, то вывести yes, иначе — no. 
		/// </summary>
		public static void Func4()
		{
			Console.WriteLine("Введите а");
			var a = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите b");
			var b = Convert.ToInt32(Console.ReadLine());

			
			if (a % b == 0 || b % a == 0)
			{
				Console.WriteLine("yes");
			}
			else
			{
				Console.WriteLine("no");
			}

			Console.WriteLine(a % b == 0 || b % a == 0 ? "yes" : "no");
			
		}

		/// <summary>
		/// 
		/// В зависимости от света светофора (Красный / жёлтый / зелёный) выдать результат: 
		/// ехать / приготовиться / стоять / сфетофор сломался (если ни одно из них) 
		/// </summary>
		public static void Func18()
        {
			
			Console.WriteLine("Какой цвет?");
			var color = Console.ReadLine();

			switch (color)
			{
				case "red":
					Console.BackgroundColor = ConsoleColor.Red;
					break;
				case "yellow":
					Console.BackgroundColor = ConsoleColor.Yellow;
					break;
				case "green":
					Console.BackgroundColor = ConsoleColor.Green;
					break;
				default:
					Console.WriteLine("Светофор сломался");
					break;
			}
		}

		/// <summary>
		/// Рассчитать значение у при заданном значении х:
		///y=sin(x) при x>0 или y = cos(x) в противном случае
		/// </summary>
		public static void Func8()
		{
			Console.WriteLine("Введите значение Х");
			var X = Convert.ToDouble(Console.ReadLine());

			double Y;
			if(X > 0)
            {
				Y = Math.Sin(X);
            }
			else
            {
				Y = Math.Cos(X);
            }

			Console.WriteLine($"y = {Y}");

			Console.WriteLine($"y = {(X > 0 ? $"{Math.Sin(X)}" : $"{Math.Cos(X)}")}");
		}

		/// <summary>
		/// Определить максимальное и минимальное значения из двух различных вещественных чисел.
		/// </summary>
		public static void Func9()
		{
			Console.WriteLine("Введите число 1");
			var number1 = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите число 2");
			var number2 = Convert.ToDouble(Console.ReadLine());

			var result = number1 > number2 
				? $"{number1} > {number2}" 
				: $"{number1} < {number2}";


			var cond1 = number1 == number2;
			var value1 = $"{number1} = {number2}";
			var value2 = number1 > number2 ? $"{number1} > {number2}" : $"{number1} < {number2}";

			result = cond1 ? value1 : value2;

			result = number1 == number2 
				? $"{number1} = {number2}" 
				: (number1 > number2 
					? $"{number1} > {number2}" 
					: $"{number1} < {number2}");

			if ( number1 == number2 )
            {
				result = $"{number1} = {number2}";

			}
			else if (number1 > number2)
            {
				result = $"{number1} > {number2}";

			}
            else
            {
				result =$"{number1} < {number2}";

            }
			
			Console.WriteLine(result);

		}

		/// <summary>
		/// См задание №1 в файле .docx
		/// </summary>
		public static void Func10()
		{
			Console.WriteLine("Введите значение а");
			var a = Convert.ToDouble(Console.ReadLine());
						
			if(a < 0)
            {
				Console.WriteLine($"Y = {-a}");
            }
			else if(a >= 0 && a < 2)
            {
				Console.WriteLine($"Y = {-(a * a)}");
            }
			else
            {
				Console.WriteLine("Y = -4");

			}

			Console.WriteLine($"Y = {((a < 0) ? $"{-a}" : (a >= 0 && a < 2) ? $"{-(a * a)}" : "-4")}");
		}

		/// <summary>
		/// См задание №2 в файле .docx
		/// </summary>
		public static void Func11()
		{
			Console.WriteLine("Введите числа А, B и С");
			var A = Convert.ToDouble(Console.ReadLine());
			var B = Convert.ToDouble(Console.ReadLine());
			var C = Convert.ToDouble(Console.ReadLine());

			if(A > B && C > A)
            {
				Console.WriteLine($"Результат: A = {A * 2}; B = {B * 2}; C = {C * 2}");
			}
			else if(B > A && C > B)
            {
				var max = Math.Max(A, Math.Max(B, C));
				if(A == max)
                {
					Console.WriteLine($"Результат: A = {A * A}; B = {B}; C = {C}");
				}
				else if(B == max)
                {
					Console.WriteLine($"Результат: A = {A}; B = {B * B}; C = {C}");
				}
				else
                {
					Console.WriteLine($"Результат: A = {A}; B = {B}; C = {C * C}");
				}
			}
			else
            {
				var min = Math.Min(A, Math.Min(B, C));
				Console.WriteLine($"Результат: A = {min}; B = {min}; C = {min}");
			}
		}

		/// <summary>
		/// См задание №3 в файле .docx
		/// </summary>
		public static void Func12()
		{
			Console.WriteLine("Введите х от 0 до 50 (включительно).");
			var x = Convert.ToByte(Console.ReadLine());

			if(x >= 0 && x < 10)
            {
				Console.WriteLine($"y = {2.3 * x + Math.Sqrt(Math.Log(x) / Math.PI)}");
            }
			else if(x >= 10 && x < 20)
            {
				Console.WriteLine($"y = {Math.Pow((x + 2), 6) + x / (x + 7)}");
			}
			else if(x >= 20 && x < 30)
            {
				Console.WriteLine($"y = {60 - x + x * x}");
			}
			else if(x >= 30 && x < 40)
            {
				Console.WriteLine($"y = {Math.Pow(Math.E, Math.Sin(x)) + Math.Sqrt(Math.Abs(x - 1))}");
			}
			else
            {
				Console.WriteLine($"y = {25 * Math.Pow(x, 3) - 7}");
			}
		}

		/// <summary>
		/// Известны две скорости: одна в километрах в час, другая — в метрах в секунду. Какая из скоростей больше?
		/// </summary>
		public static void Func13()
		{
			Console.WriteLine("Введите скорость в километрах в час");
			var speed_KpH = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Введите скорость в метрах в минуту");
			var speed_MpM2 = Convert.ToDouble(Console.ReadLine());

			var speed_MpM1 = speed_KpH * 50 / 3;
			if(speed_MpM1 > speed_MpM2)
            {
				Console.WriteLine($"Скорость {speed_KpH}км/ч больше, чем {speed_MpM2}м/мин");
            }
            else
            {
				Console.WriteLine($"Скорость {speed_MpM2}м/мин больше, чем {speed_KpH}км/ч");
			}
			
		}

		/// <summary>
		/// Известны год и номер месяца рождения человека, а также год и номер месяца сегодняшнего дня (январь — 1 и т. д.).
		/// Определить возраст человека (число полных лет).
		/// В случае совпадения указанных номеров месяцев считать, что прошел полный год.
		/// </summary>
		public static void Func14()
		{
			Console.WriteLine("Введите год рождения");
			var birthYear = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите месяц рождения");
			var birtMonth = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите текущий год");
			var currentYear = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите текущий месяц");
			var currentMonth = Convert.ToInt32(Console.ReadLine());

			var diff_of_years = currentYear - birthYear;
			if(currentMonth >= birtMonth)
            {
				Console.WriteLine($"Человеку {diff_of_years} лет/год");
            }
			else
            {
				Console.WriteLine($"Человеку {diff_of_years-1} лет/год");
			}

			//показать, как это делается с DateTime
			var birthDate = new DateTime(birthYear, birtMonth, 1);
			var currentDate = DateTime.Now; //new DateTime(currentYear, currentMonth, 2);
			var diff = (int)(currentDate - birthDate).TotalDays / 365; 
		}

		/// <summary>
		/// Дано трехзначное число. Выяснить, является ли оно палиндромом, т. е. таким числом,
		/// десятичная запись которого читается одинаково слева направо и справа налево.
		/// </summary>
		public static void Func15()
		{
			var number = Convert.ToInt32(Console.ReadLine());

			//258
			//258 % 10^3 / 10^2 - 2
			//258 % 10^2 / 10^1 - 5
			//258 % 10^1 / 10^0 - 8
			var hundreds = number / 100;
			var tens = (number % 100) / 10;
			var units = number % 10;

			Console.WriteLine($"Число {((number == (units * 100 + tens * 10 + hundreds)) ? "" : "не") }является палиндромом");

			if (number == (units * 100 + tens * 10 + hundreds))
            {
				Console.WriteLine("Число является палиндромом");
            }
			else
            {
				Console.WriteLine("Число не является палиндромом");
			}

		}



		/// <summary>
		/// Работа светофора для пешеходов запрограммирована следующим образом:
		/// в начале каждого часа в течение трех минут горит зеленый сигнал, затем в течение двух минут — красный,
		/// в течение трех минут — опять зеленый и т. д.
		/// Дано вещественное число t, означающее время в минутах, прошедшее с начала очередного часа [0, infinity).
		/// Определить, сигнал какого цвета горит для пешеходов в этот момент.
		/// </summary>
		public static void Func16()
		{
			Console.WriteLine("Введите количество минут, прошедшее с начала очередного часа");
			var t = Convert.ToDouble(Console.ReadLine());

			if(t % 5 >= 3)
            {
				Console.WriteLine("Горит красный свет");
            }
           else
            {
				Console.WriteLine("Горит зелёный свет");
			}
		}

		/// <summary>
		/// Дано двузначное число. Определить:входит ли в него цифра а.
		/// </summary>
		public static void Func17()
		{
			Console.WriteLine("Введите двухзначное число");
			var number = Convert.ToByte(Console.ReadLine());
			Console.WriteLine("Введите искомую цифру");
			var a = Convert.ToByte(Console.ReadLine());

			var tens = number / 10;
			var units = number % 10;

			if(tens == a || units == a)
            {
				Console.WriteLine($"Цифра {a} входит в число {number}");
            }
			else
            {
				Console.WriteLine($"Цифра {a} не входит в число {number}");
			}
		}



		#endregion
	}
}
