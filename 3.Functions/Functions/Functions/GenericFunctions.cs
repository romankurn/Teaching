using Lesson2;
using System;

namespace Functions
{
	/// <summary>
	/// 1. Реализовать обобщенные функции для поиска мин и макс значения .MinCustom, .MaxCustom
	/// в массиве с касотмной функцией сравнения
	///
	/// 2. Реализовать функцию фильтрацию элементов массива .Filter
	/// с кастомной функцией условия
	///
	/// 3. Реализовать обобщенную функцию сортировки массива .Sort									done
	/// с кастомной функцией сравнения <TArray, TArray, int>
	///
	/// 4. Реализовать обобщенную функцию перемешки массива .Mix
	///
	/// 5. Реализовать обобщенную функцию вывода массива .PrintWhere
	/// c кастомной функцией условия <TArray, bool>
	///
	/// 6. Реализовать обобщенную функцию добавления элемента в массив .AddAfter					done
	/// после первого элемента, удовлетворяющего условию кастомной функции <TArray, bool>
	///
	/// 7. Реализовать обобщенную функцию удаления элемента(ов) из массива .RemoveWhere				done
	/// с кастомной функцией условия <TArray, bool>
	///
	/// 8. Реализовать обобщенную функцию подсчета количества элементов в массиве .CountWhere
	/// с кастомной функцией условия <TArray, bool>
	///
	/// 9. Реализовать функцию .IndexesOfWhere, возвращающую индексы элементов обобщенного массива	hw
	/// с кастомной функцией фильтрации <TArray, bool>
	///
	/// 10. Реализовать рекурсивную обобщенную функцию суммирования .SumRec							DONE
	/// элементов массива с кастомной функцией сложения <TArray, TArray, T2Array>
	/// 
	/// 11. Реализовать рекурсивную обобщенную функцию поиска минимума .MinRec
	/// элементов массива с кастомной функцией минимума
	/// </summary>
	public static class GenericFunctions
	{

		public static void Function1()
		{
			var array1 = new[] { "aaa", "ccc", "ddd", "bbb" };
			var array2 = new[] { "3", "1,0", "4", "2" };


			var result1 = GenericFunctions.MinCustom(array1, (a, b) => a.CompareTo(b));
			var result2 = GenericFunctions.MinCustom(array2, (a, b) =>
			{
				var double1 = double.Parse(a);
				var double2 = double.Parse(b);

				if (double1 < double2)
					return -1;
				if (double1 > double2)
					return 1;

				return 0;
			});
		}

		public static void Function2()
		{
			var numbersArray = new[] { 3, 4, 5, 6, 7, 1, 3 };
			var stringArray = new[] { "wefw", "we", "erergeg", "23", "efergfergerg" };

			var result1 = numbersArray.Filter(number => number > 3);
			var result2 = stringArray.Filter(str => str.Length > 5);
		}

		/// <summary>
		/// Реализовать обобщенную функцию сортировки массива .Sort									done
		/// с кастомной функцией сравнения <TArray, TArray, int>
		/// </summary>
		public static void Function3()
		{
			var numbersArray = new[] { 3, 4, 5, 6, -7, 1, 30 };
			var stringArray = new[] { "wefw", "we", "erergeg", "23", "efergfergerg" };

			var result1 = numbersArray.Sort((a, b) => a > b ? 1 : 0);

			foreach (var element in numbersArray)
			{
				Console.WriteLine(element);
			}

			var result2 = GenericFunctions.Sort(stringArray, (a, b) =>
			{
				if (a.Length < b.Length)
					return 1;
				else
					return 0;
			});

			foreach (var element in stringArray)
			{
				Console.WriteLine(element);
			}
		}

		public static void Function6()
		{
			var numbersArray = new[] { 3, 4, 5, 6, -7, 3, 1, 30, 10, 3 };
			var newElement1 = 576;
			var stringArray = new[] { "23", "wefw", "we", "erergeg", "23", "efergfergerg", "23" };
			var newElement2 = "hoba";

			var result1 = numbersArray.AddAfter(newElement1, a => a == 3);
			result1.PrintArray();
			Console.WriteLine();
			var result2 = stringArray.AddAfter(newElement2, a => a == "23");
			result2.PrintArray();
		}

		public static void Function7()
		{
			var numbersArray = new[] { 3, 4, 5, 6, -7, 3, 1, 30, 10, 3 };
			var stringArray = new[] { "23", "wefw", "we", "erergeg", "23", "efergfergerg", "23" };

			var result1 = GenericFunctions.RemoveWhere(numbersArray, a => a == 3);
			foreach (var element in result1)
			{
				Console.WriteLine(element);
			}
			Console.WriteLine();
			var result2 = GenericFunctions.RemoveWhere(stringArray, a => a == "23");
			foreach (var element in result2)
			{
				Console.WriteLine(element);
			}
		}

		public static void Function9()
		{
			var numbersArray = new[] { 3, 4, 5, 6, -7, 3, 1, 30, 10, 3 };
			var stringArray = new[] { "23", "wefw", "we", "erergeg", "23", "efergfergerg", "23" };

			var result1 = GenericFunctions.IndexesOfWhere(numbersArray, a => a == 3);
			foreach (var element in result1)
			{
				Console.WriteLine(element);
			}
			Console.WriteLine();
			var result2 = GenericFunctions.IndexesOfWhere(stringArray, a => a == "23");
			foreach (var element in result2)
			{
				Console.WriteLine(element);
			}
		}

		public static void Function10()
		{
			var numbersArray = new[] { 3, 4, 6, 6, -7, 3, 1, 30, 10, 3 };
			var stringArray = new[] { "23", "wefw", "we", "erergeg", "23", "efergfergerg", "23" };

			var result1 = GenericFunctions.SumRec(numbersArray, (a, b) => a + b);
			Console.WriteLine(result1);

			Console.WriteLine();

			var result2 = GenericFunctions.SumRec(stringArray, (a, b) => a + b);
			Console.WriteLine(result2);

		}

		public static void Function11()
		{
			var srtingArray1 = new string[] { "3242", "23", "876", "953", "-55" };

			var result = srtingArray1.MinRec((element1, element2) =>
			{
				var number1 = int.Parse(element1);
				var number2 = int.Parse(element2);

				return number1 < number2 ? element1 : element2;
			});

			var result2 = srtingArray1.MinRec((element1, element2) => element1.Length < element2.Length ? element1 : element2);


		}

		#region Functions

		public static TArray SumRec<TArray>(TArray[] array, Func<TArray, TArray, TArray> sumFunc, int elemIndex = 0)
		{
			if (elemIndex == 0)
				elemIndex = array.Length;

			if (elemIndex == 2)
			{
				return sumFunc(array[0], array[1]);
			}

			var last = array[elemIndex - 1];
			var sum = sumFunc(SumRec(array, sumFunc, elemIndex - 1), last);

			return sum;
		}

		public static int[] IndexesOfWhere<TArray>(TArray[] array, Func<TArray, bool> searchFunc)
		{
			var indexArray = new int[array.Length];
			var index = 0;

			for (var i = 0; i < array.Length; i++)
			{
				if (searchFunc(array[i]))
					indexArray[index++] = i;
			}

			if (index == 0)
			{
				Console.WriteLine("There is no such element here");
				var result = new int[0];
				return result;
			}
			else
			{
				var result = new int[index];
				for (var i = 0; i < result.Length; i++)
				{
					result[i] = indexArray[i];
				}
				return result;
			}
		}

		public static TArray[] RemoveWhere<TArray>(TArray[] array, Func<TArray, bool> delFunc)
		{
			var newArray = new TArray[array.Length];
			var index = 0;

			foreach (var element in array)
			{
				if (!delFunc(element))
				{
					newArray[index++] = element;
				}
			}

			if (index == array.Length)
			{
				Console.WriteLine("There is no such element here");
				return array;
			}
			else
			{
				var result = new TArray[index];
				for (var i = 0; i < result.Length; i++)
				{
					result[i] = newArray[i];
				}
				return result;
			}
		}

		public static TArray[] AddAfter<TArray>(this TArray[] array, TArray newElement, Func<TArray, bool> addFunc)
		{
			var newArray = new TArray[array.Length * 2];
			var newArrayElementIndex = 0;
			var conter = 0;

			for (var elementIndex = 0; elementIndex < array.Length; elementIndex++)
			{
				if (addFunc(array[elementIndex]))
				{
					conter++;
					newArray[newArrayElementIndex++] = array[elementIndex];
					newArray[newArrayElementIndex++] = newElement;
				}
				else
					newArray[newArrayElementIndex++] = array[elementIndex];
			}

			if (conter == 0)
			{
				Console.WriteLine("There is no such element here");
				return array;
			}
			else
			{
				var result = new TArray[array.Length + conter];
				for (var i = 0; i < result.Length; i++)
				{
					result[i] = newArray[i];
				}
				return result;
			}
		}

		public static TArray Sort<TArray>(this TArray[] array, Func<TArray, TArray, int> sortFunc) // почему ломается, если делаю экстеншином?
		{
			var transit = array[0];
			for (var checkedElem = 0; checkedElem < array.Length - 1; checkedElem++)
			{
				for (var otherElem = checkedElem + 1; otherElem < array.Length; otherElem++)
				{
					if (sortFunc(array[checkedElem], array[otherElem]) > 0)
					{
						transit = array[checkedElem];
						array[checkedElem] = array[otherElem];
						array[otherElem] = transit;
					}
				}
			}
			return array[array.Length - 1];
		}

		public static TArray MinCustom<TArray>(TArray[] array, Func<TArray, TArray, int> compareFunc)
		{
			var min = array[0];
			foreach (var element in array)
			{
				if (compareFunc(min, element) > 0)
				{
					min = element;
				}
			}
			return min;
		}

		public static TArray[] Filter<TArray>(this TArray[] array, Func<TArray, bool> conditionFunc)
		{
			var newArray = new TArray[array.Length];

			int index = 0;
			foreach (var element in array)
			{
				if (conditionFunc(element))
					newArray[index++] = element;
			}

			var result = new TArray[index];
			for (var i = 0; i < index; i++)
			{
				result[i] = newArray[i];
			}

			return result;
		}

		public static TArray MinRec<TArray>(this TArray[] array, Func<TArray, TArray, TArray> minFunc, int length = 0)
		{
			if (length == 0)
				length = array.Length;

			if (length == 2)
			{
				return minFunc(array[0], array[1]);
			}

			var last = array[length - 1];

			var min = minFunc(MinRec(array, minFunc, length - 1), last);

			return min;
		}

		#endregion

		#region Descriptions

		public static void Execute()
		{
			var res1 = SumStr("123", "1234", (str1, str2) =>
			{
				if (!int.TryParse(str1, out var a))
					return "";
				if (!int.TryParse(str2, out var b))
					return "";

				return (a + b).ToString();
			});
			var res2 = SumStr("123", "1234", (a, b) => string.Concat(a, b));

			///////////////////////////////////

			var result = SumGeneric(5, 10, (a, b) => a + b);
			var result1 = SumGeneric("5", "10", (a, b) => string.Concat(a, b));

			////////////////////////////////////

			var result2 = SumGeneric2("string", 123, (str, number) => string.Concat(str, number.ToString()));
			var resul3 = SumGeneric2(123, 321, (number1, number2) => (number1 + number2).ToString());
		}

		public static T3 SumGeneric2<T1, T2, T3>(T1 element1, T2 element2, Func<T1, T2, T3> funcSum)
		{
			return funcSum(element1, element2);
		}

		public static T SumGeneric<T>(T element1, T element2, Func<T, T, T> funcSum)
		{
			return funcSum(element1, element2);
		}

		public static string SumStr(string string1, string string2, Func<string, string, string> func)
		{
			return func(string1, string2);
		}


		#endregion
	}
}
