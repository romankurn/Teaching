using System;
using Newtonsoft.Json;

namespace Lesson2
{
	public class Arrays
	{
		/// <summary>
		/// Преобразовывает элементы в строке, разделенные пробелами к указанному типу данных
		/// </summary>
		/// <typeparam name="TArray"></typeparam>
		/// <param name="line"></param>
		/// <returns></returns>
		public static TArray[] ConvertStringToArray<TArray>(string line)
		{
			var jarray = $"[{line.Replace(" ", ",")}]";

			return JsonConvert.DeserializeObject<TArray[]>(jarray);
		}

		#region Вывод

		/// <summary>
		/// Выводит все элементы массива.
		/// </summary>
		public static void Func1()
		{

		}

		/// <summary>
		/// Выводит все элементы массива в обратном порядке
		/// </summary>
		public static void Func2()
		{

		}

		/// <summary>
		/// Выводит чётные элементы массива
		/// </summary>
		public static void Func3()
		{

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
		{ }

		/// <summary>
		/// В массив добавляется элемент в начало
		/// </summary>
		public static void Func6()
		{ }

		/// <summary>
		/// В массив добавляется элемент в позицию k
		/// </summary>
		public static void Func7()
		{ }

		#endregion

		#region Удаление

		/// <summary>
		/// Из массива удаляется элемент с конца
		/// </summary>
		public static void Func8()
		{ }

		/// <summary>
		/// Из массива удаляется элемент с начала
		/// </summary>
		public static void Func9()
		{ }

		/// <summary>
		/// Из массива удаляется элемент с позиции k
		/// </summary>
		public static void Func10()
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

		#endregion

		#region Обработка строки как массива символов - Comming soon...

		

		#endregion
	}
}
