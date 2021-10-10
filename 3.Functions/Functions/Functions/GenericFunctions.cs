using System;
using System.Linq;

namespace Functions
{
	/// <summary>
	/// 1. Реализовать обобщенные функции для поиска мин и макс значения .MinCustom, .MaxCustom
	/// в массиве с касотмной функцией сравнения
	///
	/// 2. Реализовать функцию фильтрацию элементов массива .Filter
	/// с кастомной функцией условия
	///
	/// 3. Реализовать обобщенную функцию сортировки массива .Sort									hw
	/// с кастомной функцией сравнения <TArray, TArray, int>
	///
	/// 4. Реализовать обобщенную функцию перемешки массива .Mix
	///
	/// 5. Реализовать обобщенную функцию вывода массива .PrintWhere
	/// c кастомной функцией условия <TArray, bool>
	///
	/// 6. Реализовать обобщенную функцию добавления элемента в массив .AddAfter					hw
	/// после первого элемента, удовлетворяющего условию кастомной функции <TArray, bool>
	///
	/// 7. Реализовать обобщенную функцию удаления элемента(ов) из массива .RemoveWhere				hw
	/// с кастомной функцией условия <TArray, bool>
	///
	/// 8. Реализовать обобщенную функцию подсчета количества элементов в массиве .CountWhere
	/// с кастомной функцией условия <TArray, bool>
	///
	/// 9. Реализовать функцию .IndexesOfWhere, возвращающую индексы элементов обобщенного массива	hw
	/// с кастомной функцией фильтрации <TArray, bool>
	///
	/// 10. Реализовать рекурсивную обобщенную функцию суммирования .SumRec							HW
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
			var res1 = SumStr("123", "1234", (str1, str2) => {
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
