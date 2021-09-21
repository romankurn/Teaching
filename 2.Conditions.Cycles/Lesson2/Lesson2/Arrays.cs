﻿using Newtonsoft.Json;
using System;
using System.Linq;

namespace Lesson2
{
	public class Arrays
	{
		#region Description

		public static void Description()
		{
			//type[] var_name = new type[length];
			int[] array1 = new int[5];
			var array1_2 = new int[5]; // {0,0,0,0,0}
			var array1_3 = new int[5] { 1, 2, 3, 4, 5 };
			var array1_4 = new int[] { 1, 2, 3, 4, 5 };
			var array1_5 = new[] { 1, 2, 3, 4, 5 };
			int[] array1_6 = { 1, 2, 3, 4, 5 };


			for (var index = 0; index < array1.Length; index++)
			{
				array1[index] = index + 1;
			}

			for (var index = 0; index < array1.Length; index++)
			{
				Console.Write($"{array1[index]} ");
			}

			foreach (var element in array1)
			{
				Console.Write($"{element} ");
			}
		}

		#endregion

		#region Одномерные массивы

		/// <summary>
		/// Преобразовывает элементы в строке, разделенные пробелами к указанному типу данных
		/// </summary>
		/// <typeparam name="TArray"></typeparam>
		/// <param name="line"></param>
		/// <returns></returns>
		public static TArray[] ConvertStringToArray<TArray>(string line)
		{
			var jarray = line.Split(" ");

			try
			{
				return JsonConvert.DeserializeObject<TArray[]>($"[{string.Join(",", jarray.Select(a => a))}]");
			}
			catch (Exception e)
			{
				return JsonConvert.DeserializeObject<TArray[]>($"[{string.Join(",", jarray.Select(a => $"\"{a}\""))}]");
			}
		}

		public static void PrintArray<TArray>(TArray[] array)
		{
			foreach(var element in array)
			{
				Console.Write($"{element} ");
			}
		}

		#region Вывод

		/// <summary>
		/// Выводит все элементы массива.
		/// </summary>
		public static void Func1()
		{
			var arrayOfInt = ConvertStringToArray<int>(Console.ReadLine());

			foreach (var element in arrayOfInt)
			{
				Console.Write($"{element} ");
			}

			for (var index = 0; index < arrayOfInt.Length; index++)
			{
				Console.Write($"{arrayOfInt[index]} ");
			}
		}

		/// <summary>
		/// Выводит все элементы массива в обратном порядке
		/// </summary>
		public static void Func2()
		{
			var arrayOfInt = ConvertStringToArray<int>(Console.ReadLine());

			for (var index = arrayOfInt.Length - 1; index >= 0; index--)
			{
				Console.Write($"{arrayOfInt[index]} ");
			}
		}

		/// <summary>
		/// Выводит чётные элементы массива
		/// </summary>
		public static void Func3()
		{
			var arrayOfInt = ConvertStringToArray<int>(Console.ReadLine());

			for (var index = 0; index < arrayOfInt.Length; index += 2)
			{
				Console.Write($"{arrayOfInt[index]} ");
			}

			Console.WriteLine();

			var i = 0;
			foreach (var element in arrayOfInt) //[1,2,3,4,5]
			{
				if (i++ % 2 == 0)
				{
					Console.Write($"{element} ");
				}
				else
					continue;
			}
		}

		/// <summary>
		/// Выводит все элементы массива пока не встретится элемент -1
		/// </summary>
		public static void Func4()
		{

		}

		#endregion

		#region Добавление

		/// <summary>
		/// В массив добавляется элемент в конец
		/// </summary>
		public static void Func5()
		{
			Console.WriteLine("Enter elements");

			var initialArray = ConvertStringToArray<string>(Console.ReadLine());
			var newArray = new string[initialArray.Length + 1];

			Console.WriteLine("Enter new element");
			var newElement = Console.ReadLine();

			for (var i = 0; i < initialArray.Length; i++)
			{
				newArray[i] = initialArray[i];
			}
			newArray[initialArray.Length] = newElement;

			PrintArray(newArray);
		}

		/// <summary>
		/// В массив добавляется элемент в начало
		/// </summary>
		public static void Func6()
		{
			Console.WriteLine("Enter elements");

			var initialArray = ConvertStringToArray<string>(Console.ReadLine());
			var newArray = new string[initialArray.Length + 1];

			Console.WriteLine("Enter new element");
			var newElement = Console.ReadLine();

			for (var i = 0; i < initialArray.Length; i++)
			{
				newArray[i+1] = initialArray[i];
			}
			newArray[0] = newElement;

			PrintArray(newArray);
		}

		/// <summary>
		/// В массив добавляется элемент в позицию k
		/// </summary>
		public static void Func7()
		{
			Console.WriteLine("Enter elements");

			var initialArray = ConvertStringToArray<string>(Console.ReadLine());
			var newArray = new string[initialArray.Length + 1];

			Console.WriteLine("Enter new element");
			var newElement = Console.ReadLine();

			Console.WriteLine($"Enter k[0; {initialArray.Length}]");
			var k = Convert.ToInt32(Console.ReadLine());

			for (var i = 0; i < k; i++)
			{
				newArray[i] = initialArray[i];
			}
			newArray[k] = newElement;
			for (var i = k; i < initialArray.Length; i++)
			{
				newArray[i + 1] = initialArray[i];
			}

			PrintArray(newArray);
		}

		/// <summary>
		/// В массив добавляется n элементов в позицию k
		/// </summary>
		public static void Func7_2()
		{
			//[0 1 2 3 4] // a b c -> [0 1 2 a b c 3 4]
		}

		#endregion

		#region Удаление

		/// <summary>
		/// Из массива удаляется элемент с конца
		/// </summary>
		public static void Func8()
		{
			Console.WriteLine("Enter elements");

			var initialArray = ConvertStringToArray<int>(Console.ReadLine());
			var newArray = new int[initialArray.Length - 1];

			for (var i = 0; i < initialArray.Length - 1; i++)
			{
				newArray[i] = initialArray[i];
			}
			
			PrintArray(newArray);
		}

		/// <summary>
		/// Из массива удаляется элемент с начала
		/// </summary>
		public static void Func9()
		{ }

		/// <summary>
		/// Из массива удаляется элемент с позиции k
		/// </summary>
		public static void Func10()
		{
			Console.WriteLine("Enter elements");

			var initialArray = ConvertStringToArray<string>(Console.ReadLine());
			var newArray = new string[initialArray.Length - 1];
						
			Console.WriteLine($"Enter k[0; {initialArray.Length - 1}]"); // [0 1 2 3 4]
			var k = Convert.ToInt32(Console.ReadLine());

			for (var i = 0; i < k; i++)
			{
				newArray[i] = initialArray[i];
			}
			for (var i = k+1; i < initialArray.Length; i++)
			{
				newArray[i-1] = initialArray[i];
			}

			PrintArray(newArray);
		}

		/// <summary>
		/// Из массива удаляется n элементов с позиции k
		/// </summary>
		public static void Func10_2()
		{ }

		#endregion

		#region Изменение, обработка, наполнение

		/// <summary>
		/// Дано число любой степени. Выяснить, является ли оно палиндромом, т. е. таким числом,
		/// десятичная запись которого читается одинаково слева направо и справа налево.
		/// </summary>
		public static void Func14FromCycles()
		{
			//сделать без составления нового числа
		}

		/// <summary>
		/// Заменить все элементы на четной позиции числом 2, на нечетной: 1
		/// </summary>
		public static void Func11()
		{ }

		/// <summary>
		/// Заменить все положительные числа цифрой 1, отрицательные: -1
		/// </summary>
		public static void Func13()
		{ }

		/// <summary>
		/// Заменить все элементы массива суммой соседних элементов.
		/// Например [1,5,3,8,5,2,-9,100,0] -> [5,4,13,8,10,-4,102,-9,100]
		/// </summary>
		public static void Func14()
		{ }

		/// <summary>
		/// Найти минимальный и максимальный элемент массива
		/// </summary>
		public static void Func15()
		{ }

		/// <summary>
		/// Сортировка массива по возрастанию/убыванию
		/// </summary>
		public static void Func16()
		{ }

		/// <summary>
		/// Посчитать количество повторяющихся элементов в массиве
		/// [1,2,3,5,1,2,6,7,5,1] -> 3: 1,2,5
		/// </summary>
		public static void Func17()
		{ }

		/// <summary>
		/// Посчитать количество уникальных элементов в массиве
		/// </summary>
		public static void Func22()
		{ }

		/// <summary>
		/// Создание массива из двух массивов. В итоговом массиве должны быть элементы первого и второго массива
		/// </summary>
		public static void Func18()
		{

		}

		/// <summary>
		/// Даны 2 массива. Найти в первом массиве первое число, которое встречается во втором массиве.
		/// Если такого числа нет, выдать сообщение
		/// </summary>
		public static void Func19()
		{

		}

		/// <summary>
		/// Даны 2 массива. Создать массив из элементов, которые содержатся как в первом так и во втором массивах.
		/// [1,2,3,1,2,3,4,5], [11,12,13,1,1,2,4,20] -> [1,2,4]
		/// </summary>
		public static void Func20()
		{

		}

		/// <summary>
		/// Даны 2 массива. Создать третий, в котором будут не повторяющиеся элементы первого и второго массива.
		/// [1,2,3,1,2,3], [2,3,4,2,3,4] -> [1,4]
		/// </summary>
		public static void Func21()
		{

		}

		/// <summary>
		/// Даны 2 массива: массив слов и массив индексов.
		/// Остортировать первый массив, согласно индексам во втором массиве.
		/// Проверить массив индексов на корректность
		/// ["word1","word2","word3"], [3,1,2] -> ["word3","word1","word2"]
		/// </summary>
		public static void Func23()
		{

		}

		/// <summary>
		/// В первом массиве даны имена людей, во втором их возраста соотвественно.
		/// Отсортировать данные
		/// 1) По именам по алфавиту
		/// 2) По возрасту по возрастанию
		/// </summary>
		public static void Func24()
		{

		}

		#endregion

		#endregion


		#region Обработка строки как массива символов

		/// <summary>
		/// Посчитать количество цифр в строке.
		/// 1) вручную
		/// 2) с помощью char.IsDigit()
		/// 3) с помощью методов LINQ
		/// </summary>
		public static void Func25()
		{
		}

		/// <summary>
		/// Посчитать количество букв в строке.
		/// 1) вручную
		/// 2) с помощью char.IsLetter()
		/// 3) с помощью методов LINQ
		/// </summary>
		public static void Func26()
		{
		}

		/// <summary>
		/// Посчитать количество чисел в строке
		/// (если в строке "dsfg12 gdfg3 sd4567" - 7 цифр, то чисел здесь всего 3)
		/// *Показать, как это делается через LINQ
		/// </summary>
		public static void Func27()
		{
		}

		/// <summary>
		/// Посчитать количество слов в строке, считая, что слова разделены пробелами
		/// *Показать, как это делается через LINQ
		/// </summary>
		public static void Func29()
		{
		}

		/// <summary>
		/// Посчитать количество слова word, вводимого с клавиатуры, в строке
		/// *Показать, как это делается через LINQ
		/// </summary>
		public static void Func30()
		{
		}

		/// <summary>
		/// Заменить все слова в строке, начинающиеся с буква 'а' их перевертышами
		/// *Показать, как это делается через LINQ
		/// </summary>
		public static void Func31()
		{
		}

		/// <summary>
		/// Найти порядковый номер первого слова в строке, в котором встречается буква 'r'
		/// *Показать, как это делается через LINQ
		/// </summary>
		public static void Func32()
		{
		}

		/// <summary>
		/// Заменить в строке все последовательности пробелов больше 1 на 1 пробел, а пробелы в начале и конце удалить
		/// *Показать как это делается через регулярки
		/// </summary>
		public static void Func33()
		{
		}

		/// <summary>
		/// Проверить правильность открывающихся и закрывающихся круглых скобок в строке
		/// "df( sdf ( sdf ) ff ) dfg (fsdf)" - валидно.
		/// "fff)sdfsdf( sdfsd (sdf)sadf" - невалидно
		/// </summary>
		public static void Func34()
		{
		}

		/// <summary>
		/// Дана последовательность литер, имеющая следующий вид: d1+-d2+-d3+-...+-dn (где di цифра от 0 до 9).
		/// Последовательность заканчивается знаком «=».
		/// Вычислить значение алгебраической суммы.
		/// </summary>
		public static void Func35()
		{

		}

		#endregion


		#region Двумерные массивы - Comming soon...



		#endregion
	}
}
