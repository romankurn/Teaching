using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
			foreach (var element in array)
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
			Console.WriteLine("Enter elements");
			var initialArray = ConvertStringToArray<int>(Console.ReadLine());

			foreach (var element in initialArray)
			{
				if (element != -1)
				{
					Console.Write($"{element} ");
				}
				else
					break;
			}
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
				newArray[i + 1] = initialArray[i];
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
		public static void Func7_2() // как задавать массивы (форматы выносят мозг)?
		{
			Console.WriteLine("Enter elements");
			var initialArray = ConvertStringToArray<string>(Console.ReadLine());

			Console.WriteLine("Enter new elements");
			var addedArray = ConvertStringToArray<string>(Console.ReadLine());

			var newArray = new string[initialArray.Length + addedArray.Length];

			Console.WriteLine($"Enter k[0; {initialArray.Length}]");
			var k = Convert.ToInt32(Console.ReadLine());

			for (var i = 0; i < k; i++)
			{
				newArray[i] = initialArray[i];
			}
			for (var i = k; i < k + addedArray.Length; i++)
			{
				newArray[i] = addedArray[i - k]; // почему нельзя засандалить инкремент в номер элемента?
			}
			for (var i = k + addedArray.Length; i < initialArray.Length + addedArray.Length; i++)
			{
				newArray[i] = initialArray[i - addedArray.Length];
			}

			PrintArray(newArray);
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
		{
			Console.WriteLine("Enter elements");

			var initialArray = ConvertStringToArray<int>(Console.ReadLine());
			var newArray = new int[initialArray.Length - 1];

			for (var i = 0; i < initialArray.Length - 1; i++)
			{
				newArray[i] = initialArray[i + 1];
			}

			PrintArray(newArray);
		}

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
			for (var i = k + 1; i < initialArray.Length; i++)
			{
				newArray[i - 1] = initialArray[i];
			}

			PrintArray(newArray);
		}

		/// <summary>
		/// Из массива удаляется n элементов с позиции k
		/// </summary>
		public static void Func10_2()
		{
			Console.WriteLine("Enter elements");
			var initialArray = ConvertStringToArray<string>(Console.ReadLine());

			Console.WriteLine($"Сколько убраить элементов - n[1,{initialArray.Length}]");
			var n = Convert.ToInt32(Console.ReadLine()); // [0 1 2 3]

			var newArray = new string[initialArray.Length - n];

			Console.WriteLine($"С какой позиции убирать -  k[0; {initialArray.Length - n}]");
			var k = Convert.ToInt32(Console.ReadLine());

			for (var i = 0; i < k; i++)
			{
				newArray[i] = initialArray[i];
			}

			for (var i = k + n; i < initialArray.Length; i++)
			{
				newArray[i - n] = initialArray[i];
			}

			PrintArray(newArray);
		}

		#endregion

		#region Изменение, обработка, наполнение

		/// <summary>
		/// Дано число любой степени. Выяснить, является ли оно палиндромом, т. е. таким числом,
		/// десятичная запись которого читается одинаково слева направо и справа налево.
		/// </summary>
		public static void Func14FromCycles()
		{
			Console.WriteLine("Введите число n");
			var n = Convert.ToInt32(Console.ReadLine());

			var numberOfDischarges = (int)Math.Log10(n);
			var arrayOfDigits = new int[numberOfDischarges + 1];

			//589
			var newDischarge = numberOfDischarges;
			for (var i = 1; i <= numberOfDischarges + 1; i++)
			{
				var currentDischrge = (int)(n % Math.Pow(10, i) / Math.Pow(10, i - 1));//985
				arrayOfDigits[i - 1] = currentDischrge;
			}

			var result = true;
			//[0 1 2 3 4 5 6 7] 0-7 1-6 2-5 3-4
			for (var i = 0; i < arrayOfDigits.Length / 2; i++)
			{
				if (arrayOfDigits[i] != arrayOfDigits[arrayOfDigits.Length - i - 1])
				{
					result = false;
					break;
				}
			}
			Console.WriteLine($"Число {n} {(!result ? "не " : " ")}является палиндромом");
		}

		/// <summary>
		/// Заменить все элементы на четной позиции числом 2, на нечетной: 1
		/// </summary>
		public static void Func11()
		{
			Console.WriteLine("Enter elements");
			var initialArray = ConvertStringToArray<string>(Console.ReadLine());

			for (var i = 0; i < initialArray.Length; i++)
			{
				if (i % 2 == 0)
				{
					initialArray[i] = "2";
				}
				else
				{
					initialArray[i] = "1";
				}
			}
			PrintArray(initialArray);
		}

		/// <summary>
		/// Заменить все положительные числа цифрой 1, отрицательные: -1
		/// </summary>
		public static void Func13()
		{
			Console.WriteLine("Enter elements");
			var initialArray = ConvertStringToArray<int>(Console.ReadLine());

			for (var i = 0; i < initialArray.Length; i++)
			{
				if (initialArray[i] >= 0)
				{
					initialArray[i] = 1;
				}
				else
				{
					initialArray[i] = -1;
				}
			}
			PrintArray(initialArray);
		}
		/// <summary>
		/// Заменить все элементы массива суммой соседних элементов.
		/// Например [1,5,3,8,5,2,-9,100,0] -> [5,4,13,8,10,-4,102,-9,100]
		/// </summary>
		public static void Func14() //hw
		{
			var sourceArray = new int[] { 1, 5, 3, 8, 5, 2, -9, 100, 0 };

			var modifiedArray = new int[sourceArray.Length];
			modifiedArray[0] = sourceArray[1];
			for (var i = 1; i < sourceArray.Length - 1; i++)
			{
				modifiedArray[i] = sourceArray[i - 1] + sourceArray[i + 1];
			}
			modifiedArray[sourceArray.Length - 1] = sourceArray[sourceArray.Length - 2];

			PrintArray(modifiedArray);
		}

		/// <summary>
		/// Найти минимальный и максимальный элемент массива
		/// </summary>
		public static void Func15()
		{
			Console.WriteLine($"Введите набор значений");
			var array = ConvertStringToArray<int>(Console.ReadLine());
			//[1 6 2 0 8 1 8 2 9 15 2 8]

			var max = array[0];
			var min = array[0];
			for (var i = 1; i < array.Length; i++)
			{
				if (array[i] > max)
				{
					max = array[i];
				}
				if (array[i] < min)
				{
					min = array[i];
				}
			}

			Console.WriteLine($"Max = {max}\nMin = {min}");

			max = array.Max();
			min = array.Min();
		}

		/// <summary>
		/// Сортировка массива по возрастанию/убыванию
		/// </summary>
		public static void Func16()
		{
			Console.WriteLine("Enter elements");
			var initialArray = ConvertStringToArray<int>(Console.ReadLine());

			// возрастание
			var transit = 0;
			for (var i = 0; i < initialArray.Length - 1; i++)
			{
				for (var j = i + 1; j < initialArray.Length; j++)
				{
					if (initialArray[i] > initialArray[j])
					{
						transit = initialArray[j];
						initialArray[j] = initialArray[i];
						initialArray[i] = transit;
					}
				}
			}
			PrintArray(initialArray);
			Console.WriteLine();

			Array.Sort(initialArray);
			initialArray = initialArray.Reverse().ToArray();

			PrintArray(initialArray);
		}

		/// <summary>
		/// Посчитать количество повторяющихся элементов в массиве
		/// [1,2,3,5,1,2,6,7,5,1] -> 3: 1,2,5
		/// </summary>
		public static void Func17()
		{
			Console.WriteLine("Enter elements");
			var initialArray = ConvertStringToArray<int>(Console.ReadLine());

			var newArray = new int[initialArray.Length / 2];
			Array.Sort(initialArray);
			var counter = 0;
			for (var i = 0; i < initialArray.Length - 1; i++)
			{
				if (initialArray[i] == initialArray[i + 1]) // [1 1 1 1 2 3 3 4 5 5 8]
				{
					newArray[counter++] = initialArray[i];
				}
				while (initialArray[i] == initialArray[i + 1])
				{
					i++;
				}
			}
			var repeatedArray = newArray.Take(counter).ToArray();
			Console.Write($"{counter}: ");
			PrintArray(repeatedArray);
		}

		/// <summary>
		/// Посчитать количество уникальных элементов в массиве
		/// </summary>
		public static void Func22() //hw
		{
			Console.WriteLine("Enter elements");
			var initialArray = ConvertStringToArray<string>(Console.ReadLine());

			var counter = 0;
			var elementIsUnique = true;
			var nonUniqueElements = new string[initialArray.Length / 2];
			var amountOfnonUniqueElements = 0;

			for (var i = 0; i < initialArray.Length; i++)
			{
				for (var k = 0; k < amountOfnonUniqueElements; k++)
				{
					if (initialArray[i] == nonUniqueElements[k])
					{
						elementIsUnique = false;
						break;
					}
				}
				if (elementIsUnique == true)
				{
					for (var j = i + 1; j < initialArray.Length; j++)
					{
						if (initialArray[i] == initialArray[j])
						{
							elementIsUnique = false;
							nonUniqueElements[amountOfnonUniqueElements++] = initialArray[i];
							break;
						}
					}
				}
				if (elementIsUnique == true)
				{
					counter++;
				}
				else
				{
					elementIsUnique = true;
				}
			}
			Console.WriteLine($"Number of unique elements is {counter}");

			var uniqueCount = initialArray.Distinct().Count();
		}

		/// <summary>
		/// Создание массива из двух массивов. 
		/// В итоговом массиве должны быть элементы первого и второго массива
		/// </summary>
		public static void Func18()
		{
			Console.WriteLine("Enter elements of the first array");
			var firstArray = ConvertStringToArray<string>(Console.ReadLine());
			Console.WriteLine("Enter elements of the second array");
			var secondlArray = ConvertStringToArray<string>(Console.ReadLine());

			var sumOfArrays = new string[firstArray.Length + secondlArray.Length];
			var nomberOfElements = 0;
			foreach (var element in firstArray)
			{
				sumOfArrays[nomberOfElements++] = element;
			}
			foreach (string element in secondlArray)
			{
				sumOfArrays[nomberOfElements++] = element;
			}
			PrintArray(sumOfArrays);

			var newArray = firstArray.Union(secondlArray).ToArray();
		}

		/// <summary>
		/// Даны 2 массива. Найти в первом массиве первое число, которое встречается во втором массиве.
		/// Если такого числа нет, выдать сообщение
		/// [1 2 3 4 5] [10 11 12 5 4 3 ] -> 3
		/// </summary>
		public static void Func19()
		{
			Console.WriteLine("Enter elements for firstArray");
			var firstArray = ConvertStringToArray<int>(Console.ReadLine());

			Console.WriteLine("Enter elements for secondArray");
			var secondArray = ConvertStringToArray<int>(Console.ReadLine());

			var common = 0;
			var found = false;
			for (var i = 0; i < firstArray.Length; i++)
			{
				for (var j = 0; j < secondArray.Length; j++)
				{
					if (firstArray[i] == secondArray[j])
					{
						common = firstArray[i];
						found = true;
						break;
					}
				}
				if (found)
					break;
			}
			if (!found)
			{
				Console.WriteLine("Not found");
			}
			else
			{
				Console.WriteLine(common);
			}
		}


		/// <summary>
		/// Даны 2 массива. Создать массив из элементов, которые содержатся как в первом
		/// так и во втором массивах.
		/// [1,2,3,1,2,3,4,5], [11,12,13,1,1,2,4,20] -> [1,2,4]
		/// </summary>
		public static void Func20() // не доделан
		{
			Console.WriteLine("Enter elements of the first array");
			var firstArray = ConvertStringToArray<string>(Console.ReadLine());
			Console.WriteLine("Enter elements of the second array");
			var secondlArray = ConvertStringToArray<string>(Console.ReadLine());

			var arrayOfCommonElements = new string[Math.Min(firstArray.Length, secondlArray.Length)];
			var nomberOfCommonElements = 0;
			var elementIsUnique = true;
			var verifiedElements = new string[Math.Min(firstArray.Length, secondlArray.Length)];
			var amountOfVerifiedElements = 0;

			for (var i = 0; i < firstArray.Length; i++)
			{
				for (var k = 0; k < amountOfVerifiedElements; k++)
				{
					if (firstArray[i] == verifiedElements[k])
					{
						elementIsUnique = false;
						break;
					}
				}
				if (elementIsUnique == true)
				{
					verifiedElements[amountOfVerifiedElements++] = firstArray[i];

					for (var j = 0; j < secondlArray.Length; j++)
					{
						if (firstArray[i] == secondlArray[j])
						{
							arrayOfCommonElements[nomberOfCommonElements++] = firstArray[i];
						}
					}
				}
				else
				{
					elementIsUnique = true;
				}
			}
			PrintArray(arrayOfCommonElements);

			var commonElements = new List<string>();
			commonElements = firstArray.Where(first => secondlArray.Contains(first)).ToList();
		}

		/// <summary>
		/// Даны 2 массива. Создать третий, в котором будут не повторяющиеся элементы первого и второго массива.
		/// [1,2,3,1,2,3], [2,3,4,2,3,4] -> [1,4]
		/// </summary>


		// 0 1 2 1 2 3 a v 54
		// 1 1 4 2 3 b a a 54 9 8
		public static void Func21() //hw
		{
			Console.WriteLine("Enter elements of the first array");
			var firstArray = ConvertStringToArray<string>(Console.ReadLine());
			Console.WriteLine("Enter elements of the second array");
			var secondlArray = ConvertStringToArray<string>(Console.ReadLine());

			var elementIsUnique = true;
			var verifiedElements = new string[Math.Max(firstArray.Length, secondlArray.Length)];
			var amountOfVerifiedElements = 0;
			var newArray = new string[firstArray.Length + secondlArray.Length];
			var amountOfUniqueElements = 0;


			for (var i = 0; i < firstArray.Length; i++)
			{
				for (var k = 0; k < amountOfVerifiedElements; k++)
				{
					if (firstArray[i] == verifiedElements[k])
					{
						elementIsUnique = false;
						break;
					}
				}
				if (elementIsUnique == true)
				{
					verifiedElements[amountOfVerifiedElements++] = firstArray[i];

					for (var j = 0; j < secondlArray.Length; j++)
					{
						if (firstArray[i] == secondlArray[j])
						{
							elementIsUnique = false;
							break;
						}
					}
				}
				if (elementIsUnique == true)
				{
					newArray[amountOfUniqueElements++] = firstArray[i];
				}
				else
				{
					elementIsUnique = true;
				}
			}

			for (var j = 0; j < secondlArray.Length; j++)
			{
				for (var k = 0; k < amountOfVerifiedElements; k++)
				{
					if (secondlArray[j] == verifiedElements[k])
					{
						elementIsUnique = false;
						break;
					}
				}
				if (elementIsUnique == true)
				{
					verifiedElements[amountOfVerifiedElements++] = secondlArray[j];

					for (var i = 0; i < firstArray.Length; i++)
					{
						if (secondlArray[j] == firstArray[i])
						{
							elementIsUnique = false;
							break;
						}
					}
				}
				if (elementIsUnique == true)
				{
					newArray[amountOfUniqueElements++] = secondlArray[j];
				}
				else
				{
					elementIsUnique = true;
				}
			}

			PrintArray(newArray);

			var firstUniqueElement = firstArray.Except(secondlArray).ToArray();
			var secondUniqueElements = secondlArray.Except(firstArray).ToArray();
			var uniqueElements = firstUniqueElement.Union(secondUniqueElements).ToArray();
		}

		/// <summary>
		/// Даны 2 массива: массив слов и массив индексов.
		/// Остортировать первый массив, согласно индексам во втором массиве.
		/// Проверить массив индексов на корректность
		/// ["word0","word1","word2"], [2,0,1] -> ["word2","word0","word1"]
		/// </summary>
		public static void Func23()
		{
			Console.WriteLine("Enter elements for firstArray");
			var wordsArray = ConvertStringToArray<string>(Console.ReadLine());

			Console.WriteLine("Enter elements for secondArray");
			var indexesArray = ConvertStringToArray<int>(Console.ReadLine());

			#region validation
			if (indexesArray.Length != wordsArray.Length)
			{
				Console.WriteLine("indexes are not valid");
				return;
			}

			for (var i = 0; i < indexesArray.Length - 1; i++)
			{
				for (var j = i + 1; j < indexesArray.Length; j++)
				{
					if (indexesArray[i] == indexesArray[j])
					{
						Console.WriteLine("indexes are not valid");
						return;
					}
				}
			}

			var sortedIndexesArray = new int[indexesArray.Length];
			for (var i = 0; i < indexesArray.Length; i++)
			{
				sortedIndexesArray[i] = indexesArray[i];
			}

			Array.Sort(sortedIndexesArray);

			if (sortedIndexesArray[0] != 0 || sortedIndexesArray[indexesArray.Length - 1] != sortedIndexesArray.Length - 1)
			{
				Console.WriteLine("indexes are not valid");
				return;
			}
			#endregion

			var modifiedWordArray = new string[wordsArray.Length];
			//var transit = "";
			for (var i = 0; i < wordsArray.Length; i++)
			{
				modifiedWordArray[i] = wordsArray[indexesArray[i]];
			}

			PrintArray(modifiedWordArray);
		}

		/// <summary>
		/// В первом массиве даны имена людей, во втором их возраста соотвественно.
		/// Отсортировать данные
		/// 1) По именам по алфавиту
		/// 2) По возрасту по возрастанию
		/// </summary>
		public static void Func24() //hw
		{
			Console.WriteLine("Enter names");
			var namesArray = ConvertStringToArray<string>(Console.ReadLine());
			Console.WriteLine("Enter ages");
			var agesArray = ConvertStringToArray<int>(Console.ReadLine());

			//O(n) + O(n^2) + O(n^2) + O(n) => 2(n^2+n)

			for (var i = 0; i < namesArray.Length - 1; i++)
			{
				for (var j = i + 1; j < namesArray.Length; j++)
				{
					if (namesArray[i].CompareTo(namesArray[j]) >= 0)
					{
						var wordTransit = namesArray[i];
						namesArray[i] = namesArray[j];
						namesArray[j] = wordTransit;

						var ageTransit = agesArray[i];
						agesArray[i] = agesArray[j];
						agesArray[j] = ageTransit;
					}
				}
			}
		}

		#endregion

		#endregion


		// https://metanit.com/sharp/tutorial/7.1.php
		#region Обработка строки как массива символов

		/// <summary>
		/// Дана страка. Выяснить, является ли она палиндромом
		/// </summary>
		public static bool Func14FromCyclesForString(string initialString)
		{
			var result = true;
			for (var i = 0; i < initialString.Length / 2; i++)
			{
				if (initialString[i] != initialString[initialString.Length - i - 1])
				{
					result = false;
					break;
				}
			}
			return result;
		}

		/// <summary>
		/// Посчитать количество цифр в строке.
		/// 1) вручную
		/// 2) с помощью char.IsDigit()
		/// 3) с помощью методов LINQ
		/// </summary>
		public static int Func25(string str)
		{
			var digits = "0123456789".ToCharArray();
			var counter = 0;
			foreach (var element in str)
			{
				if (digits.Contains(element))
				{
					counter++;
				}
			}

			//foreach (var element in str)
			//{
			//	if (char.IsDigit(element))
			//		counter++;
			//}

			return counter;
		}

		/// <summary>
		/// Посчитать количество букв в строке.
		/// 2) с помощью char.IsLetter()
		/// </summary>
		public static int Func26(string str) //hw
		{
			var counter = 0;

			foreach (var element in str)
			{
				if (char.IsLetter(element))
					counter++;
			}

			counter = str.Count(element => char.IsLetter(element));
			return counter;
		}

		/// <summary>
		/// Посчитать количество чисел в строке
		/// (если в строке "dsfg12 gdfg3 sd4567" - 7 цифр, то чисел здесь всего 3)
		/// 1) вручную - hw
		/// Показать, как это делается через LINQ
		/// </summary>
		public static int Func27(string line)
		{
			for (var i = 0; i < line.Length; i++)
			{
				if (!char.IsDigit(line[i]))
				{
					line = line.Replace(line[i], ' ');
				}
			}
			return Func29(line);
		}

		/// <summary>
		/// Посчитать количество слов в строке, считая, что слова разделены пробелами
		/// *Показать, как это делается через LINQ
		/// </summary>
		public static int Func29(string str)
		{
			//str = Func33(str);

			//var counter = 1;
			//foreach (var element in str)
			//{
			//	if (element == ' ')
			//	{
			//		counter++;
			//	}
			//}
			//return counter;

			var words = str.Split(" ");
			var res = words.Count(w => w != string.Empty);

			return res;
		}

		/// <summary>
		/// Посчитать количество слова word, вводимого с клавиатуры, в строке
		/// *Показать, как это делается через LINQ (Count, Contains)
		/// </summary>
		public static int Func30(string str, string word) //hw
		{
			str = Func33(str);
			var words = str.Split(' ');
			var counter = words.Count(w => w == word);

			return counter;

			//word dfg word2 -> 1
		}

		/// <summary>
		/// Заменить все слова в строке, начинающиеся с буква 'а' их перевертышами
		/// *Показать, как это делается через LINQ 
		/// </summary>
		public static string Func31(string str) //hw
		{
			str = Func33(str);
			var words = str.Split(' ');
			for (var wordIndex = 0; wordIndex < words.Length; wordIndex++)
			{
				if (words[wordIndex][0] == 'a')
				{
					char[] letters = words[wordIndex].ToCharArray();
					Array.Reverse(letters);
					words[wordIndex] = new string(letters);
					words[wordIndex] = words[wordIndex] + " ";
				}
				else
				{
					words[wordIndex] = words[wordIndex] + " ";
				}
			}
			str = String.Concat(words);

			words = str.Split(' ');
			var word = words.FirstOrDefault(w => w.StartsWith('a') || w.StartsWith('A'));
			var reverse = new string(word?.Reverse().ToArray());
			str = reverse != null ? str.Replace(word, reverse) : str;

			return str;

			// .Reverse
		}

		/// <summary>
		/// Найти порядковый номер первого слова в строке, в котором встречается буква 'r'
		/// *Показать, как это делается через LINQ
		/// </summary>
		public int Func32(string str) //hw
		{
			var words = Func33(str).Split(' ');

			var word = words.FirstOrDefault(w => w.Contains('r'));

			if (word == null)
				return -1;

			var index = 0;
			foreach(var w in words)
			{
				if (w == word)
					break;
				index++;
			}

			return index;
		}

		/// <summary>
		/// Заменить в строке все последовательности пробелов больше 1 на 1 пробел, а пробелы в начале и конце удалить
		/// *Показать как это делается через регулярки
		/// </summary>
		public static string Func33(string str)
		{
			str = str.Trim();
			var count = 0;
			var startIndex = 0;
			for (var i = 0; i < str.Length; i++)
			{
				if (str[i] == ' ' && str[i + 1] == ' ')
				{
					count = 0;
					startIndex = i;
					while (true)
					{
						if (str[++i] != ' ')
							break;

						count++;
					}
					str = str.Remove(startIndex, count);
					i -= count;
				}
			}
			//sdfs     sdf
			//str = str.Remove(startIndex, count);
			return str;
		}

		/// <summary>
		/// Проверить правильность открывающихся и закрывающихся круглых скобок в строке
		/// "df( sdf ( sdf ) ff ) dfg (fsdf)" - валидно.
		/// "fff)(sdfsdf( sdfsd (sdf)sadf" - невалидно
		/// </summary>
		public static bool Func34(string str)
		{
			var conter = 0;
			foreach (var element in str)
			{
				if (element == '(')
					conter++;
				if (element == ')')
				{
					conter--;
					if (conter < 0)
						return false;
				}
			}
			return conter == 0;
		}

		/// <summary>
		/// Дана последовательность литер, имеющая следующий вид: d1+-d2+-d3+-...+-dn (где di цифра от 0 до 9).
		/// Последовательность заканчивается знаком «=».
		/// Вычислить значение алгебраической суммы.
		/// </summary>
		public static void Func35() //hw
		{

		}

		#endregion


		#region Двумерные массивы

		public void ArrayOfArraysDescription()
		{
			int[][] matrix = new int[5][];
			matrix[0] = new int[3];
			matrix[1] = new int[1];
			//..
			//	..
			//	..
			//matrix[row-1] = new int[column];

			var matrix2 = new int[5][];

			int[][] matrix3 = { new[] { 1, 2, 3 }, new[] { 11, 12, 13 } };

			foreach (var row in matrix3)
			{
				foreach (var element in row)
				{
				}
			}

			for (var rowIndex = 0; rowIndex < matrix3.Length; rowIndex++)
			{
				for (var columnIndex = 0; columnIndex < matrix3[rowIndex].Length; columnIndex++)
				{

				}
			}
		}

		/// <summary>
		/// Заполнить матрицу размера rows*columns рандомными числами от min до max 
		/// </summary>
		/// <param name="rows"></param>
		/// <param name="columns"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		public static int[][] CreateMatrix(int rows, int columns, int min, int max)
		{
			var random = new Random();

			var matrix = new int[rows][];
			for (var rowIndex = 0; rowIndex < rows; rowIndex++)
			{
				matrix[rowIndex] = new int[columns];
				for (var columnIndex = 0; columnIndex < matrix[rowIndex].Length; columnIndex++)
				{
					matrix[rowIndex][columnIndex] = random.Next(min, max + 1);
				}
			}

			return matrix;
		}

		public static char[][] CreateMatrix(int rows, int columns)
		{
			var matrix = new char[rows][];
			for (var rowIndex = 0; rowIndex < rows; rowIndex++)
			{
				matrix[rowIndex] = new char[columns];
			
			}

			return matrix;
		}

		/// <summary>
		/// Напечатать двумерный массив
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="matrix"></param>
		public static void PrintMatrix<T>(T[][] matrix)
		{
			foreach (var row in matrix)
			{
				foreach (var element in row)
				{
					Console.Write($"{element}\t");
				}
				Console.WriteLine();
			}
		}

		/// <summary>
		/// Создать двумерный массив вида:
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
		///
		/// в)
		/// 1
		/// 4
		/// 1 2 3
		/// 16
		/// 1 2 3 4 5
		/// 36
		/// 1 2 3 4 5 6 7
		/// 64
		/// 1 2 3 4 5 6 7 8 9
		/// 100
		/// 
		/// 1
		/// 2^2
		/// 1 2 3
		/// 4^2
		/// 1 2 3 4 5
		/// 6^2
		/// 1 2 3 4 5 6 7
		/// 8^2
		/// 
		/// </summary>
		public static void Func21FromCycles() // To do left tasks
		{
			//var matrix = new int[5][];
			//for (var rowIndex = 0; rowIndex < 5; rowIndex++)
			//{
			//	matrix[rowIndex] = new int[rowIndex + 1];
			//	for (var columnIndex = 0; columnIndex < matrix[rowIndex].Length; columnIndex++)
			//	{
			//		matrix[rowIndex][columnIndex] = rowIndex + 1;
			//	}
			//}
			//PrintMatrix(matrix);

			//б
			//var matrix2 = new int[5][];
			//var rowLenght = 5;
			//var matrix2Element = 20;

			//for (var rowIndex = 0; rowIndex < 5; rowIndex++)
			//{
			//	matrix2[rowIndex] = new int[rowLenght--];
			//	for (var columnIndex = 0; columnIndex < matrix2[rowIndex].Length; columnIndex++)
			//	{
			//		matrix2[rowIndex][columnIndex] = matrix2Element + columnIndex;
			//	}
			//	matrix2Element--;
			//}
			//PrintMatrix(matrix2);

			// в 
			var matrix3 = new int[10][];
			var oddRowElement = 4;
			var oddRowElementGrowth = 12;

			for (var rowIndex = 0; rowIndex <= matrix3.Length - 1; rowIndex++)
			{
				if (rowIndex % 2 == 0)
				{
					matrix3[rowIndex] = new int[rowIndex + 1];
					for (var columnIndex = 0; columnIndex <= rowIndex; columnIndex++)
					{
						matrix3[rowIndex][columnIndex] = columnIndex + 1;
					}

				}
				else
				{
					matrix3[rowIndex] = new int[1];
					matrix3[rowIndex][0] = oddRowElement;
					oddRowElement += oddRowElementGrowth;
					oddRowElementGrowth += 8;
				}
			}
			PrintMatrix(matrix3);
		}

		/// <summary>
		/// Отсортировать четные столбцы по возрастанию
		/// нечетные - по убыванию
		/// </summary>
		public static void MatrixFunc1() //To think about realisation
		{
			Console.Write("Enter number of rows: ");
			var numberOfRows = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter number of columns: ");
			var numberOfColumns = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter min value: ");
			var minValue = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter max value: ");
			var maxValue = Convert.ToInt32(Console.ReadLine());

			var matrix = CreateMatrix(numberOfRows, numberOfColumns, minValue, maxValue);

			Console.WriteLine("Original Matrix:");
			PrintMatrix(matrix);
			Console.WriteLine();

			var sortedMatrix = new int[numberOfRows][]; // это можно опустить и сложить отсортированные элементы прямо в исходную матрицу
			for (var rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
			{
				sortedMatrix[rowIndex] = new int[numberOfColumns];
			}

			var sortableColumn = new int[numberOfRows];
			for (var columnIndex = 0; columnIndex < matrix[0].Length; columnIndex++)
			{
				if (columnIndex % 2 == 0)
				{
					for (var rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
					{
						sortableColumn[rowIndex] = matrix[rowIndex][columnIndex];
					}
					sortableColumn = sortableColumn.OrderBy(element => element).ToArray();
					for (var rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
					{
						sortedMatrix[rowIndex][columnIndex] = sortableColumn[rowIndex];
					}
				}
				else
				{
					for (var rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
					{
						sortableColumn[rowIndex] = matrix[rowIndex][columnIndex];
					}
					sortableColumn = sortableColumn.OrderByDescending(element => element).ToArray();
					for (var rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
					{
						sortedMatrix[rowIndex][columnIndex] = sortableColumn[rowIndex];
					}
				}
			}
			Console.WriteLine("Sorted Matrix:");
			PrintMatrix(sortedMatrix);


			//var sortedElement = 0;
			//for (var columnIndex = 0; columnIndex < numberOfRows; columnIndex++)
			//{
			//	for(var rowIndex = 0; rowIndex < numberOfColumns; rowIndex++)
			//	{
			//		for()
			//		sortedElement
			//	}
			//}
		}

		/// <summary>
		/// Отсортировать все элементы матрицы по возрастанию
		/// </summary>
		public static void MatrixFunc2()
		{
			Console.Write("Enter number of rows: ");
			var numberOfRows = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter number of columns: ");
			var numberOfColumns = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter min value: ");
			var minValue = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter max value: ");
			var maxValue = Convert.ToInt32(Console.ReadLine());

			var matrix = CreateMatrix(numberOfRows, numberOfColumns, minValue, maxValue);
			var elementCount = 0;
			var counter = 0;

			foreach (var row in matrix)
			{
				elementCount += row.Length;
			}
			var allMatrixElements = new int[elementCount];
			//var allMatrixElements1 = new int[matrix.Sum(row => row.Length)];

			foreach (var row in matrix)
			{
				foreach (var element in row)
				{
					allMatrixElements[counter++] = element;
				}
			}

			//var allMatrixElements1 = matrix.SelectMany(element => element).ToArray();

			allMatrixElements = allMatrixElements.OrderBy(element => element).ToArray();

			counter = 0;
			for (var rowNumber = 0; rowNumber < matrix.Length; rowNumber++)
			{
				for (var columnNumber = 0; columnNumber < matrix[rowNumber].Length; columnNumber++)
				{
					matrix[rowNumber][columnNumber] = allMatrixElements[counter++];
				}
			}
			PrintMatrix(matrix);
		}

		/// <summary>
		/// Поменять местами макимальный элемент первой матрицы
		/// с минимальным элементом второй матрицы
		/// </summary>
		public static void MatrixFunc8()
		{
			Console.Write("Enter number of rows for first matrix: ");
			var numberOfRows = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter number of columns for first matrix: ");
			var numberOfColumns = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter min value for first matrix: ");
			var minValue = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter max value for first matrix: ");
			var maxValue = Convert.ToInt32(Console.ReadLine());

			var firstMatrix = CreateMatrix(numberOfRows, numberOfColumns, minValue, maxValue);

			Console.Write("Enter number of rows for second matrix: ");
			numberOfRows = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter number of columns for second matrix: ");
			numberOfColumns = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter min value for second matrix: ");
			minValue = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter max value for second matrix: ");
			maxValue = Convert.ToInt32(Console.ReadLine());

			var secondMatrix = CreateMatrix(numberOfRows, numberOfColumns, minValue, maxValue);

			PrintMatrix(firstMatrix);
			Console.WriteLine();
			PrintMatrix(secondMatrix);

			var firstMax = firstMatrix.SelectMany(element => element).Max();
			var secondMin = secondMatrix.SelectMany(element => element).Min();

			Console.WriteLine($"firstMax: {firstMax}, secondMin: {secondMin}");


			for (var rowNumber = 0; rowNumber < firstMatrix.Length; rowNumber++)
			{
				for (var columnNumber = 0; columnNumber < firstMatrix[rowNumber].Length; columnNumber++)
				{
					if (firstMatrix[rowNumber][columnNumber] == firstMax)
					{
						firstMatrix[rowNumber][columnNumber] = secondMin;
					}
				}
			}
			for (var rowNumber = 0; rowNumber < secondMatrix.Length; rowNumber++)
			{
				for (var columnNumber = 0; columnNumber < secondMatrix[rowNumber].Length; columnNumber++)
				{
					if (secondMatrix[rowNumber][columnNumber] == secondMin)
					{
						secondMatrix[rowNumber][columnNumber] = firstMax;
					}
				}
			}
			Console.WriteLine();
			PrintMatrix(firstMatrix);
			Console.WriteLine();
			PrintMatrix(secondMatrix);
		}

		/// <summary>
		/// Поменять местами столбцы с макимальным и минимальным элемантами
		/// </summary>
		public static void MatrixFunc7() // To think about realisation
		{

		}

		/// <summary>
		/// Транспонировать матрицу
		/// </summary>
		public static void MatrixFunc3() //to do realisation
		{
			Console.Write("Enter number of rows: ");
			var numberOfRows = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter number of columns: ");
			var numberOfColumns = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter min value: ");
			var minValue = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter max value: ");
			var maxValue = Convert.ToInt32(Console.ReadLine());

			var matrix = CreateMatrix(numberOfRows, numberOfColumns, minValue, maxValue);

			Console.WriteLine("Original Matrix:");
			PrintMatrix(matrix);
			Console.WriteLine();


			var transposedMatrix = new int[numberOfColumns][];
			for (var rowIndex = 0; rowIndex < numberOfColumns; rowIndex++)
			{
				transposedMatrix[rowIndex] = new int[numberOfRows];
				for (var columnIndex = 0; columnIndex < numberOfRows; columnIndex++)
				{
					transposedMatrix[rowIndex][columnIndex] = matrix[columnIndex][rowIndex];
				}
			}

			Console.WriteLine("Transposed Matrix:");
			PrintMatrix(transposedMatrix);
		}

		/// <summary>
		/// Составить массив из максимальных элементов каждого столбца матрицы
		/// Получинным массивом заменить строку с минимальным элементом
		/// </summary>
		public static void MatrixFunc4()
		{

		}

		/// <summary>
		/// Составить массив произведений диагоналей квадратной матрицы нечетной размерности
		/// Полученным массивом заменить среднюю строку и средний столбец
		/// </summary>
		public static void MatrixFunc5()
		{

		}

		/// <summary>
		/// Выполнить преобразование над матрицей (см файл)
		/// в которой размерности кратны 3
		/// </summary>
		public static void MatrixFunc6()
		{

		}

		#endregion
	}
}
